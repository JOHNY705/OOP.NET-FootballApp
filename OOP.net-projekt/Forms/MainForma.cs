using OOP.net_projekt.Models;
using OOP.net_projekt.Resources;
using OOP.net_projekt.UserControls;
using PodatkovniSloj;
using PodatkovniSloj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace OOP.net_projekt.Forms
{
    public partial class MainForma : Form
    {
        private const string postavkePrvenstva = "../../../TekstualneDatoteke/PostavkePrvenstva.txt";
        private const string postavkeNajdraziTim = "../../../TekstualneDatoteke/PostavkeNajdraziTim.txt";
        private const string postavkeJezika = "../../../TekstualneDatoteke/PostavkeJezika.txt";
        private const string igraciDatoteka = "../../../TekstualneDatoteke/IgraciNajdraziTim.txt";
        private const string linkDatoteka = "../../../TekstualneDatoteke/PostavkeLinkZaDohvacanje.txt";
        private string trenutnoPrvenstvo;
        private string trenutnaKultura;
        private UserControlIgrac oznaceniIgrac;

        public MainForma()
        {
            InitializeComponent();
        }

        private void MainForma_Load(object sender, EventArgs e)
        {
            var odabranoPrvenstvo = Repozitorij.UcitajPostavkePrvenstva(postavkePrvenstva);
            trenutnoPrvenstvo = odabranoPrvenstvo;
            trenutnaKultura = Repozitorij.UcitajPostavkeJezika(postavkeJezika);
            NapuniComboBoxTimovi(cbTimovi, odabranoPrvenstvo);
            if (File.Exists(igraciDatoteka))
            {
                UcitavanjeIgracaIzDatoteke(igraciDatoteka);
                btnRankLista.Enabled = true;
            }
        }

        private void UcitavanjeIgracaIzDatoteke(string igraciDatoteka)
        {
            lblStatus.Text = MojiResursi.ucitavanjePoruka;
            var igraci = Repozitorij.UcitavanjeIgracaIzDatoteke(igraciDatoteka);
            foreach (var igrac in igraci)
            {
                var dodaniIgrac = new UserControlIgrac(igrac.Name, igrac.Position, igrac.ShirtNumber, igrac.Captain, igrac.Najdrazi, igrac.SlikaIgraca);
                dodaniIgrac.ContextMenuStrip = contextMenuIgraci;
                dodaniIgrac.SlikaIgraca.Tag = igrac.SlikaIgraca;
                if (igrac.Najdrazi)
                {
                    flpNajdraziIgraci.Controls.Add(dodaniIgrac);
                }
                else
                {
                    flpIgraci.Controls.Add(dodaniIgrac);
                }
            }
            lblStatus.Text = "";
        }

        private static async void NapuniComboBoxTimovi(ComboBox cbTimovi, string odabranoPrvenstvo)
        {
            var podaci = await Repozitorij.GetComboBoxTimovi(odabranoPrvenstvo);
            foreach (var team in podaci)
            {
                cbTimovi.Items.Add(team);
            }
        }

        private static async void NapuniFlpIgraci(FlowLayoutPanel flpIgraci, FlowLayoutPanel flpNajdraziIgraci, string linkZaDohvacanje, string najdraziTim, ContextMenuStrip contextMenuIgraci, Label lblStatus, string linkDatoteka)
        {
            flpIgraci.Controls.Clear();
            flpNajdraziIgraci.Controls.Clear();
            lblStatus.Text = MojiResursi.ucitavanjePoruka;
            var podaci = await Repozitorij.GetMatches(linkZaDohvacanje);
            Repozitorij.SpremiStringUDatoteku(linkDatoteka, linkZaDohvacanje);
            List<Match> listaUtakmica = podaci;
            List<Player> listaIgraca = Repozitorij.GetIgraciFromUtakmica(listaUtakmica, najdraziTim);
            foreach (var igrac in listaIgraca)
            {
                var dodaniIgrac = new UserControlIgrac(igrac.Name, igrac.Position, igrac.ShirtNumber, igrac.Captain);
                dodaniIgrac.ContextMenuStrip = contextMenuIgraci;
                flpIgraci.Controls.Add(dodaniIgrac);
            }
            lblStatus.Text = "";
        }


        private void flpNajdraziIgrac_DragDrop(object sender, DragEventArgs e)
        {
            if (flpNajdraziIgraci.Controls.Count == 3)
            {
                IspisGreske();
                return;
            }
            var igrac = sender as UserControlIgrac;
            var noviIgrac = (UserControlIgrac)e.Data.GetData(typeof(UserControlIgrac));
            flpNajdraziIgraci.Controls.Add(noviIgrac);
            noviIgrac.NajdraziIgrac.Image = Slike.goldenstar;
        }
        //poruka za prekoracenje limita od 3 igraca u flpNajdraziIgraci
        private static void IspisGreske()
        {
            MessageBox.Show(MojiResursi.porukaZaFlpNajdraziIgrac);
        }
        //Drag and Drop
        private void flpNajdraziIgraci_DragEnter(object sender, DragEventArgs e)
        {
            var igrac = sender as UserControlIgrac;
            e.Effect = DragDropEffects.Move;
        }

        private void flpIgraci_DragEnter(object sender, DragEventArgs e)
        {
            var igrac = sender as UserControlIgrac;
            e.Effect = DragDropEffects.Move;
        }

        private void flpIgraci_DragDrop(object sender, DragEventArgs e)
        {
            var igrac = sender as UserControlIgrac;
            var noviIgrac = (UserControlIgrac)e.Data.GetData(typeof(UserControlIgrac));
            flpIgraci.Controls.Add(noviIgrac);
            noviIgrac.NajdraziIgrac.Image = null;
        }

        private void prebaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (oznaceniIgrac == null)
            {
                return;
            }
            if (flpIgraci.Contains(oznaceniIgrac))
            {
                if (flpNajdraziIgraci.Controls.Count < 3)
                {
                    flpNajdraziIgraci.Controls.Add(oznaceniIgrac);
                    oznaceniIgrac.NajdraziIgrac.Image = Slike.goldenstar;
                    flpIgraci.Controls.Remove(oznaceniIgrac);
                    oznaceniIgrac.BorderStyle = BorderStyle.None;
                }
                else
                {
                    IspisGreske();
                    return;
                }
            }
            else
            {
                flpIgraci.Controls.Add(oznaceniIgrac);
                oznaceniIgrac.NajdraziIgrac.Image = null;
                flpNajdraziIgraci.Controls.Remove(oznaceniIgrac);
                oznaceniIgrac.BorderStyle = BorderStyle.None;
            }
        }

        private void contextMenuIgraci_Opened(object sender, EventArgs e)
        {
            if (oznaceniIgrac != null)
            {
                //vracanje na default
                oznaceniIgrac.BorderStyle = BorderStyle.None;
            }

            var igrac = (sender as ContextMenuStrip).SourceControl as UserControlIgrac;
            igrac.BorderStyle = BorderStyle.FixedSingle;
            oznaceniIgrac = igrac;
        }

        private void contextMenuIgraci_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            var igrac = (sender as ContextMenuStrip).SourceControl as UserControlIgrac;
            igrac.BorderStyle = BorderStyle.FixedSingle;
        }

        private void btnPostavke_Click(object sender, EventArgs e)
        {
            var postavke = new PostavkeForma();
            if (postavke.ShowDialog() == DialogResult.OK)
            {
                var novaKultura = Repozitorij.UcitajPostavkeJezika(postavkeJezika);
                SetCulture(novaKultura);
                //provjera kulture i ponovno ucitavanje iz datotekeIgraci
                if (novaKultura != trenutnaKultura)
                {
                    flpIgraci.Controls.Clear();
                    flpNajdraziIgraci.Controls.Clear();
                    UcitavanjeIgracaIzDatoteke(igraciDatoteka);
                }
                trenutnaKultura = novaKultura;
                var novoPrvenstvo = Repozitorij.UcitajPostavkePrvenstva(postavkePrvenstva);
                if (trenutnoPrvenstvo != novoPrvenstvo)
                {
                    if (novoPrvenstvo != trenutnoPrvenstvo)
                    {
                        MijenjanjePostavkiForme(novoPrvenstvo);
                    }
                    else
                    {
                        MijenjanjePostavkiForme(novoPrvenstvo);
                        //OcistiKontrole();
                        //NapuniComboBoxTimovi(cbTimovi, novoPrvenstvo);
                        //Repozitorij.SpremiPostavkeTima(postavkeNajdraziTim, "");
                        //trenutnoPrvenstvo = novoPrvenstvo;
                    }
                }
                if (ProvjeraIgracaZaRankListu())
                {
                    btnRankLista.Enabled = true;
                }
            }
        }

        private void MijenjanjePostavkiForme(string novoPrvenstvo)
        {
            OcistiKontrole();
            NapuniComboBoxTimovi(cbTimovi, novoPrvenstvo);
            Repozitorij.SpremiPostavkeTima(postavkeNajdraziTim, "");
            trenutnoPrvenstvo = novoPrvenstvo;
        }

        private void OcistiKontrole()
        {
            cbTimovi.Items.Clear();
            flpIgraci.Controls.Clear();
            flpNajdraziIgraci.Controls.Clear();
        }

        private bool ProvjeraIgracaZaRankListu()
        {
            if (flpIgraci.Controls.Count == 0)
            {
                return false;
            }
            return true;
        }

        public void SetCulture(string kultura)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(kultura);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(kultura);

            foreach (Control kontrola in Controls)
            {
                var resursi = new ComponentResourceManager(typeof(MainForma));
                resursi.ApplyResources(kontrola, kontrola.Name, new CultureInfo(kultura));
            }
        }

        private void cbTimovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            var najdraziTim = cbTimovi.SelectedItem.ToString().Substring(cbTimovi.SelectedItem.ToString().LastIndexOf('(') + 1, 3);
            var odabranoPrvenstvo = Repozitorij.UcitajPostavkePrvenstva(postavkePrvenstva);
            string linkZaDohvacanje = Repozitorij.GetLinkZaDohvacanje(odabranoPrvenstvo, najdraziTim);
            Repozitorij.SpremiPostavkeTima(postavkeNajdraziTim, najdraziTim);
            NapuniFlpIgraci(flpIgraci, flpNajdraziIgraci, linkZaDohvacanje, najdraziTim, contextMenuIgraci, lblStatus, linkDatoteka);
            btnRankLista.Enabled = true;
        }

        private void promijeniSlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Slike|*.bmp;*jpg;*.jpeg;*.png|Sve ostalo|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PrikaziSliku(ofd.FileName);
            }
        }

        private void PrikaziSliku(string putanja)
        {
            oznaceniIgrac.SlikaIgraca.Image = Repozitorij.GetSlika(putanja);
            oznaceniIgrac.SlikaIgraca.Tag = putanja;
        }

        private void btnRankLista_Click(object sender, EventArgs e)
        {
            SpremanjeIgracaUDatoteku();
            this.Hide();
            var form = new RangListaForma();
            form.Closed += (s, args) => this.Close();
            form.ShowDialog();
        }

        private void SpremanjeIgracaUDatoteku()
        {
            List<Player> igraci = new List<Player>();
            foreach (UserControlIgrac igrac in flpIgraci.Controls)
            {
                Player player = new Player
                {
                    Name = igrac.NazivIgraca,
                    Captain = igrac.Kapetan,
                    Position = igrac.Pozicija,
                    ShirtNumber = igrac.Broj,
                    Najdrazi = false,
                    SlikaIgraca = igrac.SlikaIgraca.Tag + string.Empty
                };
                igraci.Add(player);
            }
            if (flpNajdraziIgraci.Controls.Count != 0)
            {
                foreach (UserControlIgrac igrac in flpNajdraziIgraci.Controls)
                {
                    Player player = new Player
                    {
                        Name = igrac.NazivIgraca,
                        Captain = igrac.Kapetan,
                        Position = igrac.Pozicija,
                        ShirtNumber = igrac.Broj,
                        Najdrazi = true,
                        SlikaIgraca = igrac.SlikaIgraca.Tag + string.Empty
                    };
                    igraci.Add(player);
                }
            }
            Repozitorij.SpremiIgraceUDatoteku(igraciDatoteka, igraci);
        }
    }
}
