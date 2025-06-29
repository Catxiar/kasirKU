namespace kasirKU
{
    partial class MenuUtama
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tampildata = new DataGridView();
            labeltotal = new Label();
            isitotal = new TextBox();
            buttontambah = new Button();
            buttonedit = new Button();
            buttonhapus = new Button();
            isikodeproduk = new TextBox();
            labeljumlah = new Label();
            isijumlah = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            buttonstock = new Button();
            buttonsimpan = new Button();
            buttonkeluar = new Button();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)tampildata).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // tampildata
            // 
            tampildata.BackgroundColor = SystemColors.ControlLight;
            tampildata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tampildata.Location = new Point(12, 12);
            tampildata.Name = "tampildata";
            tampildata.Size = new Size(776, 150);
            tampildata.TabIndex = 0;
            // 
            // labeltotal
            // 
            labeltotal.AutoSize = true;
            labeltotal.BackColor = Color.FromArgb(224, 224, 224);
            labeltotal.BorderStyle = BorderStyle.FixedSingle;
            labeltotal.Font = new Font("Segoe UI", 20F);
            labeltotal.Location = new Point(589, 167);
            labeltotal.Name = "labeltotal";
            labeltotal.Size = new Size(93, 39);
            labeltotal.TabIndex = 1;
            labeltotal.Text = "TOTAL";
            // 
            // isitotal
            // 
            isitotal.Font = new Font("Segoe UI", 20F);
            isitotal.Location = new Point(688, 165);
            isitotal.Name = "isitotal";
            isitotal.Size = new Size(100, 43);
            isitotal.TabIndex = 2;
            // 
            // buttontambah
            // 
            buttontambah.Font = new Font("Segoe UI", 10F);
            buttontambah.Location = new Point(12, 168);
            buttontambah.Name = "buttontambah";
            buttontambah.Size = new Size(75, 27);
            buttontambah.TabIndex = 3;
            buttontambah.Text = "Tambah";
            buttontambah.UseVisualStyleBackColor = true;
            // 
            // buttonedit
            // 
            buttonedit.Font = new Font("Segoe UI", 10F);
            buttonedit.Location = new Point(12, 201);
            buttonedit.Name = "buttonedit";
            buttonedit.Size = new Size(75, 27);
            buttonedit.TabIndex = 4;
            buttonedit.Text = "Edit";
            buttonedit.UseVisualStyleBackColor = true;
            // 
            // buttonhapus
            // 
            buttonhapus.Font = new Font("Segoe UI", 10F);
            buttonhapus.Location = new Point(12, 234);
            buttonhapus.Name = "buttonhapus";
            buttonhapus.Size = new Size(75, 27);
            buttonhapus.TabIndex = 5;
            buttonhapus.Text = "Hapus";
            buttonhapus.UseVisualStyleBackColor = true;
            // 
            // isikodeproduk
            // 
            isikodeproduk.Font = new Font("Segoe UI", 10F);
            isikodeproduk.Location = new Point(107, 170);
            isikodeproduk.Name = "isikodeproduk";
            isikodeproduk.Size = new Size(150, 25);
            isikodeproduk.TabIndex = 6;
            // 
            // labeljumlah
            // 
            labeljumlah.AutoSize = true;
            labeljumlah.BackColor = Color.FromArgb(224, 224, 224);
            labeljumlah.BorderStyle = BorderStyle.FixedSingle;
            labeljumlah.Font = new Font("Segoe UI", 9F);
            labeljumlah.Location = new Point(181, 203);
            labeljumlah.Name = "labeljumlah";
            labeljumlah.Size = new Size(39, 17);
            labeljumlah.TabIndex = 7;
            labeljumlah.Text = "JMLH";
            // 
            // isijumlah
            // 
            isijumlah.Font = new Font("Segoe UI", 10F);
            isijumlah.Location = new Point(226, 199);
            isijumlah.Name = "isijumlah";
            isijumlah.Size = new Size(31, 25);
            isijumlah.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(255, 192, 192);
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(803, 162);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(255, 192, 255);
            pictureBox2.Location = new Point(-1, 83);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(803, 286);
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // buttonstock
            // 
            buttonstock.Font = new Font("Segoe UI", 10F);
            buttonstock.Location = new Point(486, 169);
            buttonstock.Name = "buttonstock";
            buttonstock.Size = new Size(75, 27);
            buttonstock.TabIndex = 13;
            buttonstock.Text = "Stock";
            buttonstock.UseVisualStyleBackColor = true;
            buttonstock.Click += stock_click;
            // 
            // buttonsimpan
            // 
            buttonsimpan.Font = new Font("Segoe UI", 10F);
            buttonsimpan.Location = new Point(284, 170);
            buttonsimpan.Name = "buttonsimpan";
            buttonsimpan.Size = new Size(75, 27);
            buttonsimpan.TabIndex = 14;
            buttonsimpan.Text = "Simpan";
            buttonsimpan.UseVisualStyleBackColor = true;
            // 
            // buttonkeluar
            // 
            buttonkeluar.Font = new Font("Segoe UI", 10F);
            buttonkeluar.Location = new Point(718, 348);
            buttonkeluar.Name = "buttonkeluar";
            buttonkeluar.Size = new Size(75, 27);
            buttonkeluar.TabIndex = 16;
            buttonkeluar.Text = "Keluar";
            buttonkeluar.UseVisualStyleBackColor = true;
            buttonkeluar.Click += button9_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(255, 128, 128);
            pictureBox3.Location = new Point(-1, 154);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(803, 239);
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // MenuUtama
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 381);
            Controls.Add(buttonkeluar);
            Controls.Add(buttonsimpan);
            Controls.Add(buttonstock);
            Controls.Add(isijumlah);
            Controls.Add(labeljumlah);
            Controls.Add(isikodeproduk);
            Controls.Add(buttonhapus);
            Controls.Add(buttonedit);
            Controls.Add(buttontambah);
            Controls.Add(isitotal);
            Controls.Add(labeltotal);
            Controls.Add(tampildata);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Name = "MenuUtama";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)tampildata).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private PictureBox pictureBox3;
        private Label labeltotal;
        private TextBox isitotal;
        private Button buttontambah;
        private Button buttonedit;
        private Button buttonhapus;
        private TextBox isikodeproduk;
        private Label labeljumlah;
        private TextBox isijumlah;
        private Button buttonstock;
        private Button buttonsimpan;
        private Button buttonkeluar;
        private DataGridView tampildata;
    }
}
