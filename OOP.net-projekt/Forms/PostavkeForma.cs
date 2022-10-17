using OOP.net_projekt.Resources;
using PodatkovniSloj;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OOP.net_projekt.Forms
{
    public partial class PostavkeForma : Form
    {
        private const string datotekaJezika = "../../../TekstualneDatoteke/PostavkeJezika.txt";
        private const string datotekaPrvenstva = "../../../TekstualneDatoteke/PostavkePrvenstva.txt";
        string odabranoPrvenstvo;
        public PostavkeForma()
        {
            InitializeComponent();
        }

        private void btnHrvatski_Click(object sender, EventArgs e)
        {
            SetCulture("hr");
            DohvatiLabeluOdabranoPrvenstvo();
        }

        private void DohvatiLabeluOdabranoPrvenstvo()
        {
            if (odabranoPrvenstvo == "Male" || odabranoPrvenstvo == "Muško prvenstvo")
            {
                lblIspisOdabiraPrvenstva.Text += " " + MojiResursi.muskoPrvenstvo;
            }
            else if (odabranoPrvenstvo == "Female" || odabranoPrvenstvo == "Žensko prvenstvo")
            {
                lblIspisOdabiraPrvenstva.Text += " " + MojiResursi.zenskoPrvenstvo;
            }
            else
            {
                lblIspisOdabiraPrvenstva.Text += "";
            }
        }

        private void btnEngleski_Click(object sender, EventArgs e)
        {
            SetCulture("en");
            DohvatiLabeluOdabranoPrvenstvo();
        }

        public void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            foreach (Control kontrola in Controls)
            {
                var resursi = new ComponentResourceManager(typeof(PostavkeForma));
                resursi.ApplyResources(kontrola, kontrola.Name, new CultureInfo(culture));
            }
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            Repozitorij.SpremiPostavkeJezika(datotekaJezika);
            Repozitorij.SpremiPostavkePrvenstva(datotekaPrvenstva, odabranoPrvenstvo);
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
         
        }

        private void PostavkeForma_Load(object sender, EventArgs e)
        {
            odabranoPrvenstvo = Repozitorij.UcitajPostavkePrvenstva(datotekaPrvenstva);
            DohvatiLabeluOdabranoPrvenstvo();
        }

        private void btnMuskoPrvenstvo_Click(object sender, EventArgs e)
        {
            //lblIspisOdabiraPrvenstva.Text = lblIspisOdabiraPrvenstva.Text.ToString().Substring(0, lblIspisOdabiraPrvenstva.Text.LastIndexOf(':') + 2);
            lblIspisOdabiraPrvenstva.Text = Repozitorij.StringCutter(lblIspisOdabiraPrvenstva.Text);
            lblIspisOdabiraPrvenstva.Text += MojiResursi.muskoPrvenstvo;
            odabranoPrvenstvo = "Muško prvenstvo";
        }

        private void btnZenskoPrvenstvo_Click(object sender, EventArgs e)
        {
            //lblIspisOdabiraPrvenstva.Text = lblIspisOdabiraPrvenstva.Text.ToString().Substring(0, lblIspisOdabiraPrvenstva.Text.LastIndexOf(':') + 2);
            lblIspisOdabiraPrvenstva.Text = Repozitorij.StringCutter(lblIspisOdabiraPrvenstva.Text);
            lblIspisOdabiraPrvenstva.Text += MojiResursi.zenskoPrvenstvo;
            odabranoPrvenstvo = "Žensko prvenstvo";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                btnPotvrdi.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Escape))
            {
                btnOdustani.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
