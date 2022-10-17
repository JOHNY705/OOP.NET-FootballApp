namespace OOP.net_projekt.Forms
{
    partial class OdabirPrvenstvaForma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OdabirPrvenstvaForma));
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnDalje = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMusko = new System.Windows.Forms.Button();
            this.btnZensko = new System.Windows.Forms.Button();
            this.lblOdabir = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOdustani
            // 
            resources.ApplyResources(this.btnOdustani, "btnOdustani");
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnDalje
            // 
            resources.ApplyResources(this.btnDalje, "btnDalje");
            this.btnDalje.Name = "btnDalje";
            this.btnDalje.UseVisualStyleBackColor = true;
            this.btnDalje.Click += new System.EventHandler(this.btnDalje_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnMusko
            // 
            resources.ApplyResources(this.btnMusko, "btnMusko");
            this.btnMusko.Name = "btnMusko";
            this.btnMusko.UseVisualStyleBackColor = true;
            this.btnMusko.Click += new System.EventHandler(this.btnMusko_Click);
            // 
            // btnZensko
            // 
            resources.ApplyResources(this.btnZensko, "btnZensko");
            this.btnZensko.Name = "btnZensko";
            this.btnZensko.UseVisualStyleBackColor = true;
            this.btnZensko.Click += new System.EventHandler(this.btnZensko_Click);
            // 
            // lblOdabir
            // 
            resources.ApplyResources(this.lblOdabir, "lblOdabir");
            this.lblOdabir.Name = "lblOdabir";
            // 
            // OdabirPrvenstvaForma
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblOdabir);
            this.Controls.Add(this.btnZensko);
            this.Controls.Add(this.btnMusko);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDalje);
            this.Controls.Add(this.btnOdustani);
            this.Name = "OdabirPrvenstvaForma";
            this.Load += new System.EventHandler(this.OdabirPrvenstvaForma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnDalje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMusko;
        private System.Windows.Forms.Button btnZensko;
        private System.Windows.Forms.Label lblOdabir;
    }
}