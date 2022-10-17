namespace OOP.net_projekt.UserControls
{
    partial class UserControlUtakmice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlUtakmice));
            this.pbStadion = new System.Windows.Forms.PictureBox();
            this.labelaDomacin = new System.Windows.Forms.Label();
            this.labelaGost = new System.Windows.Forms.Label();
            this.labelaLokacija = new System.Windows.Forms.Label();
            this.labelaPosjetitelji = new System.Windows.Forms.Label();
            this.lblDomacin = new System.Windows.Forms.Label();
            this.lblGost = new System.Windows.Forms.Label();
            this.lblLokacija = new System.Windows.Forms.Label();
            this.lblBrojPosjetitelja = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbStadion)).BeginInit();
            this.SuspendLayout();
            // 
            // pbStadion
            // 
            this.pbStadion.Image = global::OOP.net_projekt.Properties.Resources.stadium_image;
            resources.ApplyResources(this.pbStadion, "pbStadion");
            this.pbStadion.Name = "pbStadion";
            this.pbStadion.TabStop = false;
            // 
            // labelaDomacin
            // 
            resources.ApplyResources(this.labelaDomacin, "labelaDomacin");
            this.labelaDomacin.Name = "labelaDomacin";
            // 
            // labelaGost
            // 
            resources.ApplyResources(this.labelaGost, "labelaGost");
            this.labelaGost.Name = "labelaGost";
            // 
            // labelaLokacija
            // 
            resources.ApplyResources(this.labelaLokacija, "labelaLokacija");
            this.labelaLokacija.Name = "labelaLokacija";
            // 
            // labelaPosjetitelji
            // 
            resources.ApplyResources(this.labelaPosjetitelji, "labelaPosjetitelji");
            this.labelaPosjetitelji.Name = "labelaPosjetitelji";
            // 
            // lblDomacin
            // 
            resources.ApplyResources(this.lblDomacin, "lblDomacin");
            this.lblDomacin.Name = "lblDomacin";
            // 
            // lblGost
            // 
            resources.ApplyResources(this.lblGost, "lblGost");
            this.lblGost.Name = "lblGost";
            // 
            // lblLokacija
            // 
            resources.ApplyResources(this.lblLokacija, "lblLokacija");
            this.lblLokacija.Name = "lblLokacija";
            // 
            // lblBrojPosjetitelja
            // 
            resources.ApplyResources(this.lblBrojPosjetitelja, "lblBrojPosjetitelja");
            this.lblBrojPosjetitelja.Name = "lblBrojPosjetitelja";
            // 
            // UserControlUtakmice
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblBrojPosjetitelja);
            this.Controls.Add(this.lblLokacija);
            this.Controls.Add(this.lblGost);
            this.Controls.Add(this.lblDomacin);
            this.Controls.Add(this.labelaPosjetitelji);
            this.Controls.Add(this.labelaLokacija);
            this.Controls.Add(this.labelaGost);
            this.Controls.Add(this.labelaDomacin);
            this.Controls.Add(this.pbStadion);
            this.Name = "UserControlUtakmice";
            ((System.ComponentModel.ISupportInitialize)(this.pbStadion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbStadion;
        private System.Windows.Forms.Label labelaDomacin;
        private System.Windows.Forms.Label labelaGost;
        private System.Windows.Forms.Label labelaLokacija;
        private System.Windows.Forms.Label labelaPosjetitelji;
        private System.Windows.Forms.Label lblDomacin;
        private System.Windows.Forms.Label lblGost;
        private System.Windows.Forms.Label lblLokacija;
        private System.Windows.Forms.Label lblBrojPosjetitelja;
    }
}
