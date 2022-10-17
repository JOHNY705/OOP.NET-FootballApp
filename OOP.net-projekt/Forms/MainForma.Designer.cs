namespace OOP.net_projekt.Forms
{
    partial class MainForma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForma));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPostavke = new System.Windows.Forms.Button();
            this.flpNajdraziIgraci = new System.Windows.Forms.FlowLayoutPanel();
            this.flpIgraci = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuIgraci = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.prebaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promijeniSlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRankLista = new System.Windows.Forms.Button();
            this.cbTimovi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuIgraci.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnPostavke
            // 
            resources.ApplyResources(this.btnPostavke, "btnPostavke");
            this.btnPostavke.Name = "btnPostavke";
            this.btnPostavke.UseVisualStyleBackColor = true;
            this.btnPostavke.Click += new System.EventHandler(this.btnPostavke_Click);
            // 
            // flpNajdraziIgraci
            // 
            resources.ApplyResources(this.flpNajdraziIgraci, "flpNajdraziIgraci");
            this.flpNajdraziIgraci.AllowDrop = true;
            this.flpNajdraziIgraci.Name = "flpNajdraziIgraci";
            this.flpNajdraziIgraci.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpNajdraziIgrac_DragDrop);
            this.flpNajdraziIgraci.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpNajdraziIgraci_DragEnter);
            // 
            // flpIgraci
            // 
            resources.ApplyResources(this.flpIgraci, "flpIgraci");
            this.flpIgraci.AllowDrop = true;
            this.flpIgraci.Name = "flpIgraci";
            this.flpIgraci.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpIgraci_DragDrop);
            this.flpIgraci.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpIgraci_DragEnter);
            // 
            // contextMenuIgraci
            // 
            resources.ApplyResources(this.contextMenuIgraci, "contextMenuIgraci");
            this.contextMenuIgraci.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prebaciToolStripMenuItem,
            this.promijeniSlikuToolStripMenuItem});
            this.contextMenuIgraci.Name = "contextMenuIgraci";
            this.contextMenuIgraci.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuIgraci_Closed);
            this.contextMenuIgraci.Opened += new System.EventHandler(this.contextMenuIgraci_Opened);
            // 
            // prebaciToolStripMenuItem
            // 
            resources.ApplyResources(this.prebaciToolStripMenuItem, "prebaciToolStripMenuItem");
            this.prebaciToolStripMenuItem.Name = "prebaciToolStripMenuItem";
            this.prebaciToolStripMenuItem.Click += new System.EventHandler(this.prebaciToolStripMenuItem_Click);
            // 
            // promijeniSlikuToolStripMenuItem
            // 
            resources.ApplyResources(this.promijeniSlikuToolStripMenuItem, "promijeniSlikuToolStripMenuItem");
            this.promijeniSlikuToolStripMenuItem.Name = "promijeniSlikuToolStripMenuItem";
            this.promijeniSlikuToolStripMenuItem.Click += new System.EventHandler(this.promijeniSlikuToolStripMenuItem_Click);
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // btnRankLista
            // 
            resources.ApplyResources(this.btnRankLista, "btnRankLista");
            this.btnRankLista.Name = "btnRankLista";
            this.btnRankLista.UseVisualStyleBackColor = true;
            this.btnRankLista.Click += new System.EventHandler(this.btnRankLista_Click);
            // 
            // cbTimovi
            // 
            resources.ApplyResources(this.cbTimovi, "cbTimovi");
            this.cbTimovi.FormattingEnabled = true;
            this.cbTimovi.Name = "cbTimovi";
            this.cbTimovi.SelectedIndexChanged += new System.EventHandler(this.cbTimovi_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // MainForma
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTimovi);
            this.Controls.Add(this.btnRankLista);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.flpIgraci);
            this.Controls.Add(this.flpNajdraziIgraci);
            this.Controls.Add(this.btnPostavke);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForma";
            this.Load += new System.EventHandler(this.MainForma_Load);
            this.contextMenuIgraci.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPostavke;
        private System.Windows.Forms.FlowLayoutPanel flpNajdraziIgraci;
        private System.Windows.Forms.FlowLayoutPanel flpIgraci;
        private System.Windows.Forms.ContextMenuStrip contextMenuIgraci;
        private System.Windows.Forms.ToolStripMenuItem prebaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promijeniSlikuToolStripMenuItem;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRankLista;
        private System.Windows.Forms.ComboBox cbTimovi;
        private System.Windows.Forms.Label label3;
    }
}