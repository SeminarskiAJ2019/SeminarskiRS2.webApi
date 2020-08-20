namespace SeminarskiRS2.WinUI.Sjedala
{
    partial class frmSjedala
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
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSjedala = new System.Windows.Forms.DataGridView();
            this.SjedaloID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Oznaka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zauzeto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Sektor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SektorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSjedala)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(15, 49);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(320, 20);
            this.txtPretraga.TabIndex = 0;
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Location = new System.Drawing.Point(667, 46);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(82, 23);
            this.btnPretrazi.TabIndex = 1;
            this.btnPretrazi.Text = "Pretraži";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSjedala);
            this.groupBox1.Location = new System.Drawing.Point(12, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 346);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sjedala";
            // 
            // dgvSjedala
            // 
            this.dgvSjedala.AllowUserToAddRows = false;
            this.dgvSjedala.AllowUserToDeleteRows = false;
            this.dgvSjedala.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSjedala.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SjedaloID,
            this.Oznaka,
            this.Zauzeto,
            this.Sektor,
            this.SektorID});
            this.dgvSjedala.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSjedala.Location = new System.Drawing.Point(3, 16);
            this.dgvSjedala.Name = "dgvSjedala";
            this.dgvSjedala.ReadOnly = true;
            this.dgvSjedala.Size = new System.Drawing.Size(756, 327);
            this.dgvSjedala.TabIndex = 0;
            this.dgvSjedala.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvSjedala_MouseDoubleClick);
            // 
            // SjedaloID
            // 
            this.SjedaloID.DataPropertyName = "SjedaloID";
            this.SjedaloID.HeaderText = "SjedaloID";
            this.SjedaloID.Name = "SjedaloID";
            this.SjedaloID.ReadOnly = true;
            this.SjedaloID.Visible = false;
            // 
            // Oznaka
            // 
            this.Oznaka.DataPropertyName = "Oznaka";
            this.Oznaka.HeaderText = "Oznaka sjedala";
            this.Oznaka.Name = "Oznaka";
            this.Oznaka.ReadOnly = true;
            this.Oznaka.Width = 150;
            // 
            // Zauzeto
            // 
            this.Zauzeto.DataPropertyName = "Status";
            this.Zauzeto.HeaderText = "Zauzeto";
            this.Zauzeto.Name = "Zauzeto";
            this.Zauzeto.ReadOnly = true;
            this.Zauzeto.Width = 150;
            // 
            // Sektor
            // 
            this.Sektor.DataPropertyName = "Sektor";
            this.Sektor.HeaderText = "Naziv sektora";
            this.Sektor.Name = "Sektor";
            this.Sektor.ReadOnly = true;
            this.Sektor.Width = 150;
            // 
            // SektorID
            // 
            this.SektorID.HeaderText = "SektorID";
            this.SektorID.Name = "SektorID";
            this.SektorID.ReadOnly = true;
            this.SektorID.Visible = false;
            // 
            // frmSjedala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPretrazi);
            this.Controls.Add(this.txtPretraga);
            this.Name = "frmSjedala";
            this.Text = "frmSjedala";
            this.Load += new System.EventHandler(this.frmSjedala_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSjedala)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSjedala;
        private System.Windows.Forms.DataGridViewTextBoxColumn SjedaloID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Oznaka;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Zauzeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sektor;
        private System.Windows.Forms.DataGridViewTextBoxColumn SektorID;
    }
}