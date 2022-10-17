namespace OOP.net_projekt.Forms
{
    partial class OdabirNajdrazegTimaForma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OdabirNajdrazegTimaForma));
            this.cbNajdraziTim = new System.Windows.Forms.ComboBox();
            this.btnDalje = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbNajdraziTim
            // 
            this.cbNajdraziTim.FormattingEnabled = true;
            resources.ApplyResources(this.cbNajdraziTim, "cbNajdraziTim");
            this.cbNajdraziTim.Name = "cbNajdraziTim";
            this.cbNajdraziTim.SelectedIndexChanged += new System.EventHandler(this.cbNajdraziTim_SelectedIndexChanged);
            // 
            // btnDalje
            // 
            resources.ApplyResources(this.btnDalje, "btnDalje");
            this.btnDalje.Name = "btnDalje";
            this.btnDalje.UseVisualStyleBackColor = true;
            this.btnDalje.Click += new System.EventHandler(this.btnDalje_Click);
            // 
            // btnOdustani
            // 
            resources.ApplyResources(this.btnOdustani, "btnOdustani");
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // OdabirNajdrazegTimaForma
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDalje);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.cbNajdraziTim);
            this.Name = "OdabirNajdrazegTimaForma";
            this.Load += new System.EventHandler(this.OdabirNajdrazegTimaForma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNajdraziTim;
        private System.Windows.Forms.Button btnDalje;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Label label1;
    }
}