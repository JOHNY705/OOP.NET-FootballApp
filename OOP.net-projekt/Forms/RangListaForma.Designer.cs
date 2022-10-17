namespace OOP.net_projekt.Forms
{
    partial class RangListaForma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RangListaForma));
            this.flpIgraciGolovi = new System.Windows.Forms.FlowLayoutPanel();
            this.flpIgraciZutiKartoni = new System.Windows.Forms.FlowLayoutPanel();
            this.flpUtakmice = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNajviseGolova = new System.Windows.Forms.Label();
            this.lblNajviseZutih = new System.Windows.Forms.Label();
            this.lblUtakmice = new System.Windows.Forms.Label();
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPostavke = new System.Windows.Forms.Button();
            this.lblUcitavanje = new System.Windows.Forms.Label();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.SuspendLayout();
            // 
            // flpIgraciGolovi
            // 
            resources.ApplyResources(this.flpIgraciGolovi, "flpIgraciGolovi");
            this.flpIgraciGolovi.Name = "flpIgraciGolovi";
            // 
            // flpIgraciZutiKartoni
            // 
            resources.ApplyResources(this.flpIgraciZutiKartoni, "flpIgraciZutiKartoni");
            this.flpIgraciZutiKartoni.Name = "flpIgraciZutiKartoni";
            // 
            // flpUtakmice
            // 
            resources.ApplyResources(this.flpUtakmice, "flpUtakmice");
            this.flpUtakmice.Name = "flpUtakmice";
            // 
            // lblNajviseGolova
            // 
            resources.ApplyResources(this.lblNajviseGolova, "lblNajviseGolova");
            this.lblNajviseGolova.Name = "lblNajviseGolova";
            // 
            // lblNajviseZutih
            // 
            resources.ApplyResources(this.lblNajviseZutih, "lblNajviseZutih");
            this.lblNajviseZutih.Name = "lblNajviseZutih";
            // 
            // lblUtakmice
            // 
            resources.ApplyResources(this.lblUtakmice, "lblUtakmice");
            this.lblUtakmice.Name = "lblUtakmice";
            // 
            // btnIzlaz
            // 
            resources.ApplyResources(this.btnIzlaz, "btnIzlaz");
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.UseVisualStyleBackColor = true;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPostavke
            // 
            resources.ApplyResources(this.btnPostavke, "btnPostavke");
            this.btnPostavke.Name = "btnPostavke";
            this.btnPostavke.UseVisualStyleBackColor = true;
            this.btnPostavke.Click += new System.EventHandler(this.btnPostavke_Click);
            // 
            // lblUcitavanje
            // 
            resources.ApplyResources(this.lblUcitavanje, "lblUcitavanje");
            this.lblUcitavanje.Name = "lblUcitavanje";
            // 
            // printDocument
            // 
            this.printDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument_EndPrint);
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // RangListaForma
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUcitavanje);
            this.Controls.Add(this.btnPostavke);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.lblUtakmice);
            this.Controls.Add(this.lblNajviseZutih);
            this.Controls.Add(this.lblNajviseGolova);
            this.Controls.Add(this.flpUtakmice);
            this.Controls.Add(this.flpIgraciZutiKartoni);
            this.Controls.Add(this.flpIgraciGolovi);
            this.Name = "RangListaForma";
            this.Load += new System.EventHandler(this.RangListaForma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpIgraciGolovi;
        private System.Windows.Forms.FlowLayoutPanel flpIgraciZutiKartoni;
        private System.Windows.Forms.FlowLayoutPanel flpUtakmice;
        private System.Windows.Forms.Label lblNajviseGolova;
        private System.Windows.Forms.Label lblNajviseZutih;
        private System.Windows.Forms.Label lblUtakmice;
        private System.Windows.Forms.Button btnIzlaz;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPostavke;
        private System.Windows.Forms.Label lblUcitavanje;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintDialog printDialog;
    }
}