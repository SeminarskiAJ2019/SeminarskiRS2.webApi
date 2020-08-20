namespace SeminarskiRS2.WinUI.Stadioni
{
    partial class frmStadioni
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
            this.cbGradovi = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvStadioni = new System.Windows.Forms.DataGridView();
            this.StadionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlikaThumb = new System.Windows.Forms.DataGridViewImageColumn();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slika = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStadioni)).BeginInit();
            this.SuspendLayout();
            // 
            // cbGradovi
            // 
            this.cbGradovi.FormattingEnabled = true;
            this.cbGradovi.Location = new System.Drawing.Point(15, 52);
            this.cbGradovi.Name = "cbGradovi";
            this.cbGradovi.Size = new System.Drawing.Size(279, 21);
            this.cbGradovi.TabIndex = 0;
            this.cbGradovi.SelectedIndexChanged += new System.EventHandler(this.cbGradovi_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvStadioni);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 320);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stadioni";
            // 
            // dgvStadioni
            // 
            this.dgvStadioni.AllowUserToAddRows = false;
            this.dgvStadioni.AllowUserToDeleteRows = false;
            this.dgvStadioni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStadioni.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StadionID,
            this.Naziv,
            this.Opis,
            this.SlikaThumb,
            this.Grad,
            this.GradID,
            this.Slika});
            this.dgvStadioni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStadioni.Location = new System.Drawing.Point(3, 16);
            this.dgvStadioni.Name = "dgvStadioni";
            this.dgvStadioni.ReadOnly = true;
            this.dgvStadioni.Size = new System.Drawing.Size(748, 301);
            this.dgvStadioni.TabIndex = 0;
            this.dgvStadioni.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvStadioni_MouseDoubleClick);
            // 
            // StadionID
            // 
            this.StadionID.DataPropertyName = "StadionID";
            this.StadionID.HeaderText = "StadionID";
            this.StadionID.Name = "StadionID";
            this.StadionID.ReadOnly = true;
            this.StadionID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv stadiona";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            this.Naziv.Width = 150;
            // 
            // Opis
            // 
            this.Opis.DataPropertyName = "Opis";
            this.Opis.HeaderText = "Opis";
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            this.Opis.Width = 150;
            // 
            // SlikaThumb
            // 
            this.SlikaThumb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SlikaThumb.DataPropertyName = "SlikaThumb";
            this.SlikaThumb.HeaderText = "Slika";
            this.SlikaThumb.Name = "SlikaThumb";
            this.SlikaThumb.ReadOnly = true;
            // 
            // Grad
            // 
            this.Grad.DataPropertyName = "Grad";
            this.Grad.HeaderText = "Naziv grada";
            this.Grad.Name = "Grad";
            this.Grad.ReadOnly = true;
            this.Grad.Width = 150;
            // 
            // GradID
            // 
            this.GradID.DataPropertyName = "GradID";
            this.GradID.HeaderText = "GradID";
            this.GradID.Name = "GradID";
            this.GradID.ReadOnly = true;
            this.GradID.Visible = false;
            // 
            // Slika
            // 
            this.Slika.DataPropertyName = "Slika";
            this.Slika.HeaderText = "Slika";
            this.Slika.Name = "Slika";
            this.Slika.ReadOnly = true;
            this.Slika.Visible = false;
            // 
            // frmStadioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 432);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbGradovi);
            this.Name = "frmStadioni";
            this.Text = "frmStadioni";
            this.Load += new System.EventHandler(this.frmStadioni_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStadioni)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbGradovi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvStadioni;
        private System.Windows.Forms.DataGridViewTextBoxColumn StadionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.DataGridViewImageColumn SlikaThumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grad;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradID;
        private System.Windows.Forms.DataGridViewImageColumn Slika;
    }
}