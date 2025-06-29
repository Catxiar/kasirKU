using kasirKU.Controller;
using kasirKU.Model;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;

namespace kasirKU
{
    public partial class MenuUtama : Form
    {
        private koneksi db;
        private CRUDS crud;

        private DataTable dataTransaksi;

        public MenuUtama()
        {
            InitializeComponent();
            db = new koneksi();
            crud = new CRUDS();

            InitTransaksiTable();
            LoadData();

            // Event handler tombol tambah
            buttontambah.Click += Buttontambah_Click;
            buttonedit.Click += buttonedit_Click;
            buttonhapus.Click += buttonhapus_Click;
            tampildata.SelectionChanged += tampildata_SelectionChanged;
            isikodeproduk.TextChanged += Isikodeproduk_TextChanged;
            buttonsimpan.Click += buttonsimpan_Click;

        }

        private void stock_click(object sender, EventArgs e)
        {
            stok formStok = new stok();
            formStok.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void InitTransaksiTable()
        {
            // Inisialisasi tabel transaksi
            dataTransaksi = new DataTable();
            dataTransaksi.Columns.Add("kode_produk");
            dataTransaksi.Columns.Add("nama_produk");
            dataTransaksi.Columns.Add("jumlah", typeof(int));
            dataTransaksi.Columns.Add("harga_jual", typeof(double));
            dataTransaksi.Columns.Add("total", typeof(double));

            tampildata.DataSource = dataTransaksi;
            tampildata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadData()
        {
            tampildata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn col in tampildata.Columns)
            {
                col.HeaderText = System.Globalization.CultureInfo.CurrentCulture.TextInfo
                    .ToTitleCase(col.HeaderText.Replace("_", " "));
            }

            HitungTotal();
        }

        private void HitungTotal()
        {
            double total = 0;
            foreach (DataGridViewRow row in tampildata.Rows)
            {
                if (row.Cells["total"].Value != null)
                {
                    double nilai;
                    if (double.TryParse(row.Cells["total"].Value.ToString(), out nilai))
                    {
                        total += nilai;
                    }
                }
            }

            isitotal.Text = total.ToString("N0");
        }

        private void Buttontambah_Click(object sender, EventArgs e)
        {
            string kodeProduk = isikodeproduk.Text.Trim();
            if (!int.TryParse(isijumlah.Text.Trim(), out int jumlah) || jumlah <= 0)
            {
                MessageBox.Show("Jumlah harus angka lebih dari 0");
                return;
            }

            // Ambil data produk dari database
            DataTable produk = crud.cariProduk(kodeProduk);
            if (produk.Rows.Count == 0)
            {
                MessageBox.Show("Produk tidak ditemukan!");
                return;
            }

            string namaProduk = produk.Rows[0]["nama_produk"].ToString();
            double hargaJual = Convert.ToDouble(produk.Rows[0]["harga_jual"]);
            int stokTersedia = Convert.ToInt32(produk.Rows[0]["stok"]);
            double totalItem = hargaJual * jumlah;

            // Validasi stok
            if (jumlah > stokTersedia)
            {
                MessageBox.Show($"Stok tidak mencukupi! Stok tersedia: {stokTersedia}");
                return;
            }

            foreach (DataRow row in dataTransaksi.Rows)
            {
                if (row["kode_produk"].ToString() == kodeProduk)
                {
                    MessageBox.Show("Produk sudah ada di daftar transaksi.\nSilakan edit jumlahnya jika ingin menambah.");
                    return;
                }
            }

            // Tambahkan ke DataTable
            dataTransaksi.Rows.Add(kodeProduk, namaProduk, jumlah, hargaJual, totalItem);
            tampildata.DataSource = dataTransaksi;

            HitungTotal();

            // Bersihkan input
            isikodeproduk.Clear();
            isijumlah.Clear();
        }

        private void buttonedit_Click(object sender, EventArgs e)
        {

            if (tampildata.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin diedit terlebih dahulu!");
                return;
            }

            if (!int.TryParse(isijumlah.Text.Trim(), out int jumlahBaru) || jumlahBaru <= 0)
            {
                MessageBox.Show("Jumlah harus angka lebih dari 0");
                return;
            }

            DataGridViewRow row = tampildata.SelectedRows[0];
            string kodeProduk = row.Cells["kode_produk"].Value.ToString();

            // Cek stok dulu
            DataTable produk = crud.cariProduk(kodeProduk);
            if (produk.Rows.Count == 0)
            {
                MessageBox.Show("Produk tidak ditemukan di database!");
                return;
            }

            int stokTersedia = Convert.ToInt32(produk.Rows[0]["stok"]);
            if (jumlahBaru > stokTersedia)
            {
                MessageBox.Show($"Jumlah melebihi stok! Stok tersedia: {stokTersedia}");
                return;
            }

            double harga = Convert.ToDouble(row.Cells["harga_jual"].Value);
            double totalBaru = harga * jumlahBaru;

            // Update di DataTable
            row.Cells["jumlah"].Value = jumlahBaru;
            row.Cells["total"].Value = totalBaru;

            HitungTotal();
            isikodeproduk.Clear();
            isijumlah.Clear();
        }

        private void buttonhapus_Click(object sender, EventArgs e)
        {
            if (tampildata.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris yang ingin dihapus!");
                return;
            }

            DialogResult result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow row = tampildata.SelectedRows[0];
                tampildata.Rows.Remove(row); // Ini langsung hapus dari tampilan dan DataTable

                HitungTotal();
            }
        }

