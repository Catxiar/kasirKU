using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kasirKU.Controller;
using kasirKU.Model;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace kasirKU
{
    public partial class stok : Form
    {
        private koneksi db;
        private CRUDS crud;
        public stok()
        {
            InitializeComponent();
            db = new koneksi();
            crud = new CRUDS();

            LoadData();
        }

        private void InitializeComponent()
        {
            this.buttonkembali = new Button();
            tampildata = new DataGridView();
            buttontambah = new Button();
            buttonedit = new Button();
            buttonhapus = new Button();
            this.buttoncari = new Button();
            isicari = new TextBox();
            labelkodeproduk = new Label();
            this.isikodeproduk = new TextBox();
            labelnamaproduk = new Label();
            this.isisnamaproduk = new TextBox();
            labelhargabeliproduk = new Label();
            labelhargajualproduk = new Label();
            this.isihargabeli = new TextBox();
            this.isihargajual = new TextBox();
            labelstok = new Label();
            this.isistok = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((ISupportInitialize)tampildata).BeginInit();
            ((ISupportInitialize)pictureBox1).BeginInit();
            ((ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // buttonkembali
            // 
            this.buttonkembali.Location = new Point(3, 355);
            this.buttonkembali.Name = "buttonkembali";
            this.buttonkembali.Size = new Size(75, 23);
            this.buttonkembali.TabIndex = 0;
            this.buttonkembali.Text = "Kembali";
            this.buttonkembali.UseVisualStyleBackColor = true;
            this.buttonkembali.Click += this.button1_Click;
            // 
            // tampildata
            // 
            tampildata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tampildata.Location = new Point(12, 12);
            tampildata.Name = "tampildata";
            tampildata.Size = new Size(776, 150);
            tampildata.TabIndex = 1;
            tampildata.CellClick += dataGridView1_CellClick;
            // 
            // buttontambah
            // 
            buttontambah.Location = new Point(12, 168);
            buttontambah.Name = "buttontambah";
            buttontambah.Size = new Size(75, 23);
            buttontambah.TabIndex = 2;
            buttontambah.Text = "Tambah";
            buttontambah.UseVisualStyleBackColor = true;
            buttontambah.Click += button2_Click;
            // 
            // buttonedit
            // 
            buttonedit.Location = new Point(93, 168);
            buttonedit.Name = "buttonedit";
            buttonedit.Size = new Size(75, 23);
            buttonedit.TabIndex = 3;
            buttonedit.Text = "Edit";
            buttonedit.UseVisualStyleBackColor = true;
            buttonedit.Click += button3_Click;
            // 
            // buttonhapus
            // 
            buttonhapus.Location = new Point(174, 168);
            buttonhapus.Name = "buttonhapus";
            buttonhapus.Size = new Size(75, 23);
            buttonhapus.TabIndex = 4;
            buttonhapus.Text = "Hapus";
            buttonhapus.UseVisualStyleBackColor = true;
            buttonhapus.Click += button4_Click;
            // 
            // buttoncari
            // 
            this.buttoncari.Location = new Point(516, 168);
            this.buttoncari.Name = "buttoncari";
            this.buttoncari.Size = new Size(75, 23);
            this.buttoncari.TabIndex = 5;
            this.buttoncari.Text = "Pencarian";
            this.buttoncari.UseVisualStyleBackColor = true;
            this.buttoncari.Click += this.button5_Click;
            // 
            // isicari
            // 
            isicari.Location = new Point(597, 169);
            isicari.Name = "isicari";
            isicari.Size = new Size(191, 23);
            isicari.TabIndex = 6;
            // 
            // labelkodeproduk
            // 
            labelkodeproduk.AutoSize = true;
            labelkodeproduk.BackColor = SystemColors.ActiveBorder;
            labelkodeproduk.BorderStyle = BorderStyle.FixedSingle;
            labelkodeproduk.Font = new Font("Segoe UI", 10F);
            labelkodeproduk.Location = new Point(6, 216);
            labelkodeproduk.Name = "labelkodeproduk";
            labelkodeproduk.Size = new Size(90, 21);
            labelkodeproduk.TabIndex = 7;
            labelkodeproduk.Text = "Kode Produk";
            // 
            // isikodeproduk
            // 
            this.isikodeproduk.Location = new Point(100, 215);
            this.isikodeproduk.Name = "isikodeproduk";
            this.isikodeproduk.Size = new Size(191, 23);
            this.isikodeproduk.TabIndex = 8;
            // 
            // labelnamaproduk
            // 
            labelnamaproduk.AutoSize = true;
            labelnamaproduk.BackColor = SystemColors.ActiveBorder;
            labelnamaproduk.BorderStyle = BorderStyle.FixedSingle;
            labelnamaproduk.Font = new Font("Segoe UI", 10F);
            labelnamaproduk.Location = new Point(2, 252);
            labelnamaproduk.Name = "labelnamaproduk";
            labelnamaproduk.Size = new Size(95, 21);
            labelnamaproduk.TabIndex = 9;
            labelnamaproduk.Text = "Nama Produk";
            // 
            // isisnamaproduk
            // 
            this.isisnamaproduk.Location = new Point(100, 251);
            this.isisnamaproduk.Name = "isisnamaproduk";
            this.isisnamaproduk.Size = new Size(191, 23);
            this.isisnamaproduk.TabIndex = 10;
            // 
            // labelhargabeliproduk
            // 
            labelhargabeliproduk.AutoSize = true;
            labelhargabeliproduk.BackColor = SystemColors.ActiveBorder;
            labelhargabeliproduk.BorderStyle = BorderStyle.FixedSingle;
            labelhargabeliproduk.Font = new Font("Segoe UI", 10F);
            labelhargabeliproduk.Location = new Point(336, 215);
            labelhargabeliproduk.Name = "labelhargabeliproduk";
            labelhargabeliproduk.Size = new Size(73, 21);
            labelhargabeliproduk.TabIndex = 11;
            labelhargabeliproduk.Text = "Harga Beli";
            // 
            // labelhargajualproduk
            // 
            labelhargajualproduk.AutoSize = true;
            labelhargajualproduk.BackColor = SystemColors.ActiveBorder;
            labelhargajualproduk.BorderStyle = BorderStyle.FixedSingle;
            labelhargajualproduk.Font = new Font("Segoe UI", 10F);
            labelhargajualproduk.Location = new Point(336, 251);
            labelhargajualproduk.Name = "labelhargajualproduk";
            labelhargajualproduk.Size = new Size(75, 21);
            labelhargajualproduk.TabIndex = 12;
            labelhargajualproduk.Text = "Harga Jual";
            // 
            // isihargabeli
            // 
            this.isihargabeli.Location = new Point(415, 213);
            this.isihargabeli.Name = "isihargabeli";
            this.isihargabeli.Size = new Size(191, 23);
            this.isihargabeli.TabIndex = 13;
            // 
            // isihargajual
            // 
            this.isihargajual.Location = new Point(416, 251);
            this.isihargajual.Name = "isihargajual";
            this.isihargajual.Size = new Size(191, 23);
            this.isihargajual.TabIndex = 14;
            // 
            // labelstok
            // 
            labelstok.AutoSize = true;
            labelstok.BackColor = SystemColors.ActiveBorder;
            labelstok.BorderStyle = BorderStyle.FixedSingle;
            labelstok.Font = new Font("Segoe UI", 10F);
            labelstok.Location = new Point(373, 285);
            labelstok.Name = "labelstok";
            labelstok.Size = new Size(38, 21);
            labelstok.TabIndex = 15;
            labelstok.Text = "Stok";
            // 
            // isistok
            // 
            this.isistok.Location = new Point(417, 284);
            this.isistok.Name = "isistok";
            this.isistok.Size = new Size(37, 23);
            this.isistok.TabIndex = 16;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(255, 128, 128);
            pictureBox1.Location = new Point(-2, 163);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(801, 216);
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(255, 192, 192);
            pictureBox2.Location = new Point(-2, -3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(801, 216);
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            // 
            // stok
            // 
            ClientSize = new Size(800, 381);
            Controls.Add(this.isistok);
            Controls.Add(labelstok);
            Controls.Add(this.isihargajual);
            Controls.Add(this.isihargabeli);
            Controls.Add(labelhargajualproduk);
            Controls.Add(labelhargabeliproduk);
            Controls.Add(this.isisnamaproduk);
            Controls.Add(labelnamaproduk);
            Controls.Add(this.isikodeproduk);
            Controls.Add(labelkodeproduk);
            Controls.Add(isicari);
            Controls.Add(this.buttoncari);
            Controls.Add(buttonhapus);
            Controls.Add(buttonedit);
            Controls.Add(buttontambah);
            Controls.Add(tampildata);
            Controls.Add(this.buttonkembali);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "stok";
            ((ISupportInitialize)tampildata).EndInit();
            ((ISupportInitialize)pictureBox1).EndInit();
            ((ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuUtama formMenuUtama = new MenuUtama();
            formMenuUtama.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool success = crud.tambahProduk(isikodeproduk.Text, isisnamaproduk.Text, isihargabeli.Text, isihargajual.Text, isistok.Text);
            if (success)
            {
                MessageBox.Show("Data berhasil ditambahkan!");
                LoadData();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Produk dengan kode atau nama tersebut sudah ada!");
            }
        }



        

        private void LoadData()
        {
            tampildata.DataSource = crud.lihatProduk();
            tampildata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            foreach (DataGridViewColumn col in tampildata.Columns)
            {
                string header = col.HeaderText.Replace("_", " ");
                col.HeaderText = textInfo.ToTitleCase(header); // Misalnya "nama_produk" → "Nama Produk"
            }
        }



        private void ClearFields()
        {
            isikodeproduk.Text = "";
            isisnamaproduk.Text = "";
            isihargabeli.Text = "";
            isihargajual.Text = "";
            isistok.Text = "";
        }

        string oldKode = ""; // Tambahkan di class-level (di luar method) agar bisa diakses di seluruh form

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tampildata.Rows[e.RowIndex];
                oldKode = row.Cells["kode_produk"].Value.ToString();

                isikodeproduk.Text = row.Cells["kode_produk"].Value.ToString();
                isisnamaproduk.Text = row.Cells["nama_produk"].Value.ToString();
                isihargabeli.Text = row.Cells["harga_beli"].Value.ToString();
                isihargajual.Text = row.Cells["harga_jual"].Value.ToString();
                isistok.Text = row.Cells["stok"].Value.ToString();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool success = crud.hapusProduk(isikodeproduk.Text);
                if (success)
                {
                    MessageBox.Show("Data berhasil dihapus.");
                    LoadData();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Data gagal dihapus.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tampildata.DataSource = crud.cariProduk(isicari.Text);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            bool success = crud.UpdateProduk(
                oldKode,
                isikodeproduk.Text, isisnamaproduk.Text,
                isihargabeli.Text, isihargajual.Text,
                isistok.Text
            );

            if (success)
            {
                MessageBox.Show("Data berhasil diperbarui.");
                LoadData();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Data gagal diperbarui.");
            }
        }


    }



}
