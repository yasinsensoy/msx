namespace Film_ve_Dizi_Ekle
{
    partial class TurGuncelle
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
            this.btnislem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbtur = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnislem
            // 
            this.btnislem.Location = new System.Drawing.Point(99, 39);
            this.btnislem.Margin = new System.Windows.Forms.Padding(3, 3, 12, 12);
            this.btnislem.Name = "btnislem";
            this.btnislem.Size = new System.Drawing.Size(87, 23);
            this.btnislem.TabIndex = 1;
            this.btnislem.TabStop = false;
            this.btnislem.Text = "Güncelle";
            this.btnislem.UseVisualStyleBackColor = true;
            this.btnislem.Click += new System.EventHandler(this.Btnislem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tür";
            // 
            // cbtur
            // 
            this.cbtur.FormattingEnabled = true;
            this.cbtur.Items.AddRange(new object[] {
            "Ulusal",
            "Film",
            "Dizi",
            "Spor",
            "Belgesel",
            "Haber",
            "Müzik"});
            this.cbtur.Location = new System.Drawing.Point(41, 12);
            this.cbtur.Name = "cbtur";
            this.cbtur.Size = new System.Drawing.Size(145, 21);
            this.cbtur.TabIndex = 0;
            // 
            // TurGuncelle
            // 
            this.AcceptButton = this.btnislem;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(234, 103);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbtur);
            this.Controls.Add(this.btnislem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TurGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tür Güncelle";
            this.Load += new System.EventHandler(this.TurGuncelle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnislem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbtur;
    }
}