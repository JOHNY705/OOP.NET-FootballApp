using System;
using System.Windows.Forms;

namespace OOP.net_projekt.Forms
{
    public partial class OdabirPrvenstvaForma : Form
    {
        private string postavkePrvenstvo = "../../../TekstualneDatoteke/PostavkePrvenstva.txt";

        public OdabirPrvenstvaForma()
        {
            InitializeComponent();
            var odabranoPrvenstvo = PodatkovniSloj.Repozitorij.UcitajPostavkePrvenstva(postavkePrvenstvo);
            if (odabranoPrvenstvo.ToString().Trim().Length != 0)
            {
                this.Hide();
                new MainForma().ShowDialog();
                this.Close();
            }
        }

        private void btnMusko_Click(object sender, EventArgs e)
        {
            OdabirPrvenstvaIspisULabel(btnMusko.Text, sender);
            btnZensko.Enabled = true;
        }

        private void OdabirPrvenstvaIspisULabel(string prvenstvo, object sender)
        {
            btnDalje.Enabled = true;
            lblOdabir.Text = lblOdabir.Text.ToString().Substring(0, lblOdabir.Text.LastIndexOf(':') + 1);
            lblOdabir.Text += " " + prvenstvo;
            var gumb = sender as Button;
            gumb.Enabled = false;
        }

        private void btnZensko_Click(object sender, EventArgs e)
        {
            OdabirPrvenstvaIspisULabel(btnZensko.Text, sender);
            btnMusko.Enabled = true;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDalje_Click(object sender, EventArgs e)
        {
            var odabirPrvenstva = lblOdabir.Text.ToString().Substring(lblOdabir.Text.IndexOf(':') + 2);
            PodatkovniSloj.Repozitorij.SpremiPostavkePrvenstva(postavkePrvenstvo, odabirPrvenstva);
            this.Hide();
            new MainForma().ShowDialog();
            this.Close();
        }

        private void OdabirPrvenstvaForma_Load(object sender, EventArgs e)
        {
            PodatkovniSloj.Repozitorij.UcitajPostavkePrvenstva(postavkePrvenstvo);
        }
    }
}
