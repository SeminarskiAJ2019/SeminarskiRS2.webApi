namespace SeminarskiRS2.WinUI.Timovi
{
    partial class frmTimovi
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
            this.cbLiga = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTimovi = new System.Windows.Forms.DataGridView();
            this.TimID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stadion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StadionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Liga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LigaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlikaThumb = new System.Windows.Forms.DataGridViewImageColumn();
            this.Slika = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimovi)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLiga
            // 
            this.cbLiga.FormattingEnabled = true;
            this.cbLiga.Location = new System.Drawing.Point(15, 40);
            this.cbLiga.Name = "cbLiga";
            this.cbLiga.Size = new System.Drawing.Size(298, 21);
            this.cbLiga.TabIndex = 0;
            this.cbLiga.SelectedIndexChanged += new System.EventHandler(this.cbLiga_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTimovi);
            this.groupBox1.Location = new System.Drawing.Point(12, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 350);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timovi";
            // 
            // dgvTimovi
            // 
            this.dgvTimovi.AllowUserToAddRows = false;
            this.dgvTimovi.AllowUserToDeleteRows = false;
            this.dgvTimovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimovi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimID,
            this.Naziv,
            this.Opis,
            this.Stadion,
            this.StadionID,
            this.Liga,
            this.LigaID,
            this.SlikaThumb,
            this.Slika});
            this.dgvTimovi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTimovi.Location = new System.Drawing.Point(3, 16);
            this.dgvTimovi.Name = "dgvTimovi";
            this.dgvTimovi.ReadOnly = true;
            this.dgvTimovi.Size = new System.Drawing.Size(770, 331);
            this.dgvTimovi.TabIndex = 0;
            this.dgvTimovi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvTimovi_MouseDoubleClick);
            // 
            // TimID
            // 
            this.TimID.DataPropertyName = "TimID";
            this.TimID.HeaderText = "TimID";
            this.TimID.Name = "TimID";
            this.TimID.ReadOnly = true;
            this.TimID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Opis
            // 
            this.Opis.DataPropertyName = "Opis";
            this.Opis.HeaderText = "Opis";
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            // 
            // Stadion
            // 
            this.Stadion.DataPropertyName = "Stadion";
            this.Stadion.HeaderText = "Stadion";
            this.Stadion.Name = "Stadion";
            this.Stadion.ReadOnly = true;
            // 
            // StadionID
            // 
            this.StadionID.DataPropertyName = "StadionID";
            this.StadionID.HeaderText = "StadionID";
            this.StadionID.Name = "StadionID";
            this.StadionID.ReadOnly = true;
            this.StadionID.Visible = false;
            // 
            // Liga
            // 
            this.Liga.DataPropertyName = "Liga";
            this.Liga.HeaderText = "Liga";
            this.Liga.Name = "Liga";
            this.Liga.ReadOnly = true;
            // 
            // LigaID
            // 
            this.LigaID.DataPropertyName = "LigaID";
            this.LigaID.HeaderText = "LigaiD";
            this.LigaID.Name = "LigaID";
            this.LigaID.ReadOnly = true;
            this.LigaID.Visible = false;
            // 
            // SlikaThumb
            // 
            this.SlikaThumb.DataPropertyName = "SlikaThumb";
            this.SlikaThumb.HeaderText = "Slika";
            this.SlikaThumb.Name = "SlikaThumb";
            this.SlikaThumb.ReadOnly = true;
            // 
            // Slika
            // 
            this.Slika.DataPropertyName = "Slika";
            this.Slika.HeaderText = "Slika";
            this.Slika.Name = "Slika";
            this.Slika.ReadOnly = true;
            this.Slika.Visible = false;
            // 
            // frmTimovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbLiga);
            this.Name = "frmTimovi";
            this.Text = "frmTimovi";
            this.Load += new System.EventHandler(this.frmTimovi_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimovi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLiga;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTimovi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stadion;
        private System.Windows.Forms.DataGridViewTextBoxColumn StadionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Liga;
        private System.Windows.Forms.DataGridViewTextBoxColumn LigaID;
        private System.Windows.Forms.DataGridViewImageColumn SlikaThumb;
        private System.Windows.Forms.DataGridViewImageColumn Slika;
    }
}