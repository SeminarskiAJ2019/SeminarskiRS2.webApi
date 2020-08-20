namespace SeminarskiRS2.WinUI.Ulaznice
{
    partial class frmUlazniceDetalji
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
            this.cbUtakmica = new System.Windows.Forms.ComboBox();
            this.cbSektor = new System.Windows.Forms.ComboBox();
            this.cbSjedala = new System.Windows.Forms.ComboBox();
            this.cbKorisnik = new System.Windows.Forms.ComboBox();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.dtpVrijeme = new System.Windows.Forms.DateTimePicker();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbUtakmica
            // 
            this.cbUtakmica.FormattingEnabled = true;
            this.cbUtakmica.Location = new System.Drawing.Point(68, 51);
            this.cbUtakmica.Name = "cbUtakmica";
            this.cbUtakmica.Size = new System.Drawing.Size(273, 21);
            this.cbUtakmica.TabIndex = 0;
            this.cbUtakmica.SelectionChangeCommitted += new System.EventHandler(this.cbUtakmica_SelectionChangeCommitted);
            this.cbUtakmica.Validating += new System.ComponentModel.CancelEventHandler(this.cbUtakmica_Validating);
            // 
            // cbSektor
            // 
            this.cbSektor.FormattingEnabled = true;
            this.cbSektor.Location = new System.Drawing.Point(68, 101);
            this.cbSektor.Name = "cbSektor";
            this.cbSektor.Size = new System.Drawing.Size(273, 21);
            this.cbSektor.TabIndex = 1;
            this.cbSektor.SelectionChangeCommitted += new System.EventHandler(this.cbSektor_SelectionChangeCommitted);
            this.cbSektor.Validating += new System.ComponentModel.CancelEventHandler(this.cbSektor_Validating);
            // 
            // cbSjedala
            // 
            this.cbSjedala.FormattingEnabled = true;
            this.cbSjedala.Location = new System.Drawing.Point(68, 161);
            this.cbSjedala.Name = "cbSjedala";
            this.cbSjedala.Size = new System.Drawing.Size(273, 21);
            this.cbSjedala.TabIndex = 2;
            this.cbSjedala.Validating += new System.ComponentModel.CancelEventHandler(this.cbSjedala_Validating);
            // 
            // cbKorisnik
            // 
            this.cbKorisnik.FormattingEnabled = true;
            this.cbKorisnik.Location = new System.Drawing.Point(68, 213);
            this.cbKorisnik.Name = "cbKorisnik";
            this.cbKorisnik.Size = new System.Drawing.Size(273, 21);
            this.cbKorisnik.TabIndex = 3;
            this.cbKorisnik.Validating += new System.ComponentModel.CancelEventHandler(this.cbKorisnik_Validating);
            // 
            // dtpDatum
            // 
            this.dtpDatum.CustomFormat = "dd MM yyyy";
            this.dtpDatum.Location = new System.Drawing.Point(68, 275);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(273, 20);
            this.dtpDatum.TabIndex = 4;
            this.dtpDatum.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDatum_Validating);
            // 
            // dtpVrijeme
            // 
            this.dtpVrijeme.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpVrijeme.Location = new System.Drawing.Point(68, 326);
            this.dtpVrijeme.Name = "dtpVrijeme";
            this.dtpVrijeme.Size = new System.Drawing.Size(273, 20);
            this.dtpVrijeme.TabIndex = 5;
            this.dtpVrijeme.Validating += new System.ComponentModel.CancelEventHandler(this.dtpVrijeme_Validating);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(68, 382);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(273, 33);
            this.btnSacuvaj.TabIndex = 6;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Utakmica";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sektor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Oznaka sjedala";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Korisnik";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Datum kupnje";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Vrijeme kupnje";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmUlazniceDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 457);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.dtpVrijeme);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.cbKorisnik);
            this.Controls.Add(this.cbSjedala);
            this.Controls.Add(this.cbSektor);
            this.Controls.Add(this.cbUtakmica);
            this.Name = "frmUlazniceDetalji";
            this.Text = "frmUlazniceDetalji";
            this.Load += new System.EventHandler(this.frmUlazniceDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUtakmica;
        private System.Windows.Forms.ComboBox cbSektor;
        private System.Windows.Forms.ComboBox cbSjedala;
        private System.Windows.Forms.ComboBox cbKorisnik;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.DateTimePicker dtpVrijeme;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}