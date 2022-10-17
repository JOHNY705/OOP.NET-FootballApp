namespace OOP.net_projekt.UserControls
{
    partial class UserControlRangKartoni
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlRangKartoni));
            this.lblNazivIgraca = new System.Windows.Forms.Label();
            this.pbNajdraziIgrac = new System.Windows.Forms.PictureBox();
            this.pbSlikaIgraca = new System.Windows.Forms.PictureBox();
            this.lblDogadaj = new System.Windows.Forms.Label();
            this.lblBrojKartona = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbNajdraziIgrac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaIgraca)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNazivIgraca
            // 
            resources.ApplyResources(this.lblNazivIgraca, "lblNazivIgraca");
            this.lblNazivIgraca.BackColor = System.Drawing.Color.Silver;
            this.lblNazivIgraca.Name = "lblNazivIgraca";
            // 
            // pbNajdraziIgrac
            // 
            resources.ApplyResources(this.pbNajdraziIgrac, "pbNajdraziIgrac");
            this.pbNajdraziIgrac.Name = "pbNajdraziIgrac";
            this.pbNajdraziIgrac.TabStop = false;
            // 
            // pbSlikaIgraca
            // 
            resources.ApplyResources(this.pbSlikaIgraca, "pbSlikaIgraca");
            this.pbSlikaIgraca.Name = "pbSlikaIgraca";
            this.pbSlikaIgraca.TabStop = false;
            // 
            // lblDogadaj
            // 
            resources.ApplyResources(this.lblDogadaj, "lblDogadaj");
            this.lblDogadaj.Name = "lblDogadaj";
            // 
            // lblBrojKartona
            // 
            resources.ApplyResources(this.lblBrojKartona, "lblBrojKartona");
            this.lblBrojKartona.Name = "lblBrojKartona";
            // 
            // UserControlRangKartoni
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblBrojKartona);
            this.Controls.Add(this.lblDogadaj);
            this.Controls.Add(this.pbSlikaIgraca);
            this.Controls.Add(this.pbNajdraziIgrac);
            this.Controls.Add(this.lblNazivIgraca);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "UserControlRangKartoni";
            ((System.ComponentModel.ISupportInitialize)(this.pbNajdraziIgrac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaIgraca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNazivIgraca;
        private System.Windows.Forms.PictureBox pbNajdraziIgrac;
        private System.Windows.Forms.PictureBox pbSlikaIgraca;
        private System.Windows.Forms.Label lblDogadaj;
        private System.Windows.Forms.Label lblBrojKartona;
    }
}
