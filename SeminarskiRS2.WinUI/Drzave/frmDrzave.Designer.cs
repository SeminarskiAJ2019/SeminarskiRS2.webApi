namespace SeminarskiRS2.WinUI.Drzave
{
    partial class frmDrzave
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
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.grpDrzave = new System.Windows.Forms.GroupBox();
            this.dgvDrzave = new System.Windows.Forms.DataGridView();
            this.DrzavaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDrzave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrzave)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(26, 28);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(377, 20);
            this.txtPretraga.TabIndex = 0;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(685, 28);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(75, 23);
            this.btnPrikazi.TabIndex = 1;
            this.btnPrikazi.Text = "Prikazi";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // grpDrzave
            // 
            this.grpDrzave.Controls.Add(this.dgvDrzave);
            this.grpDrzave.Location = new System.Drawing.Point(26, 86);
            this.grpDrzave.Name = "grpDrzave";
            this.grpDrzave.Size = new System.Drawing.Size(734, 352);
            this.grpDrzave.TabIndex = 3;
            this.grpDrzave.TabStop = false;
            this.grpDrzave.Text = "Drzave";
            // 
            // dgvDrzave
            // 
            this.dgvDrzave.AllowUserToAddRows = false;
            this.dgvDrzave.AllowUserToDeleteRows = false;
            this.dgvDrzave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDrzave.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DrzavaID,
            this.Naziv});
            this.dgvDrzave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDrzave.Location = new System.Drawing.Point(3, 16);
            this.dgvDrzave.Name = "dgvDrzave";
            this.dgvDrzave.ReadOnly = true;
            this.dgvDrzave.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDrzave.Size = new System.Drawing.Size(728, 333);
            this.dgvDrzave.TabIndex = 0;
            this.dgvDrzave.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDrzave_MouseDoubleClick);
            // 
            // DrzavaID
            // 
            this.DrzavaID.DataPropertyName = "DrzavaID";
            this.DrzavaID.HeaderText = "DrzavaID";
            this.DrzavaID.Name = "DrzavaID";
            this.DrzavaID.ReadOnly = true;
            this.DrzavaID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv države";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // frmDrzave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpDrzave);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.txtPretraga);
            this.Name = "frmDrzave";
            this.Text = "frmDrzave";
            this.grpDrzave.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrzave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.GroupBox grpDrzave;
        private System.Windows.Forms.DataGridView dgvDrzave;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrzavaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
    }
}