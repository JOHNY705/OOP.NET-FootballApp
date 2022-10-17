using OOP.net_projekt.Forms;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OOP.net_projekt
{
    public partial class Lokalizacija : Form
    {
        private const string datotekaJezika = "../../../TekstualneDatoteke/PostavkeJezika.txt";

        public Lokalizacija()
        {
            InitializeComponent();
            var kultura = PodatkovniSloj.Repozitorij.UcitajPostavkeJezika(datotekaJezika);
            if (kultura == "en" || kultura =="hr")
            {
                SetCulture(kultura);
                this.Hide();
                new OdabirPrvenstvaForma().ShowDialog();
                this.Dispose();
            }
        }

        public void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

            foreach (Control kontrola in Controls)
            {
                var resursi = new ComponentResourceManager(typeof(Lokalizacija));
                resursi.ApplyResources(kontrola, kontrola.Name, new CultureInfo(culture));
            }
        }

        private void btnHrvatski_Click(object sender, EventArgs e)
        {
            SetCulture("hr");
            btnDalje.Enabled = true;
        }

        private void btnEngleski_Click(object sender, EventArgs e)
        {
            SetCulture("en");
            btnDalje.Enabled = true;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDalje_Click(object sender, EventArgs e)
        {
            PodatkovniSloj.Repozitorij.SpremiPostavkeJezika(datotekaJezika);
            this.Hide();
            new OdabirPrvenstvaForma().ShowDialog();
            this.Close();
        }

        private void Lokalizacija_Load(object sender, EventArgs e)
        {
            var kultura = PodatkovniSloj.Repozitorij.UcitajPostavkeJezika(datotekaJezika);
            SetCulture(kultura);
        }
    }
}
