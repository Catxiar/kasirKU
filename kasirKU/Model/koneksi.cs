using MySql.Data.MySqlClient;

namespace kasirKU.Model
{
    public class koneksi
    {
        private MySqlConnection conn;

        public koneksi()
        {
            string connectionString = "Server=localhost;Database=kasir;Uid=root;Pwd=;";
            conn = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return conn;
        }

        public void OpenConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void CloseConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
