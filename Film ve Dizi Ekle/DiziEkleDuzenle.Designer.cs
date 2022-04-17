namespace Film_ve_Dizi_Ekle
{
    partial class DiziEkleDuzenle
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
            this.cbtur = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnafisbul = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbafis)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbafis
            // 
            this.pbafis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbafis.ContextMenuStrip = this.contextMenuStrip1;
            this.pbafis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbafis.Location = new System.Drawing.Point(12, 12);
            this.pbafis.Name = "pbafis";
            this.pbafis.Size = new System.Drawing.Size(282, 349);
            this.pbafis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbafis.TabIndex = 0;
            this.pbafis.TabStop = false;
            this.pbafis.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Pbafis_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yapıştırToolStripMenuItem,
            this.temizleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 48);
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
            this.btnislem.Location = new System.Drawing.Point(207, 420);
            this.btnislem.Margin = new System.Windows.Forms.Padding(3, 3, 12, 12);
            this.btnislem.Name = "btnislem";
            this.btnislem.Size = new System.Drawing.Size(87, 23);
            this.btnislem.TabIndex = 2;
            this.btnislem.TabStop = false;
            this.btnislem.Text = "button1";
            this.btnislem.UseVisualStyleBackColor = true;
            this.btnislem.Click += new System.EventHandler(this.Btnislem_Click);
            // 
            // txtad
            // 
            this.txtad.Location = new System.Drawing.Point(91, 367);
            this.txtad.Name = "txtad";
            this.txtad.Size = new System.Drawing.Size(203, 20);
            this.txtad.TabIndex = 0;
            this.txtad.TextChanged += new System.EventHandler(this.Duzenle);
            // 
            // cbtur
            // 
            this.cbtur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtur.FormattingEnabled = true;
            this.cbtur.Items.AddRange(new object[] {
            "Yerli",
            "Yabancı"});
            this.cbtur.Location = new System.Drawing.Point(91, 393);
            this.cbtur.Name = "cbtur";
            this.cbtur.Size = new System.Drawing.Size(203, 21);
            this.cbtur.TabIndex = 1;
            this.cbtur.SelectedIndexChanged += new System.EventHandler(this.Duzenle);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Dizi ad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tür";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 14;
            this.button1.TabStop = false;
            this.button1.Text = "Medya Seç";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnafisbul
            // 
            this.btnafisbul.Enabled = false;
            this.btnafisbul.Location = new System.Drawing.Point(22, 420);
            this.btnafisbul.Name = "btnafisbul";
            this.btnafisbul.Size = new System.Drawing.Size(87, 23);
            this.btnafisbul.TabIndex = 15;
            this.btnafisbul.TabStop = false;
            this.btnafisbul.Text = "Afiş Bul";
            this.btnafisbul.UseVisualStyleBackColor = true;
            this.btnafisbul.Click += new System.EventHandler(this.Btnafisbul_Click);
            // 
            // DiziEkleDuzenle
            // 
            this.AcceptButton = this.btnislem;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1174, 507);
            this.Controls.Add(this.btnafisbul);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbtur);
            this.Controls.Add(this.txtad);
            this.Controls.Add(this.btnislem);
            this.Controls.Add(this.pbafis);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DiziEkleDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dizi Ekle";
            this.Load += new System.EventHandler(this.DiziEkleDuzenle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbafis)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbafis;
        private System.Windows.Forms.TextBox txtad;
        public System.Windows.Forms.Button btnislem;
        private System.Windows.Forms.ComboBox cbtur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yapıştırToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temizleToolStripMenuItem;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button btnafisbul;
    }
}