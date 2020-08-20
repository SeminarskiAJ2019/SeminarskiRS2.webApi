namespace SeminarskiRS2.WinUI.Izvješća
{
    partial class frmGodineStadioniIzvjesce
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
            this.cbGodina = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvIzvješće = new System.Windows.Forms.DataGridView();
            this.Stadion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojProdanihUlaznica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zarada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvješće)).BeginInit();
            this.SuspendLayout();
            // 
            // cbGodina
            // 
            this.cbGodina.FormattingEnabled = true;
            this.cbGodina.Location = new System.Drawing.Point(15, 36);
            this.cbGodina.Name = "cbGodina";
            this.cbGodina.Size = new System.Drawing.Size(223, 21);
            this.cbGodina.TabIndex = 0;
            this.cbGodina.SelectedIndexChanged += new System.EventHandler(this.cbGodina_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvIzvješće);
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(937, 490);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ukupni dohodak";
            // 
            // dgvIzvješće
            // 
            this.dgvIzvješće.AllowUserToAddRows = false;
            this.dgvIzvješće.AllowUserToDeleteRows = false;
            this.dgvIzvješće.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIzvješće.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stadion,
            this.Grad,
            this.BrojProdanihUlaznica,
            this.Zarada});
            this.dgvIzvješće.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIzvješće.Location = new System.Drawing.Point(3, 16);
            this.dgvIzvješće.Name = "dgvIzvješće";
            this.dgvIzvješće.ReadOnly = true;
            this.dgvIzvješće.Size = new System.Drawing.Size(931, 471);
            this.dgvIzvješće.TabIndex = 0;
            // 
            // Stadion
            // 
            this.Stadion.DataPropertyName = "Stadion";
            this.Stadion.HeaderText = "Naziv stadiona";
            this.Stadion.Name = "Stadion";
            this.Stadion.ReadOnly = true;
            this.Stadion.Width = 150;
            // 
            // Grad
            // 
            this.Grad.DataPropertyName = "Grad";
            this.Grad.HeaderText = "Grad";
            this.Grad.Name = "Grad";
            this.Grad.ReadOnly = true;
            this.Grad.Width = 150;
            // 
            // BrojProdanihUlaznica
            // 
            this.BrojProdanihUlaznica.DataPropertyName = "BrojProdanihUlaznica";
            this.BrojProdanihUlaznica.HeaderText = "BrojProdanihUlaznica";
            this.BrojProdanihUlaznica.Name = "BrojProdanihUlaznica";
            this.BrojProdanihUlaznica.ReadOnly = true;
            this.BrojProdanihUlaznica.Width = 150;
            // 
            // Zarada
            // 
            this.Zarada.DataPropertyName = "Zarada";
            this.Zarada.HeaderText = "Ukupna zarada";
            this.Zarada.Name = "Zarada";
            this.Zarada.ReadOnly = true;
            this.Zarada.Width = 150;
            // 
            // frmGodineStadioniIzvjesce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 593);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbGodina);
            this.Name = "frmGodineStadioniIzvjesce";
            this.Text = "frmGodineStadioniIzvjesce";
            this.Load += new System.EventHandler(this.frmGodineStadioniIzvjesce_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvješće)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbGodina;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvIzvješće;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stadion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grad;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojProdanihUlaznica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zarada;
    }
}