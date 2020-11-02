namespace SeminarskiRS2.WinUI.Utakmice
{
    partial class frmUtakmiceDetalji
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
            this.cbDomaci = new System.Windows.Forms.ComboBox();
            this.cbGosti = new System.Windows.Forms.ComboBox();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.dtpVrijeme = new System.Windows.Forms.DateTimePicker();
            this.cbLiga = new System.Windows.Forms.ComboBox();
            this.cbStadion = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDomaci
            // 
            this.cbDomaci.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDomaci.FormattingEnabled = true;
            this.cbDomaci.Location = new System.Drawing.Point(66, 38);
            this.cbDomaci.Name = "cbDomaci";
            this.cbDomaci.Size = new System.Drawing.Size(302, 21);
            this.cbDomaci.TabIndex = 0;
            this.cbDomaci.Validating += new System.ComponentModel.CancelEventHandler(this.cbDomaci_Validating);
            // 
            // cbGosti
            // 
            this.cbGosti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGosti.FormattingEnabled = true;
            this.cbGosti.Location = new System.Drawing.Point(66, 100);
            this.cbGosti.Name = "cbGosti";
            this.cbGosti.Size = new System.Drawing.Size(302, 21);
            this.cbGosti.TabIndex = 1;
            this.cbGosti.Validating += new System.ComponentModel.CancelEventHandler(this.cbGosti_Validating);
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(66, 162);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(302, 20);
            this.dtpDatum.TabIndex = 2;
            this.dtpDatum.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDatum_Validating);
            // 
            // dtpVrijeme
            // 
            this.dtpVrijeme.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpVrijeme.Location = new System.Drawing.Point(66, 214);
            this.dtpVrijeme.Name = "dtpVrijeme";
            this.dtpVrijeme.Size = new System.Drawing.Size(302, 20);
            this.dtpVrijeme.TabIndex = 3;
            this.dtpVrijeme.Validating += new System.ComponentModel.CancelEventHandler(this.dtpVrijeme_Validating);
            // 
            // cbLiga
            // 
            this.cbLiga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLiga.FormattingEnabled = true;
            this.cbLiga.Location = new System.Drawing.Point(66, 264);
            this.cbLiga.Name = "cbLiga";
            this.cbLiga.Size = new System.Drawing.Size(302, 21);
            this.cbLiga.TabIndex = 4;
            this.cbLiga.Validating += new System.ComponentModel.CancelEventHandler(this.cbLiga_Validating);
            // 
            // cbStadion
            // 
            this.cbStadion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStadion.FormattingEnabled = true;
            this.cbStadion.Location = new System.Drawing.Point(66, 321);
            this.cbStadion.Name = "cbStadion";
            this.cbStadion.Size = new System.Drawing.Size(302, 21);
            this.cbStadion.TabIndex = 5;
            this.cbStadion.Validating += new System.ComponentModel.CancelEventHandler(this.cbStadion_Validating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(66, 376);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 67);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(293, 385);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 46);
            this.btnDodaj.TabIndex = 7;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(66, 469);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(302, 34);
            this.btnSacuvaj.TabIndex = 8;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Domaći tim";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Gostujući tim";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Datum odigravanja";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Vrijeme odigravanja";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Vrsta natjecanja";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Stadion";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmUtakmiceDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 545);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbStadion);
            this.Controls.Add(this.cbLiga);
            this.Controls.Add(this.dtpVrijeme);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.cbGosti);
            this.Controls.Add(this.cbDomaci);
            this.Name = "frmUtakmiceDetalji";
            this.Text = "frmUtakmiceDetalji";
            this.Load += new System.EventHandler(this.frmUtakmiceDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDomaci;
        private System.Windows.Forms.ComboBox cbGosti;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.DateTimePicker dtpVrijeme;
        private System.Windows.Forms.ComboBox cbLiga;
        private System.Windows.Forms.ComboBox cbStadion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}