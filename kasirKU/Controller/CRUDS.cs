using System;
using System.Data;
using kasirKU.Model;
using MySql.Data.MySqlClient;

namespace kasirKU.Controller
{
    public class CRUDS
    {
        private koneksi db;

        public CRUDS()
        {
            db = new koneksi();
        }

        public DataTable lihatProduk()
        {
            db.OpenConnection();
            string query = "SELECT * FROM produk";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.GetConnection());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            db.CloseConnection();
            return dt;
        }

        public bool tambahProduk(string kode, string nama, string beli, string jual, string stok)
        {
            db.OpenConnection();

            // Cek duplikat
            string checkQuery = "SELECT COUNT(*) FROM produk WHERE kode_produk = @kode OR nama_produk = @nama";
            MySqlCommand checkCmd = new MySqlCommand(checkQuery, db.GetConnection());
            checkCmd.Parameters.AddWithValue("@kode", kode);
            checkCmd.Parameters.AddWithValue("@nama", nama);

            int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
            if (exists > 0)
            {
                db.CloseConnection();
                return false;
            }

            string query = "INSERT INTO produk (kode_produk, nama_produk, harga_beli, harga_jual, stok) " +
                           "VALUES (@kode, @nama, @beli, @jual, @stok)";
            MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@kode", kode);
            cmd.Parameters.AddWithValue("@nama", nama);
            cmd.Parameters.AddWithValue("@beli", beli);
            cmd.Parameters.AddWithValue("@jual", jual);
            cmd.Parameters.AddWithValue("@stok", stok);

            cmd.ExecuteNonQuery();
            db.CloseConnection();
            return true;
        }

        public bool UpdateProduk(string oldKode, string kode, string nama, string beli, string jual, string stok)
        {
            db.OpenConnection();
            string query = "UPDATE produk SET kode_produk = @kode, nama_produk = @nama, harga_beli = @beli, " +
                           "harga_jual = @jual, stok = @stok WHERE kode_produk = @oldKode";
            MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@kode", kode);
            cmd.Parameters.AddWithValue("@nama", nama);
            cmd.Parameters.AddWithValue("@beli", beli);
            cmd.Parameters.AddWithValue("@jual", jual);
            cmd.Parameters.AddWithValue("@stok", stok);
            cmd.Parameters.AddWithValue("@oldKode", oldKode);

            int result = cmd.ExecuteNonQuery();
            db.CloseConnection();
            return result > 0;
        }

        public bool hapusProduk(string kode)
        {
            db.OpenConnection();
            string query = "DELETE FROM produk WHERE kode_produk = @kode";
            MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@kode", kode);
            int result = cmd.ExecuteNonQuery();
            db.CloseConnection();
            return result > 0;
        }

        public DataTable cariProduk(string keyword)
        {
            db.OpenConnection();
            string query = "SELECT * FROM produk WHERE " +
                           "kode_produk LIKE CONCAT('%', @keyword, '%') OR " +
                           "nama_produk LIKE CONCAT('%', @keyword, '%') OR " +
                           "harga_jual LIKE CONCAT('%', @keyword, '%') OR " +
                           "harga_beli LIKE CONCAT('%', @keyword, '%') OR " +
                           "stok LIKE CONCAT('%', @keyword, '%')";
            MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@keyword", keyword);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            db.CloseConnection();
            return dt;
        }

        public int SimpanTransaksi(double total, DataTable detail)
        {
            int idTransaksi = -1;

            db.OpenConnection();
            MySqlTransaction trans = db.GetConnection().BeginTransaction();

            try
            {
                // Simpan ke tabel transaksi
                string query1 = "INSERT INTO transaksi (tanggal, total) VALUES (@tanggal, @total)";
                MySqlCommand cmd1 = new MySqlCommand(query1, db.GetConnection(), trans);
                cmd1.Parameters.AddWithValue("@tanggal", DateTime.Now);
                cmd1.Parameters.AddWithValue("@total", total);
                cmd1.ExecuteNonQuery();

                // Ambil ID transaksi terakhir
                idTransaksi = (int)cmd1.LastInsertedId;

                // Simpan ke detail_transaksi
                foreach (DataRow row in detail.Rows)
                {
                    string query2 = @"INSERT INTO detail_transaksi 
                (id_transaksi, kode_produk, jumlah, harga_jual, total) 
                VALUES (@id_trans, @kode, @jumlah, @harga, @total)";
                    MySqlCommand cmd2 = new MySqlCommand(query2, db.GetConnection(), trans);
                    cmd2.Parameters.AddWithValue("@id_trans", idTransaksi);
                    cmd2.Parameters.AddWithValue("@kode", row["kode_produk"]);
                    cmd2.Parameters.AddWithValue("@jumlah", row["jumlah"]);
                    cmd2.Parameters.AddWithValue("@harga", row["harga_jual"]);
                    cmd2.Parameters.AddWithValue("@total", row["total"]);
                    cmd2.ExecuteNonQuery();

                    // Update stok
                    string queryStok = "UPDATE produk SET stok = stok - @jumlah WHERE kode_produk = @kode";
                    MySqlCommand cmd3 = new MySqlCommand(queryStok, db.GetConnection(), trans);
                    cmd3.Parameters.AddWithValue("@jumlah", row["jumlah"]);
                    cmd3.Parameters.AddWithValue("@kode", row["kode_produk"]);
                    cmd3.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Gagal menyimpan transaksi: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            return idTransaksi;
        }

    }
}
