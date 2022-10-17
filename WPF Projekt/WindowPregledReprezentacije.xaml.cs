using OOP.net_projekt.Models;
using PodatkovniSloj;
using PodatkovniSloj.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WPF_Projekt
{
    /// <summary>
    /// Interaction logic for WindowPregledReprezentacije.xaml
    /// </summary>
    public partial class WindowPregledReprezentacije : Window
    {
        private const string postavkePrvenstvo = "../../../TekstualneDatoteke/PostavkePrvenstva.txt";
        private const string postavkeNajdraziTim = "../../../TekstualneDatoteke/PostavkeNajdraziTim.txt";
        private const string linkDatoteka = "../../../TekstualneDatoteke/PostavkeLinkZaDohvacanje.txt";
        private const string igraciDatoteka = "../../../TekstualneDatoteke/IgraciNajdraziTim.txt";
        private const string postavkeJezika = "../../../TekstualneDatoteke/PostavkeJezika.txt";
        private const string postavkeRezolucija = "../../../TekstualneDatoteke/PostavkeRezolucija.txt";
        private string ucitaniJezik;
        private List<Match> listaUtakmica;
        private List<Team> listaTimova;
        private List<Team> listaProtivnika;
        private string ucitaniNajdraziTim;
        private string trenutniNajdraziTim;
        private string odabranoPrvenstvo;
        private string linkZaDohvacanje;
        private Team najdrazaReprezentacija;
        private Team protivnickaReprezentacija;
        private Match utakmicaIzmeduTimova;
        private List<Player> listaNajdrazihIgraca;

        public WindowPregledReprezentacije()
        {
            ucitaniJezik = Repozitorij.UcitajPostavkeJezika(postavkeJezika);
            SetCulture(ucitaniJezik);
            InitializeComponent();
        }

        public WindowPregledReprezentacije(string rezolucija) : this()
        {
            if (rezolucija == "Fullscreen")
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                string[] podaci = rezolucija.Split('x');
                Width = double.Parse(podaci[0]);
                Height = double.Parse(podaci[1]);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            odabranoPrvenstvo = Repozitorij.UcitajPostavkePrvenstva(postavkePrvenstvo);
            listaTimova = new List<Team>();
            listaProtivnika = new List<Team>();
            listaUtakmica = new List<Match>();
            utakmicaIzmeduTimova = new Match();
            listaNajdrazihIgraca = new List<Player>();
            ucitaniNajdraziTim = Repozitorij.UcitajStringIzDatoteke(postavkeNajdraziTim);

            NapuniComboBoxNajdraziTimovi(cbNajdraziTim, odabranoPrvenstvo, listaTimova, ucitaniNajdraziTim);

            if (File.Exists(igraciDatoteka))
            {
                listaNajdrazihIgraca = Repozitorij.UcitavanjeIgracaIzDatoteke(igraciDatoteka);
            }

            if (File.Exists(linkDatoteka))
            {
                linkZaDohvacanje = Repozitorij.UcitajStringIzDatoteke(linkDatoteka);
            }
        }

        private void SetCulture(string kultura)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(kultura);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(kultura);
        }

        private static async void NapuniComboBoxNajdraziTimovi(ComboBox cbNajdraziTim, string odabranoPrvenstvo, List<Team> listaTimova, string ucitaniNajdraziTim)
        {
            var podaci = await Repozitorij.GetComboBoxTimovi(odabranoPrvenstvo);
            foreach (var team in podaci)
            {
                cbNajdraziTim.Items.Add(team);
                listaTimova.Add(team);
            }

            for (int i = 0; i < listaTimova.Count; i++)
            {
                if (listaTimova[i].ToString().Substring(listaTimova[i].ToString().LastIndexOf('(') + 1, 3) == ucitaniNajdraziTim)
                {
                    cbNajdraziTim.SelectedItem = listaTimova[i];
                }
            }
        }

        private void cbNajdraziTim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            najdraziTimGolman.Children.Clear();
            najdraziTimObrana.Children.Clear();
            najdraziTimVeza.Children.Clear();
            najdraziTimNapad.Children.Clear();

            protivnikTimGolman.Children.Clear();
            protivnikTimObrana.Children.Clear();
            protivnikTimVeza.Children.Clear();
            protivnikTimNapad.Children.Clear();

            if (cbNajdraziTim.SelectedItem == null)
            {
                lblNajdraziTim.Content = Resursi.Stringovi.stringNajdraziTim;
                return;
            }

            lblNajdraziTim.Content = cbNajdraziTim.SelectedItem.ToString();
            var najdraziTim = cbNajdraziTim.SelectedItem.ToString().Substring(cbNajdraziTim.SelectedItem.ToString().LastIndexOf('(') + 1, 3);
            trenutniNajdraziTim = najdraziTim;
            
            for (int i = 0; i < listaTimova.Count; i++)
            {
                if (listaTimova[i].FifaCode == najdraziTim)
                {
                    najdrazaReprezentacija = listaTimova[i];
                }
            }

            btnInfoNajdraziTim.IsEnabled = true;
            cbProtivnickiTim.Items.Clear();
            btnInfoProtivnickiTim.IsEnabled = false;
            lblProtivnickiTim.Content = Resursi.Stringovi.stringProtivnickiTim;
            lblNajdraziTimRezultat.Content = "0";
            lblProtivnickiTimRezultat.Content = "0";

            odabranoPrvenstvo = Repozitorij.UcitajPostavkePrvenstva(postavkePrvenstvo);
            linkZaDohvacanje = Repozitorij.GetLinkZaDohvacanje(odabranoPrvenstvo, najdraziTim);
            Repozitorij.SpremiStringUDatoteku(postavkeNajdraziTim, najdraziTim);

            NapuniListuUtakmica(listaUtakmica, linkZaDohvacanje, najdraziTim, listaProtivnika, listaTimova, cbProtivnickiTim, btnInfoProtivnickiTim);
        }

        private static async void NapuniListuUtakmica(List<Match> listaUtakmica, string linkZaDohvacanje, string najdraziTim, List<Team> listaProtivnika, 
            List<Team> listaTimova, ComboBox cbProtivnickiTim, Button btnInfoProtivnickiTim)
        {
            listaUtakmica.Clear();
            listaProtivnika.Clear();

            var podaci = await Repozitorij.GetMatches(linkZaDohvacanje);
            for (int i = 0; i < podaci.Count; i++)
            {
                for (int j = 0; j < listaTimova.Count; j++)
                {
                    listaUtakmica.Add(podaci[i]);
                    if (listaTimova[j].FifaCode == podaci[i].HomeTeam.Code && podaci[i].HomeTeam.Code != najdraziTim)
                    {
                        listaProtivnika.Add(listaTimova[j]);
                    }
                    else if (listaTimova[j].FifaCode == podaci[i].AwayTeam.Code && podaci[i].AwayTeam.Code != najdraziTim)
                    {
                        listaProtivnika.Add(listaTimova[j]);
                    }
                }
            }

            foreach (var tim in listaProtivnika)
            {
                cbProtivnickiTim.Items.Add(tim);
            }

            cbProtivnickiTim.IsEnabled = true;
        }

        private void btnInfoNajdraziTim_Click(object sender, RoutedEventArgs e)
        {
            new WindowInformacijeReprezentacije(najdrazaReprezentacija.Country, najdrazaReprezentacija.FifaCode, najdrazaReprezentacija.Wins,
                najdrazaReprezentacija.Draws, najdrazaReprezentacija.Losses, najdrazaReprezentacija.GamesPlayed, najdrazaReprezentacija.GoalsFor,
                najdrazaReprezentacija.GoalsAgainst, najdrazaReprezentacija.GoalDifferential).ShowDialog();
        }

        private void btnInfoProtivnickiTim_Click(object sender, RoutedEventArgs e)
        {
            new WindowInformacijeReprezentacije(protivnickaReprezentacija.Country, protivnickaReprezentacija.FifaCode, protivnickaReprezentacija.Wins,
                protivnickaReprezentacija.Draws, protivnickaReprezentacija.Losses, protivnickaReprezentacija.GamesPlayed, protivnickaReprezentacija.GoalsFor,
                protivnickaReprezentacija.GoalsAgainst, protivnickaReprezentacija.GoalDifferential).ShowDialog();
        }

        private void cbProtivnickiTim_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbProtivnickiTim.Items.Count == 0)
            {
                return;
            }

            if (cbProtivnickiTim.SelectedItem == null)
            {
                lblProtivnickiTim.Content = Resursi.Stringovi.stringProtivnickiTim;
                lblProtivnickiTimRezultat.Content = "0";
                lblNajdraziTimRezultat.Content = "0";
                return;
            }

            btnInfoProtivnickiTim.IsEnabled = true;
            lblProtivnickiTim.Content = cbProtivnickiTim.SelectedItem.ToString();
            var protivnickiTim = cbProtivnickiTim.SelectedItem.ToString().Substring(cbProtivnickiTim.SelectedItem.ToString().LastIndexOf('(') + 1, 3);

            for (int i = 0; i < listaProtivnika.Count; i++)
            {
                if (listaProtivnika[i].FifaCode == protivnickiTim)
                {
                    protivnickaReprezentacija = listaProtivnika[i];
                }
            }

            var najdraziTim = cbNajdraziTim.SelectedItem.ToString().Substring(cbNajdraziTim.SelectedItem.ToString().LastIndexOf('(') + 1, 3);

            for (int i = 0; i < listaUtakmica.Count; i++)
            {
                if ((listaUtakmica[i].HomeTeam.Code == protivnickiTim && listaUtakmica[i].AwayTeam.Code == najdraziTim) || 
                    (listaUtakmica[i].HomeTeam.Code == najdraziTim && listaUtakmica[i].AwayTeam.Code == protivnickiTim))
                {
                    utakmicaIzmeduTimova = listaUtakmica[i];
                }
            }

            TeamStatistics statistikaNajdraziTim = new TeamStatistics();
            List<TeamEvent> dogadajiNajdraziTim = new List<TeamEvent>();

            TeamStatistics statistikaProtivnickiTim = new TeamStatistics();
            List<TeamEvent> dogadajiProtivnicki = new List<TeamEvent>();

            if (najdraziTim == utakmicaIzmeduTimova.HomeTeam.Code)
            {
                lblNajdraziTimRezultat.Content = utakmicaIzmeduTimova.HomeTeam.Goals;
                lblProtivnickiTimRezultat.Content = utakmicaIzmeduTimova.AwayTeam.Goals;

                statistikaNajdraziTim = utakmicaIzmeduTimova.HomeTeamStatistics;
                dogadajiNajdraziTim = utakmicaIzmeduTimova.HomeTeamEvents;

                statistikaProtivnickiTim = utakmicaIzmeduTimova.AwayTeamStatistics;
                dogadajiProtivnicki = utakmicaIzmeduTimova.AwayTeamEvents;
            }
            else
            {
                lblNajdraziTimRezultat.Content = utakmicaIzmeduTimova.AwayTeam.Goals;
                lblProtivnickiTimRezultat.Content = utakmicaIzmeduTimova.HomeTeam.Goals;

                statistikaNajdraziTim = utakmicaIzmeduTimova.AwayTeamStatistics;
                dogadajiNajdraziTim = utakmicaIzmeduTimova.AwayTeamEvents;

                statistikaProtivnickiTim = utakmicaIzmeduTimova.HomeTeamStatistics;
                dogadajiProtivnicki = utakmicaIzmeduTimova.HomeTeamEvents;
            }

            najdraziTimGolman.Children.Clear();
            najdraziTimObrana.Children.Clear();
            najdraziTimVeza.Children.Clear();
            najdraziTimNapad.Children.Clear();

            if (ucitaniNajdraziTim == trenutniNajdraziTim && listaNajdrazihIgraca.Count != 0)
            {
                for (int i = 0; i < listaNajdrazihIgraca.Count; i++)
                {
                    for (int j = 0; j < statistikaNajdraziTim.StartingEleven.Count; j++)
                    {
                        if (listaNajdrazihIgraca[i].Name == statistikaNajdraziTim.StartingEleven[j].Name)
                        {
                            int brojacGolova = 0;
                            int brojacZutih = 0;

                            var igrac = listaNajdrazihIgraca[i];

                            for (int k = 0; k < dogadajiNajdraziTim.Count; k++)
                            {
                                if (dogadajiNajdraziTim[k].Player == igrac.Name && dogadajiNajdraziTim[k].TypeOfEvent == "yellow-card")
                                {
                                    brojacZutih++;
                                }
                                else if (dogadajiNajdraziTim[k].Player == igrac.Name && dogadajiNajdraziTim[k].TypeOfEvent == "goal")
                                {
                                    brojacGolova++;
                                }
                            }

                            if (igrac.Position == Resursi.Stringovi.stringVratar)
                            {
                                najdraziTimGolman.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber, igrac.SlikaIgraca, 
                                    brojacGolova.ToString(), brojacZutih.ToString(), igrac.Captain, Resursi.Stringovi.stringVratar));
                            }
                            else if (igrac.Position == Resursi.Stringovi.stringBranic)
                            {
                                najdraziTimObrana.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber, igrac.SlikaIgraca,
                                    brojacGolova.ToString(), brojacZutih.ToString(), igrac.Captain, Resursi.Stringovi.stringBranic));
                            }
                            else if (igrac.Position == Resursi.Stringovi.stringVeznjak)
                            {
                                najdraziTimVeza.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber, igrac.SlikaIgraca,
                                    brojacGolova.ToString(), brojacZutih.ToString(), igrac.Captain, Resursi.Stringovi.stringVeznjak));
                            }
                            else if (igrac.Position == Resursi.Stringovi.stringNapadac)
                            {
                                najdraziTimNapad.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber, igrac.SlikaIgraca,
                                    brojacGolova.ToString(), brojacZutih.ToString(), igrac.Captain, Resursi.Stringovi.stringNapadac));
                            }
                        }
                    }
                }
                
                }
            else
            {
                for (int i = 0; i < statistikaNajdraziTim.StartingEleven.Count; i++)
                {
                    
                    int brojacGolova = 0;
                    int brojacZutih = 0;

                    var igrac = statistikaNajdraziTim.StartingEleven[i];

                    for (int j = 0; j < dogadajiNajdraziTim.Count; j++)
                    {
                        if (dogadajiNajdraziTim[j].Player == igrac.Name && dogadajiNajdraziTim[j].TypeOfEvent == "yellow-card")
                        {
                            brojacZutih++;
                        }
                        else if (dogadajiNajdraziTim[j].Player == igrac.Name && dogadajiNajdraziTim[j].TypeOfEvent == "goal")
                        {
                            brojacGolova++;
                        }
                    }

                    switch (igrac.Position)
                    {
                        case "Goalie":
                            najdraziTimGolman.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber, "",
                            brojacGolova.ToString(), brojacZutih.ToString(), igrac.Captain, Resursi.Stringovi.stringVratar));
                            break;
                        case "Defender":
                            najdraziTimObrana.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber, "",
                            brojacGolova.ToString(), brojacZutih.ToString(), igrac.Captain, Resursi.Stringovi.stringBranic));
                            break;
                        case "Midfield":
                            najdraziTimVeza.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber, "",
                            brojacGolova.ToString(), brojacZutih.ToString(), igrac.Captain, Resursi.Stringovi.stringVeznjak));
                            break;
                        case "Forward":
                            najdraziTimNapad.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber, "",
                            brojacGolova.ToString(), brojacZutih.ToString(), igrac.Captain, Resursi.Stringovi.stringNapadac));
                            break;
                    }

                    
                }
            }

            protivnikTimGolman.Children.Clear();
            protivnikTimObrana.Children.Clear();
            protivnikTimVeza.Children.Clear();
            protivnikTimNapad.Children.Clear();

            for (int i = 0; i < statistikaProtivnickiTim.StartingEleven.Count; i++)
            {

                int brojacGolova = 0;
                int brojacZutih = 0;

                var igrac = statistikaProtivnickiTim.StartingEleven[i];

                for (int j = 0; j < dogadajiProtivnicki.Count; j++)
                {
                    if (dogadajiProtivnicki[j].Player == igrac.Name && dogadajiProtivnicki[j].TypeOfEvent == "yellow-card")
                    {
                        brojacZutih++;
                    }
                    else if (dogadajiProtivnicki[j].Player == igrac.Name && dogadajiProtivnicki[j].TypeOfEvent == "goal")
                    {
                        brojacGolova++;
                    }
                }

                switch (igrac.Position)
                {
                    case "Goalie":
                        protivnikTimGolman.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber, "",
                        brojacGolova.ToString(), brojacZutih.ToString(), igrac.Captain, Resursi.Stringovi.stringVratar));
                        break;
                    case "Defender":
                        protivnikTimObrana.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber, "",
                        brojacGolova.ToString(), brojacZutih.ToString(), igrac.Captain, Resursi.Stringovi.stringBranic));
                        break;
                    case "Midfield":
                        protivnikTimVeza.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber, "",
                        brojacGolova.ToString(), brojacZutih.ToString(), igrac.Captain, Resursi.Stringovi.stringVeznjak));
                        break;
                    case "Forward":
                        protivnikTimNapad.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber, "",
                        brojacGolova.ToString(), brojacZutih.ToString(), igrac.Captain, Resursi.Stringovi.stringNapadac));
                        break;
                }
            }

            //foreach (var igrac in statistikaProtivnickiTim.StartingEleven)
            //{
            //    switch (igrac.Position)
            //    {
            //        case "Goalie":
            //            protivnikTimGolman.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber));
            //            break;
            //        case "Defender":
            //            protivnikTimObrana.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber));
            //            break;
            //        case "Midfield":
            //            protivnikTimVeza.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber));
            //            break;
            //        case "Forward":
            //            protivnikTimNapad.Children.Add(new UserControlIgrac(igrac.Name, igrac.ShirtNumber));
            //            break;
            //    }
            //}

        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            new WindowIzlaz().ShowDialog();
        }

        private void btnPostavke_Click(object sender, RoutedEventArgs e)
        {
            new WindowPostavke().ShowDialog();
            var rezolucija = Repozitorij.UcitajStringIzDatoteke(postavkeRezolucija);

            if (rezolucija == "Fullscreen")
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                string[] podaci = rezolucija.Split('x');
                Width = double.Parse(podaci[0]);
                Height = double.Parse(podaci[1]);
            }
            var novaKultura = Repozitorij.UcitajStringIzDatoteke(postavkeJezika);
            if (novaKultura != ucitaniJezik)
            {
                this.Close();
                new WindowPregledReprezentacije(rezolucija).ShowDialog();
                ucitaniJezik = novaKultura;
            }
            var novoPrvenstvo = Repozitorij.UcitajPostavkePrvenstva(postavkePrvenstvo);
            if (odabranoPrvenstvo != novoPrvenstvo)
            {
                btnInfoNajdraziTim.IsEnabled = false;
                btnInfoProtivnickiTim.IsEnabled = false;
                odabranoPrvenstvo = novoPrvenstvo;
                cbNajdraziTim.SelectedItem = null;
                cbNajdraziTim.Items.Clear();
                cbProtivnickiTim.SelectedItem = null;
                cbProtivnickiTim.Items.Clear();
                listaNajdrazihIgraca.Clear();
                listaTimova.Clear();
                NapuniComboBoxNajdraziTimovi(cbNajdraziTim, odabranoPrvenstvo, listaTimova, "");
            }
        }
    }
}
