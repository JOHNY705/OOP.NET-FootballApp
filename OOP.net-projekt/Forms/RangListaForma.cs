using OOP.net_projekt.Models;
using OOP.net_projekt.Resources;
using OOP.net_projekt.UserControls;
using PodatkovniSloj;
using PodatkovniSloj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OOP.net_projekt.Forms
{
    public partial class RangListaForma : Form
    {
        private const string postavkePrvenstva = "../../../TekstualneDatoteke/PostavkePrvenstva.txt";
        private const string postavkeNajdraziTim = "../../../TekstualneDatoteke/PostavkeNajdraziTim.txt";
        private const string postavkeJezika = "../../../TekstualneDatoteke/PostavkeJezika.txt";
        private const string igraciDatoteka = "../../../TekstualneDatoteke/IgraciNajdraziTim.txt";
        private const string postavkeLink = "../../../TekstualneDatoteke/PostavkeLinkZaDohvacanje.txt";
        private string trenutnaKultura;
        private string linkZaDohvacanje;
        private string najdraziTim;
        private List<Match> listaUtakmica;
        private List<TeamEvent> listaDogadaja;
        private List<UserControlRangKartoni> listaIgracaKartoni;
        private List<UserControlRangGolovi> listaIgracaGolovi;
        private List<UserControlUtakmice> listaUserControlUtakmica;
        public RangListaForma()
        {
            InitializeComponent();
        }

        private void RangListaForma_Load(object sender, EventArgs e)
        {
            linkZaDohvacanje = Repozitorij.UcitajStringIzDatoteke(postavkeLink);
            najdraziTim = Repozitorij.UcitajPostavkeTima(postavkeNajdraziTim);
            trenutnaKultura = Repozitorij.UcitajPostavkeJezika(postavkeJezika);
            
            listaUserControlUtakmica = new List<UserControlUtakmice>();
            listaIgracaKartoni = UcitajIgraceKartoni(igraciDatoteka);
            listaIgracaGolovi = UcitajIgraceGolovi(igraciDatoteka);
            
            NapuniListuUtakmica(linkZaDohvacanje, listaUtakmica, najdraziTim, listaDogadaja, listaIgracaKartoni, 
                listaIgracaGolovi, listaUserControlUtakmica, flpIgraciGolovi, flpIgraciZutiKartoni, flpUtakmice, lblUcitavanje);
        }

        private List<UserControlRangGolovi> UcitajIgraceGolovi(string igraciDatoteka)
        {
            List<UserControlRangGolovi> igraciListaGolovi = new List<UserControlRangGolovi>();
            var igraci = Repozitorij.UcitavanjeIgracaIzDatoteke(igraciDatoteka);
            foreach (var igrac in igraci)
            {
                var dodaniIgracGol = new UserControlRangGolovi(igrac.Name, igrac.Najdrazi, igrac.SlikaIgraca);
                igraciListaGolovi.Add(dodaniIgracGol);
            }
            return igraciListaGolovi;
        }

        private List<UserControlRangKartoni> UcitajIgraceKartoni(string igraciDatoteka)
        {
            List<UserControlRangKartoni> igraciListaKartoni = new List<UserControlRangKartoni>();
            var igraci = Repozitorij.UcitavanjeIgracaIzDatoteke(igraciDatoteka);
            foreach (var igrac in igraci)
            {
                var dodaniIgracKarton = new UserControlRangKartoni(igrac.Name, igrac.Najdrazi, igrac.SlikaIgraca);
                igraciListaKartoni.Add(dodaniIgracKarton);
            }
            return igraciListaKartoni;
        }

        private static async void NapuniListuUtakmica(string linkZaDohvacanje, List<Match> listaUtakmica, string najdraziTim, List<TeamEvent> listaDogadaja, 
            List<UserControlRangKartoni> igraciListaKartoni, List<UserControlRangGolovi> igraciListaGolovi, List<UserControlUtakmice> listaUserControlUtakmica,
            FlowLayoutPanel flpIgraciGolovi, FlowLayoutPanel flpIgraciZutiKartoni, FlowLayoutPanel flpUtakmice, Label lblUcitavanje)
        {
            listaUtakmica = await Repozitorij.GetMatches(linkZaDohvacanje);
            UcitajUserControlUtakmice(listaUtakmica, listaUserControlUtakmica, flpUtakmice);
            listaDogadaja = Repozitorij.UcitajEventeIzUtakmica(listaUtakmica, najdraziTim);
            UcitajEventeUIgrace(igraciListaKartoni, igraciListaGolovi, listaDogadaja, flpIgraciGolovi, flpIgraciZutiKartoni);
            lblUcitavanje.Text = "";
        }

        private static void UcitajUserControlUtakmice(List<Match> listaUtakmica, List<UserControlUtakmice> listaUserControlUtakmica, FlowLayoutPanel flpUtakmice)
        {
            foreach (var utakmica in listaUtakmica)
            {
                var ucitanaUtakmica = new UserControlUtakmice(utakmica.HomeTeamCountry, utakmica.AwayTeamCountry, utakmica.Venue, utakmica.Attendance);
                listaUserControlUtakmica.Add(ucitanaUtakmica);
            }
            
            listaUserControlUtakmica.Sort();

            foreach (var utakmica in listaUserControlUtakmica)
            {
                flpUtakmice.Controls.Add(utakmica);
            }
        }

        private static void UcitajEventeUIgrace(List<UserControlRangKartoni> igraciListaKartoni, List<UserControlRangGolovi> igraciListaGolovi, List<TeamEvent> listaDogadaja, 
            FlowLayoutPanel flpIgraciGolovi, FlowLayoutPanel flpIgraciZutiKartoni)
        {
            for (int i = 0; i < igraciListaKartoni.Count; i++)
            {
                int brojacZutihKartona = 0;
                for (int j = 0; j < listaDogadaja.Count; j++)
                {
                    if (listaDogadaja[j].Player == igraciListaKartoni[i].NazivIgraca && listaDogadaja[j].TypeOfEvent == "yellow-card")
                    {
                        brojacZutihKartona++;
                    }
                }
                igraciListaKartoni[i].BrojZutihKartona = brojacZutihKartona;
            }

            for (int i = 0; i < igraciListaGolovi.Count; i++)
            {
                int brojacGolova = 0;
                for (int j = 0; j < listaDogadaja.Count; j++)
                {
                    if (listaDogadaja[j].Player == igraciListaGolovi[i].NazivIgraca && listaDogadaja[j].TypeOfEvent == "goal")
                    {
                        brojacGolova++;
                    }
                    else if (listaDogadaja[j].Player == igraciListaGolovi[i].NazivIgraca && listaDogadaja[j].TypeOfEvent == "goal-penalty")
                    {
                        brojacGolova++;
                    }
                }
                igraciListaGolovi[i].BrojGolova = brojacGolova;
            }

            igraciListaKartoni.Sort();
            igraciListaGolovi.Sort();

            foreach (var igrac in igraciListaKartoni)
            {
                flpIgraciZutiKartoni.Controls.Add(igrac);
            }

            foreach (var igrac in igraciListaGolovi)
            {
                flpIgraciGolovi.Controls.Add(igrac);
            }
        }

        private void btnPostavke_Click(object sender, EventArgs e)
        {
            var postavke = new PostavkeForma();
            if (postavke.ShowDialog() == DialogResult.OK)
            {
                var novaKultura = Repozitorij.UcitajPostavkeJezika(postavkeJezika);
                SetCulture(novaKultura);

                if (novaKultura != trenutnaKultura)
                {
                    //flpIgraciGolovi.Controls.Clear();
                    //flpIgraciZutiKartoni.Controls.Clear();
                    //flpUtakmice.Controls.Clear();

                    foreach (var igrac in listaIgracaGolovi)
                    {
                        igrac.GoloviLabela.Text = "";
                        igrac.GoloviLabela.Text = MojiResursi.goloviLabela;
                    }

                    foreach (var igrac in listaIgracaKartoni)
                    {
                        igrac.KartoniLabela.Text = "";
                        igrac.KartoniLabela.Text = MojiResursi.kartoniLabela;
                    }

                    foreach (var utakmica in listaUserControlUtakmica)
                    {
                        utakmica.DomacinLabel.Text = "";
                        utakmica.DomacinLabel.Text = MojiResursi.utakmicaUCDomacin;

                        utakmica.GostLabel.Text = "";
                        utakmica.GostLabel.Text = MojiResursi.utakmicaUCGost;

                        utakmica.LokacijaLabel.Text = "";
                        utakmica.LokacijaLabel.Text = MojiResursi.utakmicaUCLokacija;

                        utakmica.PosjetiteljiLabel.Text = "";
                        utakmica.PosjetiteljiLabel.Text = MojiResursi.utakmicaUCPosjetitelji;
                    }

                //NapuniListuUtakmica(linkZaDohvacanje, listaUtakmica, najdraziTim, listaDogadaja, listaIgracaKartoni,
                //listaIgracaGolovi, listaUserControlUtakmica, flpIgraciGolovi, flpIgraciZutiKartoni, flpUtakmice, lblUcitavanje);
                }
                trenutnaKultura = novaKultura;
            }
            lblUcitavanje.Text = "";
        }

        private void SetCulture(string kultura)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(kultura);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(kultura);

            foreach (Control kontrola in Controls)
            {
                var resursi = new ComponentResourceManager(typeof(RangListaForma));
                resursi.ApplyResources(kontrola, kontrola.Name, new CultureInfo(kultura));
            }
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            new IzlazForma().ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var x = 40;
            var y = 30;

            var fontNaslov = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            var fontZaUserControle = new Font("Arial", 11, FontStyle.Bold, GraphicsUnit.Pixel);

            e.Graphics.DrawString(lblNajviseGolova.Text, fontNaslov, Brushes.Black, 20, 8);        

            foreach (var igrac in listaIgracaGolovi)
            {
                Bitmap slikaZaIgraca = new Bitmap(igrac.SlikaIgraca);
                var novaSlikaZaIgraca = ResizeBitmap(slikaZaIgraca, 42, 42);
                e.Graphics.DrawImage(novaSlikaZaIgraca, x, y + 2);

                if (igrac.NajdraziIgrac != null)
                {
                    Bitmap slikaZaNajdraziIgrac = new Bitmap(Slike.goldenstar);
                    var novaSlikaZaNajdraziIgrac = ResizeBitmap(slikaZaNajdraziIgrac, 15, 15);
                    e.Graphics.DrawImage(novaSlikaZaNajdraziIgrac, 20, y);
                }

                e.Graphics.DrawString(igrac.NazivIgraca, fontZaUserControle, Brushes.Black, x + novaSlikaZaIgraca.Width + 5, y + 3);
                e.Graphics.DrawString(igrac.GoloviLabela.Text + " " + igrac.BrojGolova.ToString(), fontZaUserControle, Brushes.Black, x + novaSlikaZaIgraca.Width + 5, y + 28);
                e.Graphics.DrawLine(Pens.Black, 20, y, 250, y);

                y += 48;
            }

            e.Graphics.DrawString(lblNajviseZutih.Text, fontNaslov, Brushes.Black, 285, 8);

            x = 300;
            y = 30;

            foreach (var igrac in listaIgracaKartoni)
            {
                Bitmap slikaZaIgraca = new Bitmap(igrac.SlikaIgraca);
                var novaSlikaZaIgraca = ResizeBitmap(slikaZaIgraca, 42, 42);
                e.Graphics.DrawImage(novaSlikaZaIgraca, x, y + 2);

                if (igrac.NajdraziIgrac != null)
                {
                    Bitmap slikaZaNajdraziIgrac = new Bitmap(Slike.goldenstar);
                    var novaSlikaZaNajdraziIgrac = ResizeBitmap(slikaZaNajdraziIgrac, 15, 15);
                    e.Graphics.DrawImage(novaSlikaZaNajdraziIgrac, x - 20, y);
                }

                e.Graphics.DrawString(igrac.NazivIgraca, fontZaUserControle, Brushes.Black, x + novaSlikaZaIgraca.Width + 5, y + 3);
                e.Graphics.DrawString(igrac.KartoniLabela.Text + " " + igrac.BrojZutihKartona.ToString(), fontZaUserControle, Brushes.Black, x + novaSlikaZaIgraca.Width + 5, y + 28);
                e.Graphics.DrawLine(Pens.Black, 280, y, 510, y);

                y += 48;
            }

            e.Graphics.DrawString(lblUtakmice.Text, fontNaslov, Brushes.Black, 550, 8);

            x = 550;
            y = 30;

            foreach (var utakmica in listaUserControlUtakmica)
            {
                Bitmap slikaStadion = new Bitmap(utakmica.SlikaStadiona);
                var novaSlikaStadion = ResizeBitmap(slikaStadion, 68, 60);
                e.Graphics.DrawImage(novaSlikaStadion, x, y + 2);

                e.Graphics.DrawString(utakmica.LokacijaLabel.Text + " " + utakmica.Lokacija, fontZaUserControle, Brushes.Black, x + novaSlikaStadion.Width + 5, y + 8);
                e.Graphics.DrawString(utakmica.DomacinLabel.Text + " " + utakmica.DomaciTim, fontZaUserControle, Brushes.Black, x + novaSlikaStadion.Width + 5, y + 22);
                e.Graphics.DrawString(utakmica.GostLabel.Text + " " + utakmica.GostTim, fontZaUserControle, Brushes.Black, x + novaSlikaStadion.Width + 5, y + 36);
                e.Graphics.DrawString(utakmica.PosjetiteljiLabel.Text + " " + utakmica.BrojPosjetitelja.ToString(), fontZaUserControle, Brushes.Black, x + novaSlikaStadion.Width + 5, y + 50);
                e.Graphics.DrawLine(Pens.Black, 540, y, 770, y);

                y += 80;
            }
        }

        private Bitmap ResizeBitmap(Bitmap bmp, int novaSirina, int novaVisina)
        {
            Bitmap result = new Bitmap(novaSirina, novaVisina);
            using (Graphics g = Graphics.FromImage((Image)result))
                g.DrawImage(bmp, 0, 0, novaSirina, novaVisina);
            return result;
        }

        private void printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            if (e.PrintAction == PrintAction.PrintToPrinter)
            {
                MessageBox.Show(MojiResursi.printanjeZavrsilo);
            }
        }
    }
}
