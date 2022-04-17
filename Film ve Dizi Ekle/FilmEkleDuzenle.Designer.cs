namespace Film_ve_Dizi_Ekle
{
    partial class FilmEkleDuzenle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbafis = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yapıştırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnislem = new System.Windows.Forms.Button();
            this.txtad = new System.Windows.Forms.TextBox();
            this.txtvideo = new System.Windows.Forms.TextBox();
            this.cbtur = new System.Windows.Forms.ComboBox();
            this.cbdil = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnafisbul = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtturler = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtyil = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtorjad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtfragman = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtozet = new System.Windows.Forms.RichTextBox();
            this.btnbobul = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.nudimdb = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtoyuncular = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtyonetmenler = new System.Windows.Forms.TextBox();
            this.pbcover = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbafis)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudimdb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcover)).BeginInit();
            this.SuspendLayout();
            // 
            // pbafis
            // 
            this.pbafis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbafis.ContextMenuStrip = this.contextMenuStrip1;
            this.pbafis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbafis.Location = new System.Drawing.Point(12, 12);
            this.pbafis.Margin = new System.Windows.Forms.Padding(3, 3, 3, 12);
            this.pbafis.Name = "pbafis";
            this.pbafis.Size = new System.Drawing.Size(272, 385);
            this.pbafis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbafis.TabIndex = 0;
            this.pbafis.TabStop = false;
            this.pbafis.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yapıştırToolStripMenuItem,
            this.temizleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // yapıştırToolStripMenuItem
            // 
            this.yapıştırToolStripMenuItem.Name = "yapıştırToolStripMenuItem";
            this.yapıştırToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.yapıştırToolStripMenuItem.Text = "Yapıştır";
            this.yapıştırToolStripMenuItem.Click += new System.EventHandler(this.YapıştırToolStripMenuItem_Click);
            // 
            // temizleToolStripMenuItem
            // 
            this.temizleToolStripMenuItem.Name = "temizleToolStripMenuItem";
            this.temizleToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.temizleToolStripMenuItem.Text = "Temizle";
            this.temizleToolStripMenuItem.Click += new System.EventHandler(this.TemizleToolStripMenuItem_Click);
            // 
            // btnislem
            // 
            this.btnislem.Location = new System.Drawing.Point(573, 374);
            this.btnislem.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.btnislem.Name = "btnislem";
            this.btnislem.Size = new System.Drawing.Size(57, 23);
            this.btnislem.TabIndex = 5;
            this.btnislem.TabStop = false;
            this.btnislem.Text = "Düzenle";
            this.btnislem.UseVisualStyleBackColor = true;
            this.btnislem.Click += new System.EventHandler(this.Btnislem_Click);
            // 
            // txtad
            // 
            this.txtad.Location = new System.Drawing.Point(358, 12);
            this.txtad.Name = "txtad";
            this.txtad.Size = new System.Drawing.Size(272, 20);
            this.txtad.TabIndex = 0;
            this.txtad.TextChanged += new System.EventHandler(this.Duzenle);
            // 
            // txtvideo
            // 
            this.txtvideo.Location = new System.Drawing.Point(358, 64);
            this.txtvideo.Name = "txtvideo";
            this.txtvideo.Size = new System.Drawing.Size(272, 20);
            this.txtvideo.TabIndex = 1;
            this.txtvideo.TextChanged += new System.EventHandler(this.Duzenle);
            // 
            // cbtur
            // 
            this.cbtur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtur.FormattingEnabled = true;
            this.cbtur.Items.AddRange(new object[] {
            "Yerli",
            "Yabancı"});
            this.cbtur.Location = new System.Drawing.Point(358, 347);
            this.cbtur.Name = "cbtur";
            this.cbtur.Size = new System.Drawing.Size(126, 21);
            this.cbtur.TabIndex = 2;
            this.cbtur.SelectedIndexChanged += new System.EventHandler(this.Duzenle);
            // 
            // cbdil
            // 
            this.cbdil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbdil.FormattingEnabled = true;
            this.cbdil.Items.AddRange(new object[] {
            "Türkçe",
            "Dublaj",
            "Altyazı"});
            this.cbdil.Location = new System.Drawing.Point(526, 347);
            this.cbdil.Name = "cbdil";
            this.cbdil.Size = new System.Drawing.Size(104, 21);
            this.cbdil.TabIndex = 3;
            this.cbdil.SelectedIndexChanged += new System.EventHandler(this.Duzenle);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Film ad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Video adres";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tür";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(490, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Dil";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(493, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 23);
            this.button1.TabIndex = 13;
            this.button1.TabStop = false;
            this.button1.Text = "Medya Seç";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnafisbul
            // 
            this.btnafisbul.Enabled = false;
            this.btnafisbul.Location = new System.Drawing.Point(438, 374);
            this.btnafisbul.Name = "btnafisbul";
            this.btnafisbul.Size = new System.Drawing.Size(49, 23);
            this.btnafisbul.TabIndex = 14;
            this.btnafisbul.TabStop = false;
            this.btnafisbul.Text = "TMDB";
            this.btnafisbul.UseVisualStyleBackColor = true;
            this.btnafisbul.Click += new System.EventHandler(this.Btnafisbul_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Türler";
            // 
            // txtturler
            // 
            this.txtturler.Location = new System.Drawing.Point(358, 90);
            this.txtturler.Name = "txtturler";
            this.txtturler.Size = new System.Drawing.Size(272, 20);
            this.txtturler.TabIndex = 15;
            this.txtturler.TextChanged += new System.EventHandler(this.Duzenle);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Yıl";
            // 
            // txtyil
            // 
            this.txtyil.Location = new System.Drawing.Point(358, 168);
            this.txtyil.Name = "txtyil";
            this.txtyil.Size = new System.Drawing.Size(126, 20);
            this.txtyil.TabIndex = 17;
            this.txtyil.TextChanged += new System.EventHandler(this.Duzenle);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(286, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Özet";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(286, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Orjinal Ad";
            // 
            // txtorjad
            // 
            this.txtorjad.Location = new System.Drawing.Point(358, 38);
            this.txtorjad.Name = "txtorjad";
            this.txtorjad.Size = new System.Drawing.Size(272, 20);
            this.txtorjad.TabIndex = 21;
            this.txtorjad.TextChanged += new System.EventHandler(this.Duzenle);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(286, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Fragman";
            // 
            // txtfragman
            // 
            this.txtfragman.Location = new System.Drawing.Point(358, 194);
            this.txtfragman.Name = "txtfragman";
            this.txtfragman.Size = new System.Drawing.Size(188, 20);
            this.txtfragman.TabIndex = 23;
            this.txtfragman.TextChanged += new System.EventHandler(this.Duzenle);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(594, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 20);
            this.button2.TabIndex = 25;
            this.button2.TabStop = false;
            this.button2.Text = "Bul";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Location = new System.Drawing.Point(552, 194);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 20);
            this.button3.TabIndex = 26;
            this.button3.TabStop = false;
            this.button3.Text = "Aç";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtozet
            // 
            this.txtozet.Location = new System.Drawing.Point(358, 220);
            this.txtozet.Name = "txtozet";
            this.txtozet.Size = new System.Drawing.Size(272, 121);
            this.txtozet.TabIndex = 27;
            this.txtozet.Text = "";
            this.txtozet.TextChanged += new System.EventHandler(this.Duzenle);
            // 
            // btnbobul
            // 
            this.btnbobul.Enabled = false;
            this.btnbobul.Location = new System.Drawing.Point(358, 374);
            this.btnbobul.Name = "btnbobul";
            this.btnbobul.Size = new System.Drawing.Size(74, 23);
            this.btnbobul.TabIndex = 28;
            this.btnbobul.TabStop = false;
            this.btnbobul.Text = "Box Office";
            this.btnbobul.UseVisualStyleBackColor = true;
            this.btnbobul.Click += new System.EventHandler(this.btnbobul_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(490, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Imdb";
            // 
            // nudimdb
            // 
            this.nudimdb.DecimalPlaces = 1;
            this.nudimdb.Location = new System.Drawing.Point(526, 168);
            this.nudimdb.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudimdb.Name = "nudimdb";
            this.nudimdb.Size = new System.Drawing.Size(104, 20);
            this.nudimdb.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(286, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Oyuncular";
            // 
            // txtoyuncular
            // 
            this.txtoyuncular.Location = new System.Drawing.Point(358, 116);
            this.txtoyuncular.Name = "txtoyuncular";
            this.txtoyuncular.Size = new System.Drawing.Size(272, 20);
            this.txtoyuncular.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(286, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Yönetmenler";
            // 
            // txtyonetmenler
            // 
            this.txtyonetmenler.Location = new System.Drawing.Point(358, 142);
            this.txtyonetmenler.Name = "txtyonetmenler";
            this.txtyonetmenler.Size = new System.Drawing.Size(272, 20);
            this.txtyonetmenler.TabIndex = 34;
            // 
            // pbcover
            // 
            this.pbcover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbcover.ContextMenuStrip = this.contextMenuStrip1;
            this.pbcover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbcover.Location = new System.Drawing.Point(636, 12);
            this.pbcover.Name = "pbcover";
            this.pbcover.Size = new System.Drawing.Size(459, 385);
            this.pbcover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcover.TabIndex = 36;
            this.pbcover.TabStop = false;
            this.pbcover.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb_MouseClick);
            // 
            // FilmEkleDuzenle
            // 
            this.AcceptButton = this.btnislem;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1118, 431);
            this.Controls.Add(this.pbcover);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtyonetmenler);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtoyuncular);
            this.Controls.Add(this.nudimdb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnbobul);
            this.Controls.Add(this.txtozet);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtfragman);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtorjad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtyil);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtturler);
            this.Controls.Add(this.btnafisbul);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbdil);
            this.Controls.Add(this.cbtur);
            this.Controls.Add(this.txtvideo);
            this.Controls.Add(this.txtad);
            this.Controls.Add(this.btnislem);
            this.Controls.Add(this.pbafis);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FilmEkleDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Film Ekle";
            this.Load += new System.EventHandler(this.FilmEkleDuzenle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbafis)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudimdb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbafis;
        private System.Windows.Forms.TextBox txtad;
        private System.Windows.Forms.TextBox txtvideo;
        public System.Windows.Forms.Button btnislem;
        private System.Windows.Forms.ComboBox cbtur;
        private System.Windows.Forms.ComboBox cbdil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yapıştırToolStripMenuItem;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem temizleToolStripMenuItem;
        public System.Windows.Forms.Button btnafisbul;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtturler;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtyil;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtorjad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtfragman;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox txtozet;
        public System.Windows.Forms.Button btnbobul;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudimdb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtoyuncular;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtyonetmenler;
        private System.Windows.Forms.PictureBox pbcover;
    }
}