namespace Film_ve_Dizi_Ekle
{
    partial class BolumTipDuzenle
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
            this.cbtip = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnislem
            // 
            this.btnislem.Location = new System.Drawing.Point(161, 39);
            this.btnislem.Margin = new System.Windows.Forms.Padding(3, 3, 12, 12);
            this.btnislem.Name = "btnislem";
            this.btnislem.Size = new System.Drawing.Size(60, 23);
            this.btnislem.TabIndex = 3;
            this.btnislem.TabStop = false;
            this.btnislem.Text = "Düzenle";
            this.btnislem.UseVisualStyleBackColor = true;
            this.btnislem.Click += new System.EventHandler(this.Btnislem_Click);
            // 
            // cbtip
            // 
            this.cbtip.DisplayMember = "key";
            this.cbtip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtip.FormattingEnabled = true;
            this.cbtip.Location = new System.Drawing.Point(74, 12);
            this.cbtip.Name = "cbtip";
            this.cbtip.Size = new System.Drawing.Size(147, 21);
            this.cbtip.TabIndex = 4;
            this.cbtip.ValueMember = "value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bölüm Tipi";
            // 
            // BolumTipDuzenle
            // 
            this.AcceptButton = this.btnislem;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(235, 67);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbtip);
            this.Controls.Add(this.btnislem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BolumTipDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bölüm Tip Düzenle";
            this.Load += new System.EventHandler(this.BolumTipDuzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnislem;
        private System.Windows.Forms.ComboBox cbtip;
        private System.Windows.Forms.Label label1;
    }
}