using Newtonsoft.Json;
using OOP.net_projekt.Models;
using PodatkovniSloj.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PodatkovniSloj
{
    public class Repozitorij
    {
        public static string UcitajPostavkeJezika(string datotekaJezika)
        {
            string kultura = String.Empty;
            try
            {
                if (!File.Exists(datotekaJezika))
                {
                    return string.Empty;
                }

                using (StreamReader reader = new StreamReader(datotekaJezika))
                {
                    kultura = reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex.Message);
            }

            return kultura;
        }

        public static string GetLinkZaDohvacanje(string odabranoPrvenstvo, string najdraziTim)
        {
            if (odabranoPrvenstvo == "Male")
            {
                return "http://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=" + najdraziTim;
            }
            else
            {
                return "http://worldcup.sfg.io/matches/country?fifa_code=" + najdraziTim;
            }
        }

        public static Task<List<Match>> GetMatches (string linkZaDohvacanje)
        {
            return Task.Run(() =>
            {
                RestClient restKlijent = new RestClient(linkZaDohvacanje);

                var rezultat = restKlijent.Execute<List<Match>>(new RestRequest());

                return JsonConvert.DeserializeObject<List<Match>>(rezultat.Content);
                //return rezultat.Data;
            });
        }

        public static List<Player> GetIgraciFromUtakmica(List<Match> listaUtakmica, string najdraziTim)
        {

            if (listaUtakmica[0].HomeTeam.Code == najdraziTim)
            {
                List<Player> igraci = new List<Player>(listaUtakmica[0].HomeTeamStatistics.StartingEleven);
                List<Player> substitutes = new List<Player>(listaUtakmica[0].HomeTeamStatistics.Substitutes);
                igraci.AddRange(substitutes);
                return igraci;
            }
            else
            {
                List<Player> igraci = new List<Player>(listaUtakmica[0].AwayTeamStatistics.StartingEleven);
                List<Player> substitutes = new List<Player>(listaUtakmica[0].AwayTeamStatistics.Substitutes);
                igraci.AddRange(substitutes);
                return igraci;
            }
        }

        //public static Task<List<Match>> GetMatches (string linkZaDohvacanje)
        //{
        //    return Task.Run(() =>
        //    {
        //        RestClient restKlijent = new RestClient(linkZaDohvacanje);

        //        var rezultat = restKlijent.Execute<List<Match>>(new RestRequest());

        //        return rezultat.Data;
        //    });
        //}

        public static void SpremiPostavkeJezika(string datotekaJezika)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(datotekaJezika))
                {
                    writer.WriteLine(Thread.CurrentThread.CurrentCulture.Name.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex.Message);
            }
        }

        public static string UcitajPostavkePrvenstva(string postavkePrvenstvo)
        {
            string ucitanoPrvenstvo = string.Empty;
            try
            {
                if (!File.Exists(postavkePrvenstvo))
                {
                    return string.Empty;
                }

                using (StreamReader reader = new StreamReader(postavkePrvenstvo))
                {
                    ucitanoPrvenstvo = reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex.Message);
            }

            return ucitanoPrvenstvo;
        }

        public static void SpremiPostavkePrvenstva(string postavkePrvenstvo, string odabir)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(postavkePrvenstvo))
                {
                    if (odabir == "Žensko prvenstvo" || odabir == "Women's Cup")
                    {
                        writer.WriteLine("Female");
                    }
                    else
                    {
                        writer.WriteLine("Male");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex.Message);
            }
        }

        //public static async void NapuniComboBoxTimovi(ComboBox cbTimovi, string odabranoPrvenstvo)
        //{
        //    var podaci = await GetComboBoxTimovi(odabranoPrvenstvo);
        //    foreach (var team in podaci)
        //    {
        //        cbTimovi.Items.Add(team);
        //    }
        //}

        public static Task<List<Team>> GetComboBoxTimovi(string prvenstvo)
        {
            return Task.Run(() =>
            {
                RestClient restKlijent = new RestClient();
                if (prvenstvo == "Male")
                {
                    restKlijent = new RestClient("https://world-cup-json-2018.herokuapp.com/teams/results");
                }
                else if (prvenstvo == "Female")
                {
                    restKlijent = new RestClient("https://worldcup.sfg.io/teams/results");
                }

                var rezultat = restKlijent.Execute<List<Team>>(new RestRequest());

                return rezultat.Data;
            });
        }

        public static void SpremiPostavkeTima(string postavkeNajdraziTim, string najdraziTim)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(postavkeNajdraziTim))
                {
                    writer.WriteLine(najdraziTim);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex.Message);
            }
        }

        public static string UcitajPostavkeTima(string postavkeTima)
        {
            string najdraziTim = string.Empty;
            try
            {
                if (!File.Exists(postavkeTima))
                {
                    return string.Empty;
                }

                using (StreamReader reader = new StreamReader(postavkeTima))
                {
                    najdraziTim = reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex.Message);
            }

            return najdraziTim;
        }

        public static Image GetSlika(string putanja)
        {
            return Image.FromFile(putanja);
        }

        //za stringove cutter

        public static string StringCutter(string tekst)
        {
            return tekst.ToString().Substring(0, tekst.LastIndexOf(':') + 2);
        }

        public static void SpremiIgraceUDatoteku(string igraciDatoteka, List<Player> igraci)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(igraciDatoteka))
                {
                    foreach (var igrac in igraci)
                    {
                        writer.Write(igrac.Name);
                        writer.Write("|");
                        writer.Write(igrac.Position);
                        writer.Write("|");
                        writer.Write(igrac.Captain);
                        writer.Write("|");
                        writer.Write(igrac.ShirtNumber);
                        writer.Write("|");
                        writer.Write(igrac.Najdrazi);
                        writer.Write("|");
                        writer.Write(igrac.SlikaIgraca);
                        writer.Write(Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex.Message);
            }
        }

        public static List<Player> UcitavanjeIgracaIzDatoteke(string igraciDatoteka)
        {
            List<Player> igraci = new List<Player>();
            try
            {
                using (StreamReader reader = new StreamReader(igraciDatoteka))
                {
                    while (!reader.EndOfStream)
                    {
                        igraci.Add(DohvatiIgracaIzStringa(reader.ReadLine()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex.Message);
            }
            return igraci;
        }

        public static Player DohvatiIgracaIzStringa(string linija)
        {
            string[] podaci = linija.Split('|');
            return new Player
            {
                Name = podaci[0],
                Position = podaci[1],
                Captain = bool.Parse(podaci[2]),
                ShirtNumber = podaci[3],
                Najdrazi = bool.Parse(podaci[4]),
                SlikaIgraca = podaci.Length > 5 ? podaci[5] : String.Empty
            };
        }

        public static void SpremiStringUDatoteku(string datoteka, string linija)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(datoteka))
                {
                    writer.WriteLine(linija);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex.Message);
            }
        }

        public static string UcitajStringIzDatoteke(string datoteka)
        {
            string link = string.Empty;
            try
            {
                if (!File.Exists(datoteka))
                {
                    return string.Empty;
                }

                using (StreamReader reader = new StreamReader(datoteka))
                {
                    link = reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n" + ex.Message);
            }

            return link;
        }

        public static List<TeamEvent> UcitajEventeIzUtakmica(List<Match> utakmice, string najdraziTim)
        {
            var brojUtakmica = utakmice.Count;
            List<TeamEvent> listaDogadaja = new List<TeamEvent>();
            for (int i = 0; i < utakmice.Count; i++)
            {
                if (utakmice[i].HomeTeam.Code == najdraziTim)
                {
                    listaDogadaja.AddRange(utakmice[i].HomeTeamEvents);
                }
                else
                {
                    listaDogadaja.AddRange(utakmice[i].AwayTeamEvents);
                }
            }
            return listaDogadaja;
        }
    }        
}
