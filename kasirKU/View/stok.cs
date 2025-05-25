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
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox6 = new TextBox();
            this.pictureBox1 = new PictureBox();
            this.pictureBox2 = new PictureBox();
            ((ISupportInitialize)dataGridView1).BeginInit();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            ((ISupportInitialize)this.pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(3, 355);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Kembali";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 150);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // button2
            // 
            button2.Location = new Point(12, 168);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Tambah";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(93, 168);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Edit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(174, 168);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 4;
            button4.Text = "Hapus";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(516, 168);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 5;
            button5.Text = "Pencarian";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(597, 169);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(191, 23);
            textBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveBorder;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(6, 216);
            label1.Name = "label1";
            label1.Size = new Size(90, 21);
            label1.TabIndex = 7;
            label1.Text = "Kode Produk";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(100, 215);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(191, 23);
            textBox2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveBorder;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(2, 252);
            label2.Name = "label2";
            label2.Size = new Size(95, 21);
            label2.TabIndex = 9;
            label2.Text = "Nama Produk";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(100, 251);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(191, 23);
            textBox3.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveBorder;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(336, 215);
            label3.Name = "label3";
            label3.Size = new Size(73, 21);
            label3.TabIndex = 11;
            label3.Text = "Harga Beli";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveBorder;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(336, 251);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 12;
            label4.Text = "Harga Jual";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(415, 213);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(191, 23);
            textBox4.TabIndex = 13;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(416, 251);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(191, 23);
            textBox5.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ActiveBorder;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(373, 285);
            label5.Name = "label5";
            label5.Size = new Size(38, 21);
            label5.TabIndex = 15;
            label5.Text = "Stok";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(417, 284);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(37, 23);
            textBox6.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = Color.FromArgb(255, 128, 128);
            this.pictureBox1.Location = new Point(-2, 163);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(801, 216);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = Color.FromArgb(255, 192, 192);
            this.pictureBox2.Location = new Point(-2, -3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(801, 216);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // stok
            // 
            ClientSize = new Size(800, 381);
            Controls.Add(textBox6);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(this.pictureBox2);
            Controls.Add(this.pictureBox1);
            Name = "stok";
            ((ISupportInitialize)dataGridView1).EndInit();
            ((ISupportInitialize)this.pictureBox1).EndInit();
            ((ISupportInitialize)this.pictureBox2).EndInit();
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
            bool success = crud.tambahProduk(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
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
            dataGridView1.DataSource = crud.lihatProduk();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void ClearFields()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        string oldKode = ""; // Tambahkan di class-level (di luar method) agar bisa diakses di seluruh form

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                oldKode = row.Cells["kode_produk"].Value.ToString();

                textBox2.Text = row.Cells["kode_produk"].Value.ToString();
                textBox3.Text = row.Cells["nama_produk"].Value.ToString();
                textBox4.Text = row.Cells["harga_beli"].Value.ToString();
                textBox5.Text = row.Cells["harga_jual"].Value.ToString();
                textBox6.Text = row.Cells["stok"].Value.ToString();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool success = crud.hapusProduk(textBox2.Text);
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
            dataGridView1.DataSource = crud.cariProduk(textBox1.Text);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            bool success = crud.UpdateProduk(
                oldKode,
                textBox2.Text, textBox3.Text,
                textBox4.Text, textBox5.Text,
                textBox6.Text
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
