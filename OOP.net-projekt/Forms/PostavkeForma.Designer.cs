namespace OOP.net_projekt.Forms
{
    partial class PostavkeForma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostavkeForma));
            this.lblOdabirJezika = new System.Windows.Forms.Label();
            this.btnHrvatski = new System.Windows.Forms.Button();
            this.btnEngleski = new System.Windows.Forms.Button();
            this.lblOdabirPrvenstva = new System.Windows.Forms.Label();
            this.btnMuskoPrvenstvo = new System.Windows.Forms.Button();
            this.btnZenskoPrvenstvo = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.lblIspisOdabiraPrvenstva = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblOdabirJezika
            // 
            resources.ApplyResources(this.lblOdabirJezika, "lblOdabirJezika");
            this.lblOdabirJezika.Name = "lblOdabirJezika";
            // 
            // btnHrvatski
            // 
            resources.ApplyResources(this.btnHrvatski, "btnHrvatski");
            this.btnHrvatski.Name = "btnHrvatski";
            this.btnHrvatski.UseMnemonic = false;
            this.btnHrvatski.UseVisualStyleBackColor = true;
            this.btnHrvatski.Click += new System.EventHandler(this.btnHrvatski_Click);
            // 
            // btnEngleski
            // 
            resources.ApplyResources(this.btnEngleski, "btnEngleski");
            this.btnEngleski.Name = "btnEngleski";
            this.btnEngleski.UseMnemonic = false;
            this.btnEngleski.UseVisualStyleBackColor = true;
            this.btnEngleski.Click += new System.EventHandler(this.btnEngleski_Click);
            // 
            // lblOdabirPrvenstva
            // 
            resources.ApplyResources(this.lblOdabirPrvenstva, "lblOdabirPrvenstva");
            this.lblOdabirPrvenstva.Name = "lblOdabirPrvenstva";
            // 
            // btnMuskoPrvenstvo
            // 
            resources.ApplyResources(this.btnMuskoPrvenstvo, "btnMuskoPrvenstvo");
            this.btnMuskoPrvenstvo.Name = "btnMuskoPrvenstvo";
            this.btnMuskoPrvenstvo.UseMnemonic = false;
            this.btnMuskoPrvenstvo.UseVisualStyleBackColor = true;
            this.btnMuskoPrvenstvo.Click += new System.EventHandler(this.btnMuskoPrvenstvo_Click);
            // 
            // btnZenskoPrvenstvo
            // 
            resources.ApplyResources(this.btnZenskoPrvenstvo, "btnZenskoPrvenstvo");
            this.btnZenskoPrvenstvo.Name = "btnZenskoPrvenstvo";
            this.btnZenskoPrvenstvo.UseMnemonic = false;
            this.btnZenskoPrvenstvo.UseVisualStyleBackColor = true;
            this.btnZenskoPrvenstvo.Click += new System.EventHandler(this.btnZenskoPrvenstvo_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnOdustani, "btnOdustani");
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnPotvrdi, "btnPotvrdi");
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // lblIspisOdabiraPrvenstva
            // 
            resources.ApplyResources(this.lblIspisOdabiraPrvenstva, "lblIspisOdabiraPrvenstva");
            this.lblIspisOdabiraPrvenstva.Name = "lblIspisOdabiraPrvenstva";
            // 
            // PostavkeForma
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblIspisOdabiraPrvenstva);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnZenskoPrvenstvo);
            this.Controls.Add(this.btnMuskoPrvenstvo);
            this.Controls.Add(this.lblOdabirPrvenstva);
            this.Controls.Add(this.btnEngleski);
            this.Controls.Add(this.btnHrvatski);
            this.Controls.Add(this.lblOdabirJezika);
            this.KeyPreview = true;
            this.Name = "PostavkeForma";
            this.Load += new System.EventHandler(this.PostavkeForma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOdabirJezika;
        private System.Windows.Forms.Button btnHrvatski;
        private System.Windows.Forms.Button btnEngleski;
        private System.Windows.Forms.Label lblOdabirPrvenstva;
        private System.Windows.Forms.Button btnMuskoPrvenstvo;
        private System.Windows.Forms.Button btnZenskoPrvenstvo;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.Label lblIspisOdabiraPrvenstva;
    }
}