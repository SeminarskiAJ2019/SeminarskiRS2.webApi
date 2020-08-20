namespace SeminarskiRS2.WinUI.Lige
{
    partial class frmLige
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
            this.cbDrzave = new System.Windows.Forms.ComboBox();
            this.Lige = new System.Windows.Forms.GroupBox();
            this.dgvLige = new System.Windows.Forms.DataGridView();
            this.LigaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrzavaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drzava = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lige.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLige)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDrzave
            // 
            this.cbDrzave.FormattingEnabled = true;
            this.cbDrzave.Location = new System.Drawing.Point(12, 35);
            this.cbDrzave.Name = "cbDrzave";
            this.cbDrzave.Size = new System.Drawing.Size(182, 21);
            this.cbDrzave.TabIndex = 0;
            this.cbDrzave.SelectedIndexChanged += new System.EventHandler(this.cbDrzave_SelectedIndexChanged);
            // 
            // Lige
            // 
            this.Lige.Controls.Add(this.dgvLige);
            this.Lige.Location = new System.Drawing.Point(12, 78);
            this.Lige.Name = "Lige";
            this.Lige.Size = new System.Drawing.Size(765, 360);
            this.Lige.TabIndex = 1;
            this.Lige.TabStop = false;
            this.Lige.Text = "Lige";
            // 
            // dgvLige
            // 
            this.dgvLige.AllowUserToAddRows = false;
            this.dgvLige.AllowUserToDeleteRows = false;
            this.dgvLige.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLige.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LigaID,
            this.Naziv,
            this.DrzavaID,
            this.Drzava});
            this.dgvLige.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLige.Location = new System.Drawing.Point(3, 16);
            this.dgvLige.Name = "dgvLige";
            this.dgvLige.ReadOnly = true;
            this.dgvLige.Size = new System.Drawing.Size(759, 341);
            this.dgvLige.TabIndex = 0;
            this.dgvLige.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvLige_MouseDoubleClick);
            // 
            // LigaID
            // 
            this.LigaID.DataPropertyName = "LigaID";
            this.LigaID.HeaderText = "LigaID";
            this.LigaID.Name = "LigaID";
            this.LigaID.ReadOnly = true;
            this.LigaID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // DrzavaID
            // 
            this.DrzavaID.DataPropertyName = "DrzavaID";
            this.DrzavaID.HeaderText = "DrzavaID";
            this.DrzavaID.Name = "DrzavaID";
            this.DrzavaID.ReadOnly = true;
            this.DrzavaID.Visible = false;
            // 
            // Drzava
            // 
            this.Drzava.DataPropertyName = "Drzava";
            this.Drzava.HeaderText = "Drzava";
            this.Drzava.Name = "Drzava";
            this.Drzava.ReadOnly = true;
            // 
            // frmLige
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Lige);
            this.Controls.Add(this.cbDrzave);
            this.Name = "frmLige";
            this.Text = "frmLige";
            this.Load += new System.EventHandler(this.frmLige_Load);
            this.Lige.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLige)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDrzave;
        private System.Windows.Forms.GroupBox Lige;
        private System.Windows.Forms.DataGridView dgvLige;
        private System.Windows.Forms.DataGridViewTextBoxColumn LigaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrzavaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drzava;
    }
}