namespace OOP.net_projekt.UserControls
{
    partial class UserControlRangGolovi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlRangGolovi));
            this.pbSlikaIgraca = new System.Windows.Forms.PictureBox();
            this.pbNajdraziIgrac = new System.Windows.Forms.PictureBox();
            this.lblNazivIgraca = new System.Windows.Forms.Label();
            this.lblDogadaj = new System.Windows.Forms.Label();
            this.lblBrojGolova = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaIgraca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNajdraziIgrac)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSlikaIgraca
            // 
            this.pbSlikaIgraca.Image = global::OOP.net_projekt.Properties.Resources.football_player_silhouette_png_7;
            resources.ApplyResources(this.pbSlikaIgraca, "pbSlikaIgraca");
            this.pbSlikaIgraca.Name = "pbSlikaIgraca";
            this.pbSlikaIgraca.TabStop = false;
            // 
            // pbNajdraziIgrac
            // 
            resources.ApplyResources(this.pbNajdraziIgrac, "pbNajdraziIgrac");
            this.pbNajdraziIgrac.Name = "pbNajdraziIgrac";
            this.pbNajdraziIgrac.TabStop = false;
            // 
            // lblNazivIgraca
            // 
            resources.ApplyResources(this.lblNazivIgraca, "lblNazivIgraca");
            this.lblNazivIgraca.Name = "lblNazivIgraca";
            // 
            // lblDogadaj
            // 
            resources.ApplyResources(this.lblDogadaj, "lblDogadaj");
            this.lblDogadaj.Name = "lblDogadaj";
            // 
            // lblBrojGolova
            // 
            resources.ApplyResources(this.lblBrojGolova, "lblBrojGolova");
            this.lblBrojGolova.Name = "lblBrojGolova";
            // 
            // UserControlRangGolovi
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblBrojGolova);
            this.Controls.Add(this.lblDogadaj);
            this.Controls.Add(this.lblNazivIgraca);
            this.Controls.Add(this.pbNajdraziIgrac);
            this.Controls.Add(this.pbSlikaIgraca);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "UserControlRangGolovi";
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaIgraca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNajdraziIgrac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSlikaIgraca;
        private System.Windows.Forms.PictureBox pbNajdraziIgrac;
        private System.Windows.Forms.Label lblNazivIgraca;
        private System.Windows.Forms.Label lblDogadaj;
        private System.Windows.Forms.Label lblBrojGolova;
    }
}
