namespace OOP.net_projekt.UserControls
{
    partial class UserControlIgrac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlIgrac));
            this.lblPunoIme = new System.Windows.Forms.Label();
            this.lblPozicija = new System.Windows.Forms.Label();
            this.lblBroj = new System.Windows.Forms.Label();
            this.pbNajdraziIgrac = new System.Windows.Forms.PictureBox();
            this.lblKapetan = new System.Windows.Forms.Label();
            this.pbIgrac = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbNajdraziIgrac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIgrac)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPunoIme
            // 
            resources.ApplyResources(this.lblPunoIme, "lblPunoIme");
            this.lblPunoIme.Name = "lblPunoIme";
            // 
            // lblPozicija
            // 
            resources.ApplyResources(this.lblPozicija, "lblPozicija");
            this.lblPozicija.Name = "lblPozicija";
            // 
            // lblBroj
            // 
            resources.ApplyResources(this.lblBroj, "lblBroj");
            this.lblBroj.Name = "lblBroj";
            // 
            // pbNajdraziIgrac
            // 
            resources.ApplyResources(this.pbNajdraziIgrac, "pbNajdraziIgrac");
            this.pbNajdraziIgrac.Name = "pbNajdraziIgrac";
            this.pbNajdraziIgrac.TabStop = false;
            // 
            // lblKapetan
            // 
            resources.ApplyResources(this.lblKapetan, "lblKapetan");
            this.lblKapetan.Name = "lblKapetan";
            // 
            // pbIgrac
            // 
            resources.ApplyResources(this.pbIgrac, "pbIgrac");
            this.pbIgrac.Name = "pbIgrac";
            this.pbIgrac.TabStop = false;
            // 
            // UserControlIgrac
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pbIgrac);
            this.Controls.Add(this.lblKapetan);
            this.Controls.Add(this.pbNajdraziIgrac);
            this.Controls.Add(this.lblBroj);
            this.Controls.Add(this.lblPozicija);
            this.Controls.Add(this.lblPunoIme);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "UserControlIgrac";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserControlIgrac_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbNajdraziIgrac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIgrac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPunoIme;
        private System.Windows.Forms.Label lblPozicija;
        private System.Windows.Forms.Label lblBroj;
        private System.Windows.Forms.PictureBox pbNajdraziIgrac;
        private System.Windows.Forms.Label lblKapetan;
        private System.Windows.Forms.PictureBox pbIgrac;
    }
}