        private void tampildata_SelectionChanged(object sender, EventArgs e)
        {
            if (tampildata.SelectedRows.Count > 0)
            {
                var row = tampildata.SelectedRows[0];
                isikodeproduk.Text = row.Cells["kode_produk"].Value.ToString();
                isijumlah.Text = row.Cells["jumlah"].Value.ToString();
            }
        }

        private void Isikodeproduk_TextChanged(object sender, EventArgs e)
        {
            string kode = isikodeproduk.Text.Trim();
            if (kode.Length < 2) return;

            DataTable produk = crud.cariProduk(kode);
            if (produk.Rows.Count > 0)
            {
                string nama = produk.Rows[0]["nama_produk"].ToString();
                string harga = Convert.ToDouble(produk.Rows[0]["harga_jual"]).ToString("N0");
                string stok = produk.Rows[0]["stok"].ToString();

                // Tampilkan informasi sebagai tooltip
                isikodeproduk.BackColor = Color.LightYellow;
                isikodeproduk.ForeColor = Color.Black;
                ToolTip tip = new ToolTip();
                tip.SetToolTip(isikodeproduk, $"Nama: {nama}\nHarga: {harga}\nStok: {stok}");

                // Seleksi baris di DataGridView jika produk sudah ditambahkan
                foreach (DataGridViewRow row in tampildata.Rows)
                {
                    if (row.Cells["kode_produk"].Value != null &&
                        row.Cells["kode_produk"].Value.ToString().Equals(kode, StringComparison.OrdinalIgnoreCase))
                    {
                        row.Selected = true;
                        tampildata.CurrentCell = row.Cells[0]; // Fokuskan ke kolom pertama
                        return;
                    }
                }
            }
            else
            {
                isikodeproduk.BackColor = Color.MistyRose;
                isikodeproduk.ForeColor = Color.Black;
            }
        }

        private void buttonsimpan_Click(object sender, EventArgs e)
        {
            if (dataTransaksi.Rows.Count == 0)
            {
                MessageBox.Show("Belum ada transaksi yang bisa disimpan.");
                return;
            }

            double total = 0;
            foreach (DataRow row in dataTransaksi.Rows)
            {
                total += Convert.ToDouble(row["total"]);
            }

            int id = crud.SimpanTransaksi(total, dataTransaksi);
            if (id > 0)
            {
                MessageBox.Show("Transaksi berhasil disimpan. ID: " + id);

                // Cetak ke PDF setelah simpan
                PrintDocument pd = new PrintDocument();
                PrintDialog printDlg = new PrintDialog();

                pd.PrinterSettings = new PrinterSettings();
                pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                pd.PrinterSettings.PrintToFile = true;

                // Nama file default
                string tanggal = DateTime.Now.ToString("yyyy-MM-dd");
                string namaFile = $"struk-{tanggal}_ID{id}.pdf";
                // Gunakan SaveFileDialog agar user bisa memilih lokasi penyimpanan
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Title = "Simpan Struk Sebagai PDF";
                saveDlg.Filter = "PDF Files|*.pdf";
                saveDlg.FileName = $"struk-{tanggal}_ID{id}.pdf";

                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    string pathFile = saveDlg.FileName;
                    pd.PrinterSettings.PrintFileName = pathFile;

                    try
                    {
                        pd.Print(); // Cetak ke file yang dipilih user
                        MessageBox.Show($"Struk berhasil disimpan:\n{pathFile}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal mencetak PDF: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Penyimpanan dibatalkan.");
                }


                printDlg.Document = pd;

                pd.PrintPage += (s, eArgs) =>
                {
                    int y = 20;
                    Font font = new Font("Consolas", 10);
                    eArgs.Graphics.DrawString("========== STRUK PEMBELIAN ==========", font, Brushes.Black, 20, y);
                    y += 25;

                    string tanggalWaktu = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    eArgs.Graphics.DrawString("Waktu: " + tanggalWaktu, font, Brushes.Black, 20, y);
                    y += 25;

                    eArgs.Graphics.DrawString("=====================================", font, Brushes.Black, 20, y);
                    y += 25;

                    foreach (DataRow row in dataTransaksi.Rows)
                    {
                        string nama = row["nama_produk"].ToString();
                        string jumlah = row["jumlah"].ToString();
                        string harga = Convert.ToDouble(row["harga_jual"]).ToString("N0");
                        string baris = $"{nama,-20} x{jumlah} {harga}";
                        eArgs.Graphics.DrawString(baris, font, Brushes.Black, 20, y);
                        y += 20;
                    }
                    eArgs.Graphics.DrawString("=====================================", font, Brushes.Black, 20, y);
                    y += 25;

                    y += 10;
                    eArgs.Graphics.DrawString($"TOTAL: {total:N0}", new Font("Consolas", 11, FontStyle.Bold), Brushes.Black, 20, y);
                };

                try
                {
                    pd.Print(); // Simpan otomatis ke file PDF dengan nama yang disiapkan
                    MessageBox.Show($"Struk berhasil disimpan ke Desktop sebagai:\n{namaFile}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mencetak PDF: " + ex.Message);
                }
                // Bersihkan transaksi
                dataTransaksi.Clear();
                HitungTotal();
            }
        }




    }
}
