using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP.net_projekt.Forms
{
    public partial class OdabirNajdrazegTimaForma : Form
    {
        private string postavkePrvenstva = "PostavkePrvenstva.txt";
        private string postavkeNajdraziTim = "PostavkeNajdraziTim.txt";
        public OdabirNajdrazegTimaForma()
        {
            InitializeComponent();
            var najdraziTim = PodatkovniSloj.Repozitorij.UcitajPostavkeTima(postavkeNajdraziTim);
            if (najdraziTim.ToString().Trim().Length != 0)
            {
                this.Hide();
                new MainForma().ShowDialog();
                this.Close();
            }
        }

        private void OdabirNajdrazegTimaForma_Load(object sender, EventArgs e)
        {
            var odabranoPrvenstvo = PodatkovniSloj.Repozitorij.UcitajPostavkePrvenstva(postavkePrvenstva);
            NapuniComboBoxTimovi(cbNajdraziTim, odabranoPrvenstvo);
        }

        private static async void NapuniComboBoxTimovi(ComboBox cbTimovi, string odabranoPrvenstvo)
        {
            var podaci = await PodatkovniSloj.Repozitorij.GetComboBoxTimovi(odabranoPrvenstvo);
            foreach (var team in podaci)
            {
                cbTimovi.Items.Add(team);
            }
        }

        private void btnDalje_Click(object sender, EventArgs e)
        {
            var najdraziTim = cbNajdraziTim.SelectedItem.ToString().Substring(cbNajdraziTim.SelectedItem.ToString().LastIndexOf('(') + 1, 3);
            PodatkovniSloj.Repozitorij.SpremiPostavkeTima(postavkeNajdraziTim, najdraziTim);
            this.Hide();
            new MainForma().ShowDialog();
            this.Close();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbNajdraziTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDalje.Enabled = true;
        }
    }
}
