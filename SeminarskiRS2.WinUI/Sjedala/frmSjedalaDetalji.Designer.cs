namespace SeminarskiRS2.WinUI.Sjedala
{
    partial class frmSjedalaDetalji
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
            this.txtOznaka = new System.Windows.Forms.TextBox();
            this.cbSektori = new System.Windows.Forms.ComboBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.cbxStatus = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOznaka
            // 
            this.txtOznaka.Location = new System.Drawing.Point(106, 44);
            this.txtOznaka.Name = "txtOznaka";
            this.txtOznaka.Size = new System.Drawing.Size(165, 20);
            this.txtOznaka.TabIndex = 0;
            this.txtOznaka.Validating += new System.ComponentModel.CancelEventHandler(this.txtOznaka_Validating_1);
            // 
            // cbSektori
            // 
            this.cbSektori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSektori.FormattingEnabled = true;
            this.cbSektori.Location = new System.Drawing.Point(106, 102);
            this.cbSektori.Name = "cbSektori";
            this.cbSektori.Size = new System.Drawing.Size(245, 21);
            this.cbSektori.TabIndex = 1;
            this.cbSektori.Validating += new System.ComponentModel.CancelEventHandler(this.cbSektori_Validating);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(106, 169);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(245, 23);
            this.btnSacuvaj.TabIndex = 2;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // cbxStatus
            // 
            this.cbxStatus.AutoSize = true;
            this.cbxStatus.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.cbxStatus.Location = new System.Drawing.Point(277, 47);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(71, 17);
            this.cbxStatus.TabIndex = 3;
            this.cbxStatus.Text = "Zauzeto?";
            this.cbxStatus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Oznaka sjedala";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sektor";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmSjedalaDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 266);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxStatus);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.cbSektori);
            this.Controls.Add(this.txtOznaka);
            this.Name = "frmSjedalaDetalji";
            this.Text = "frmSjedalaDetalji";
            this.Load += new System.EventHandler(this.frmSjedalaDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOznaka;
        private System.Windows.Forms.ComboBox cbSektori;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.CheckBox cbxStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}