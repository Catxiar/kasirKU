namespace kasirKU
{
    public partial class MenuUtama : Form
    {
        public MenuUtama()
        {
            InitializeComponent();
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
    }
}
