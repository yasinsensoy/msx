namespace Film_ve_Dizi_Ekle
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.datafilmler = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpfilmler = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnfilmekle = new System.Windows.Forms.Button();
            this.btnfilmduzenle = new System.Windows.Forms.Button();
            this.btnfilmsil = new System.Windows.Forms.Button();
            this.btnfilmcek = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tpdiziler = new System.Windows.Forms.TabPage();
            this.datadiziler = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btndiziekle = new System.Windows.Forms.Button();
            this.btndiziduzenle = new System.Windows.Forms.Button();
            this.btndizisil = new System.Windows.Forms.Button();
            this.btndizicek = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.databolumler = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnbolumekle = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnbolumsil = new System.Windows.Forms.Button();
            this.btnbolumtipduzenle = new System.Windows.Forms.Button();
            this.tpkanallar = new System.Windows.Forms.TabPage();
            this.datakanallar = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnkanalekle = new System.Windows.Forms.Button();
            this.btnkanalduzenle = new System.Windows.Forms.Button();
            this.btnkanalsil = new System.Windows.Forms.Button();
            this.btnkanalturdegis = new System.Windows.Forms.Button();
            this.btnkanallisteekle = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datafilmler)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpfilmler.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tpdiziler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datadiziler)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databolumler)).BeginInit();
            this.flowLayoutPanel5.SuspendLayout();
            this.tpkanallar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datakanallar)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // datafilmler
            // 
            this.datafilmler.AllowUserToAddRows = false;
            this.datafilmler.AllowUserToDeleteRows = false;
            this.datafilmler.AllowUserToResizeRows = false;
            this.datafilmler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datafilmler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datafilmler.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datafilmler.Location = new System.Drawing.Point(3, 45);
            this.datafilmler.Name = "datafilmler";
            this.datafilmler.RowHeadersVisible = false;
            this.datafilmler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datafilmler.Size = new System.Drawing.Size(665, 483);
            this.datafilmler.TabIndex = 0;
            this.datafilmler.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Datafilmler_DataBindingComplete);
            this.datafilmler.SelectionChanged += new System.EventHandler(this.Datafilmler_SelectionChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpfilmler);
            this.tabControl1.Controls.Add(this.tpdiziler);
            this.tabControl1.Controls.Add(this.tpkanallar);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1179, 557);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl1_Selecting);
            // 
            // tpfilmler
            // 
            this.tpfilmler.Controls.Add(this.datafilmler);
            this.tpfilmler.Controls.Add(this.panel1);
            this.tpfilmler.Controls.Add(this.flowLayoutPanel1);
            this.tpfilmler.Location = new System.Drawing.Point(4, 22);
            this.tpfilmler.Name = "tpfilmler";
            this.tpfilmler.Padding = new System.Windows.Forms.Padding(3);
            this.tpfilmler.Size = new System.Drawing.Size(1171, 531);
            this.tpfilmler.TabIndex = 0;
            this.tpfilmler.Text = "Filmler";
            this.tpfilmler.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(668, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 483);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 460);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.MaximumSize = new System.Drawing.Size(358, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 23);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnfilmekle);
            this.flowLayoutPanel1.Controls.Add(this.btnfilmduzenle);
            this.flowLayoutPanel1.Controls.Add(this.btnfilmsil);
            this.flowLayoutPanel1.Controls.Add(this.btnfilmcek);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1165, 42);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnfilmekle
            // 
            this.btnfilmekle.AutoSize = true;
            this.btnfilmekle.BackColor = System.Drawing.Color.DarkGreen;
            this.btnfilmekle.FlatAppearance.BorderSize = 0;
            this.btnfilmekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfilmekle.ForeColor = System.Drawing.Color.White;
            this.btnfilmekle.Location = new System.Drawing.Point(0, 3);
            this.btnfilmekle.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnfilmekle.Name = "btnfilmekle";
            this.btnfilmekle.Size = new System.Drawing.Size(80, 36);
            this.btnfilmekle.TabIndex = 0;
            this.btnfilmekle.Text = "Ekle";
            this.btnfilmekle.UseVisualStyleBackColor = false;
            this.btnfilmekle.Click += new System.EventHandler(this.Btnfilmekle_Click);
            // 
            // btnfilmduzenle
            // 
            this.btnfilmduzenle.AutoSize = true;
            this.btnfilmduzenle.BackColor = System.Drawing.Color.OrangeRed;
            this.btnfilmduzenle.Enabled = false;
            this.btnfilmduzenle.FlatAppearance.BorderSize = 0;
            this.btnfilmduzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfilmduzenle.ForeColor = System.Drawing.Color.White;
            this.btnfilmduzenle.Location = new System.Drawing.Point(83, 3);
            this.btnfilmduzenle.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnfilmduzenle.Name = "btnfilmduzenle";
            this.btnfilmduzenle.Size = new System.Drawing.Size(80, 36);
            this.btnfilmduzenle.TabIndex = 1;
            this.btnfilmduzenle.Text = "Düzenle";
            this.btnfilmduzenle.UseVisualStyleBackColor = false;
            this.btnfilmduzenle.Click += new System.EventHandler(this.Btnfilmduzenle_Click);
            // 
            // btnfilmsil
            // 
            this.btnfilmsil.AutoSize = true;
            this.btnfilmsil.BackColor = System.Drawing.Color.DarkRed;
            this.btnfilmsil.Enabled = false;
            this.btnfilmsil.FlatAppearance.BorderSize = 0;
            this.btnfilmsil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfilmsil.ForeColor = System.Drawing.Color.White;
            this.btnfilmsil.Location = new System.Drawing.Point(166, 3);
            this.btnfilmsil.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnfilmsil.Name = "btnfilmsil";
            this.btnfilmsil.Size = new System.Drawing.Size(80, 36);
            this.btnfilmsil.TabIndex = 2;
            this.btnfilmsil.Text = "Sil";
            this.btnfilmsil.UseVisualStyleBackColor = false;
            this.btnfilmsil.Click += new System.EventHandler(this.Btnfilmsil_Click);
            // 
            // btnfilmcek
            // 
            this.btnfilmcek.AutoSize = true;
            this.btnfilmcek.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnfilmcek.FlatAppearance.BorderSize = 0;
            this.btnfilmcek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfilmcek.ForeColor = System.Drawing.Color.White;
            this.btnfilmcek.Location = new System.Drawing.Point(249, 3);
            this.btnfilmcek.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnfilmcek.Name = "btnfilmcek";
            this.btnfilmcek.Size = new System.Drawing.Size(100, 36);
            this.btnfilmcek.TabIndex = 5;
            this.btnfilmcek.Text = "Filmleri Çek";
            this.btnfilmcek.UseVisualStyleBackColor = false;
            this.btnfilmcek.Click += new System.EventHandler(this.Btnfilmcek_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(352, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "filmmodu Filmleri Çek";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(472, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(513, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tpdiziler
            // 
            this.tpdiziler.Controls.Add(this.datadiziler);
            this.tpdiziler.Controls.Add(this.flowLayoutPanel3);
            this.tpdiziler.Controls.Add(this.panel2);
            this.tpdiziler.Location = new System.Drawing.Point(4, 22);
            this.tpdiziler.Name = "tpdiziler";
            this.tpdiziler.Padding = new System.Windows.Forms.Padding(3);
            this.tpdiziler.Size = new System.Drawing.Size(1171, 531);
            this.tpdiziler.TabIndex = 1;
            this.tpdiziler.Text = "Diziler";
            this.tpdiziler.UseVisualStyleBackColor = true;
            // 
            // datadiziler
            // 
            this.datadiziler.AllowUserToAddRows = false;
            this.datadiziler.AllowUserToDeleteRows = false;
            this.datadiziler.AllowUserToResizeRows = false;
            this.datadiziler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datadiziler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datadiziler.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datadiziler.Location = new System.Drawing.Point(3, 45);
            this.datadiziler.Name = "datadiziler";
            this.datadiziler.RowHeadersVisible = false;
            this.datadiziler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datadiziler.Size = new System.Drawing.Size(930, 483);
            this.datadiziler.TabIndex = 2;
            this.datadiziler.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Datadiziler_DataBindingComplete);
            this.datadiziler.SelectionChanged += new System.EventHandler(this.Datadiziler_SelectionChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.btndiziekle);
            this.flowLayoutPanel3.Controls.Add(this.btndiziduzenle);
            this.flowLayoutPanel3.Controls.Add(this.btndizisil);
            this.flowLayoutPanel3.Controls.Add(this.btndizicek);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(930, 42);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // btndiziekle
            // 
            this.btndiziekle.AutoSize = true;
            this.btndiziekle.BackColor = System.Drawing.Color.DarkGreen;
            this.btndiziekle.FlatAppearance.BorderSize = 0;
            this.btndiziekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndiziekle.ForeColor = System.Drawing.Color.White;
            this.btndiziekle.Location = new System.Drawing.Point(0, 3);
            this.btndiziekle.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btndiziekle.Name = "btndiziekle";
            this.btndiziekle.Size = new System.Drawing.Size(80, 36);
            this.btndiziekle.TabIndex = 0;
            this.btndiziekle.Text = "Ekle";
            this.btndiziekle.UseVisualStyleBackColor = false;
            this.btndiziekle.Click += new System.EventHandler(this.Btndiziekle_Click);
            // 
            // btndiziduzenle
            // 
            this.btndiziduzenle.AutoSize = true;
            this.btndiziduzenle.BackColor = System.Drawing.Color.OrangeRed;
            this.btndiziduzenle.Enabled = false;
            this.btndiziduzenle.FlatAppearance.BorderSize = 0;
            this.btndiziduzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndiziduzenle.ForeColor = System.Drawing.Color.White;
            this.btndiziduzenle.Location = new System.Drawing.Point(83, 3);
            this.btndiziduzenle.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btndiziduzenle.Name = "btndiziduzenle";
            this.btndiziduzenle.Size = new System.Drawing.Size(80, 36);
            this.btndiziduzenle.TabIndex = 1;
            this.btndiziduzenle.Text = "Düzenle";
            this.btndiziduzenle.UseVisualStyleBackColor = false;
            this.btndiziduzenle.Click += new System.EventHandler(this.Btndiziduzenle_Click);
            // 
            // btndizisil
            // 
            this.btndizisil.AutoSize = true;
            this.btndizisil.BackColor = System.Drawing.Color.DarkRed;
            this.btndizisil.Enabled = false;
            this.btndizisil.FlatAppearance.BorderSize = 0;
            this.btndizisil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndizisil.ForeColor = System.Drawing.Color.White;
            this.btndizisil.Location = new System.Drawing.Point(166, 3);
            this.btndizisil.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btndizisil.Name = "btndizisil";
            this.btndizisil.Size = new System.Drawing.Size(80, 36);
            this.btndizisil.TabIndex = 2;
            this.btndizisil.Text = "Sil";
            this.btndizisil.UseVisualStyleBackColor = false;
            this.btndizisil.Click += new System.EventHandler(this.Btndizisil_Click);
            // 
            // btndizicek
            // 
            this.btndizicek.AutoSize = true;
            this.btndizicek.BackColor = System.Drawing.Color.RoyalBlue;
            this.btndizicek.FlatAppearance.BorderSize = 0;
            this.btndizicek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndizicek.ForeColor = System.Drawing.Color.White;
            this.btndizicek.Location = new System.Drawing.Point(249, 3);
            this.btndizicek.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btndizicek.Name = "btndizicek";
            this.btndizicek.Size = new System.Drawing.Size(100, 36);
            this.btndizicek.TabIndex = 6;
            this.btndizicek.Text = "Dizileri Çek";
            this.btndizicek.UseVisualStyleBackColor = false;
            this.btndizicek.Click += new System.EventHandler(this.Btndizicek_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.databolumler);
            this.panel2.Controls.Add(this.flowLayoutPanel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(933, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 525);
            this.panel2.TabIndex = 5;
            // 
            // databolumler
            // 
            this.databolumler.AllowUserToAddRows = false;
            this.databolumler.AllowUserToDeleteRows = false;
            this.databolumler.AllowUserToResizeRows = false;
            this.databolumler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.databolumler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.databolumler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databolumler.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.databolumler.Location = new System.Drawing.Point(0, 42);
            this.databolumler.Name = "databolumler";
            this.databolumler.RowHeadersVisible = false;
            this.databolumler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.databolumler.Size = new System.Drawing.Size(235, 483);
            this.databolumler.TabIndex = 2;
            this.databolumler.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Databolumler_DataBindingComplete);
            this.databolumler.SelectionChanged += new System.EventHandler(this.Databolumler_SelectionChanged);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel5.Controls.Add(this.btnbolumekle);
            this.flowLayoutPanel5.Controls.Add(this.button3);
            this.flowLayoutPanel5.Controls.Add(this.btnbolumsil);
            this.flowLayoutPanel5.Controls.Add(this.btnbolumtipduzenle);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(235, 42);
            this.flowLayoutPanel5.TabIndex = 3;
            // 
            // btnbolumekle
            // 
            this.btnbolumekle.AutoSize = true;
            this.btnbolumekle.BackColor = System.Drawing.Color.DarkGreen;
            this.btnbolumekle.Enabled = false;
            this.btnbolumekle.FlatAppearance.BorderSize = 0;
            this.btnbolumekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbolumekle.ForeColor = System.Drawing.Color.White;
            this.btnbolumekle.Location = new System.Drawing.Point(0, 3);
            this.btnbolumekle.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnbolumekle.Name = "btnbolumekle";
            this.btnbolumekle.Size = new System.Drawing.Size(38, 36);
            this.btnbolumekle.TabIndex = 0;
            this.btnbolumekle.Text = "Ekle";
            this.btnbolumekle.UseVisualStyleBackColor = false;
            this.btnbolumekle.Click += new System.EventHandler(this.Btnbolumekle_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.BackColor = System.Drawing.Color.OrangeRed;
            this.button3.Enabled = false;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(41, 3);
            this.button3.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 36);
            this.button3.TabIndex = 4;
            this.button3.Text = "Düzenle";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnbolumsil
            // 
            this.btnbolumsil.AutoSize = true;
            this.btnbolumsil.BackColor = System.Drawing.Color.DarkRed;
            this.btnbolumsil.Enabled = false;
            this.btnbolumsil.FlatAppearance.BorderSize = 0;
            this.btnbolumsil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbolumsil.ForeColor = System.Drawing.Color.White;
            this.btnbolumsil.Location = new System.Drawing.Point(100, 3);
            this.btnbolumsil.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnbolumsil.Name = "btnbolumsil";
            this.btnbolumsil.Size = new System.Drawing.Size(28, 36);
            this.btnbolumsil.TabIndex = 2;
            this.btnbolumsil.Text = "Sil";
            this.btnbolumsil.UseVisualStyleBackColor = false;
            this.btnbolumsil.Click += new System.EventHandler(this.Btnbolumsil_Click);
            // 
            // btnbolumtipduzenle
            // 
            this.btnbolumtipduzenle.AutoSize = true;
            this.btnbolumtipduzenle.BackColor = System.Drawing.Color.OrangeRed;
            this.btnbolumtipduzenle.Enabled = false;
            this.btnbolumtipduzenle.FlatAppearance.BorderSize = 0;
            this.btnbolumtipduzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbolumtipduzenle.ForeColor = System.Drawing.Color.White;
            this.btnbolumtipduzenle.Location = new System.Drawing.Point(131, 3);
            this.btnbolumtipduzenle.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnbolumtipduzenle.Name = "btnbolumtipduzenle";
            this.btnbolumtipduzenle.Size = new System.Drawing.Size(74, 36);
            this.btnbolumtipduzenle.TabIndex = 3;
            this.btnbolumtipduzenle.Text = "Tip Düzenle";
            this.btnbolumtipduzenle.UseVisualStyleBackColor = false;
            this.btnbolumtipduzenle.Click += new System.EventHandler(this.btnbolumtipduzenle_Click);
            // 
            // tpkanallar
            // 
            this.tpkanallar.Controls.Add(this.datakanallar);
            this.tpkanallar.Controls.Add(this.flowLayoutPanel2);
            this.tpkanallar.Location = new System.Drawing.Point(4, 22);
            this.tpkanallar.Name = "tpkanallar";
            this.tpkanallar.Padding = new System.Windows.Forms.Padding(3);
            this.tpkanallar.Size = new System.Drawing.Size(1171, 531);
            this.tpkanallar.TabIndex = 2;
            this.tpkanallar.Text = "Kanallar";
            this.tpkanallar.UseVisualStyleBackColor = true;
            // 
            // datakanallar
            // 
            this.datakanallar.AllowUserToAddRows = false;
            this.datakanallar.AllowUserToDeleteRows = false;
            this.datakanallar.AllowUserToResizeRows = false;
            this.datakanallar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datakanallar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datakanallar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.datakanallar.Location = new System.Drawing.Point(3, 45);
            this.datakanallar.Name = "datakanallar";
            this.datakanallar.RowHeadersVisible = false;
            this.datakanallar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datakanallar.Size = new System.Drawing.Size(1165, 483);
            this.datakanallar.TabIndex = 2;
            this.datakanallar.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Datakanallar_DataBindingComplete);
            this.datakanallar.SelectionChanged += new System.EventHandler(this.Datakanallar_SelectionChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.btnkanalekle);
            this.flowLayoutPanel2.Controls.Add(this.btnkanalduzenle);
            this.flowLayoutPanel2.Controls.Add(this.btnkanalsil);
            this.flowLayoutPanel2.Controls.Add(this.btnkanalturdegis);
            this.flowLayoutPanel2.Controls.Add(this.button4);
            this.flowLayoutPanel2.Controls.Add(this.btnkanallisteekle);
            this.flowLayoutPanel2.Controls.Add(this.comboBox1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1165, 42);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btnkanalekle
            // 
            this.btnkanalekle.AutoSize = true;
            this.btnkanalekle.BackColor = System.Drawing.Color.DarkGreen;
            this.btnkanalekle.FlatAppearance.BorderSize = 0;
            this.btnkanalekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkanalekle.ForeColor = System.Drawing.Color.White;
            this.btnkanalekle.Location = new System.Drawing.Point(0, 3);
            this.btnkanalekle.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnkanalekle.Name = "btnkanalekle";
            this.btnkanalekle.Size = new System.Drawing.Size(80, 36);
            this.btnkanalekle.TabIndex = 0;
            this.btnkanalekle.Text = "Ekle";
            this.btnkanalekle.UseVisualStyleBackColor = false;
            this.btnkanalekle.Click += new System.EventHandler(this.Btnkanalekle_Click);
            // 
            // btnkanalduzenle
            // 
            this.btnkanalduzenle.AutoSize = true;
            this.btnkanalduzenle.BackColor = System.Drawing.Color.OrangeRed;
            this.btnkanalduzenle.Enabled = false;
            this.btnkanalduzenle.FlatAppearance.BorderSize = 0;
            this.btnkanalduzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkanalduzenle.ForeColor = System.Drawing.Color.White;
            this.btnkanalduzenle.Location = new System.Drawing.Point(83, 3);
            this.btnkanalduzenle.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnkanalduzenle.Name = "btnkanalduzenle";
            this.btnkanalduzenle.Size = new System.Drawing.Size(80, 36);
            this.btnkanalduzenle.TabIndex = 1;
            this.btnkanalduzenle.Text = "Düzenle";
            this.btnkanalduzenle.UseVisualStyleBackColor = false;
            this.btnkanalduzenle.Click += new System.EventHandler(this.Btnkanalduzenle_Click);
            // 
            // btnkanalsil
            // 
            this.btnkanalsil.AutoSize = true;
            this.btnkanalsil.BackColor = System.Drawing.Color.DarkRed;
            this.btnkanalsil.Enabled = false;
            this.btnkanalsil.FlatAppearance.BorderSize = 0;
            this.btnkanalsil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkanalsil.ForeColor = System.Drawing.Color.White;
            this.btnkanalsil.Location = new System.Drawing.Point(166, 3);
            this.btnkanalsil.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnkanalsil.Name = "btnkanalsil";
            this.btnkanalsil.Size = new System.Drawing.Size(80, 36);
            this.btnkanalsil.TabIndex = 2;
            this.btnkanalsil.Text = "Sil";
            this.btnkanalsil.UseVisualStyleBackColor = false;
            this.btnkanalsil.Click += new System.EventHandler(this.Btnkanalsil_Click);
            // 
            // btnkanalturdegis
            // 
            this.btnkanalturdegis.AutoSize = true;
            this.btnkanalturdegis.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnkanalturdegis.Enabled = false;
            this.btnkanalturdegis.FlatAppearance.BorderSize = 0;
            this.btnkanalturdegis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkanalturdegis.ForeColor = System.Drawing.Color.White;
            this.btnkanalturdegis.Location = new System.Drawing.Point(249, 3);
            this.btnkanalturdegis.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnkanalturdegis.Name = "btnkanalturdegis";
            this.btnkanalturdegis.Size = new System.Drawing.Size(71, 36);
            this.btnkanalturdegis.TabIndex = 3;
            this.btnkanalturdegis.Text = "Tür Değiştir";
            this.btnkanalturdegis.UseVisualStyleBackColor = false;
            this.btnkanalturdegis.Click += new System.EventHandler(this.Btnkanalturdegis_Click);
            // 
            // btnkanallisteekle
            // 
            this.btnkanallisteekle.AutoSize = true;
            this.btnkanallisteekle.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnkanallisteekle.FlatAppearance.BorderSize = 0;
            this.btnkanallisteekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkanallisteekle.ForeColor = System.Drawing.Color.White;
            this.btnkanallisteekle.Location = new System.Drawing.Point(376, 3);
            this.btnkanallisteekle.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnkanallisteekle.Name = "btnkanallisteekle";
            this.btnkanallisteekle.Size = new System.Drawing.Size(100, 36);
            this.btnkanallisteekle.TabIndex = 4;
            this.btnkanallisteekle.Text = "Kanal Listesi Ekle";
            this.btnkanallisteekle.UseVisualStyleBackColor = false;
            this.btnkanallisteekle.Click += new System.EventHandler(this.Btnkanallisteekle_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(482, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(678, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.BackColor = System.Drawing.Color.RoyalBlue;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(323, 3);
            this.button4.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 36);
            this.button4.TabIndex = 6;
            this.button4.Text = "Oluştur";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1179, 557);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Film ve Dizi Ekle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datafilmler)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpfilmler.ResumeLayout(false);
            this.tpfilmler.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tpdiziler.ResumeLayout(false);
            this.tpdiziler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datadiziler)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databolumler)).EndInit();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.tpkanallar.ResumeLayout(false);
            this.tpkanallar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datakanallar)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datafilmler;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpfilmler;
        private System.Windows.Forms.TabPage tpdiziler;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnfilmekle;
        private System.Windows.Forms.Button btnfilmduzenle;
        private System.Windows.Forms.Button btnfilmsil;
        private System.Windows.Forms.DataGridView datadiziler;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btndiziekle;
        private System.Windows.Forms.Button btndiziduzenle;
        private System.Windows.Forms.Button btndizisil;
        private System.Windows.Forms.TabPage tpkanallar;
        private System.Windows.Forms.DataGridView datakanallar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnkanalekle;
        private System.Windows.Forms.Button btnkanalduzenle;
        private System.Windows.Forms.Button btnkanalsil;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView databolumler;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Button btnbolumekle;
        private System.Windows.Forms.Button btnbolumsil;
        private System.Windows.Forms.Button btnkanalturdegis;
        private System.Windows.Forms.Button btnkanallisteekle;
        private System.Windows.Forms.Button btnfilmcek;
        private System.Windows.Forms.Button btndizicek;
        private System.Windows.Forms.Button btnbolumtipduzenle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button4;
    }
}

