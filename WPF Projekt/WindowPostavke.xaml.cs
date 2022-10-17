using PodatkovniSloj;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_Projekt
{
    /// <summary>
    /// Interaction logic for WindowPostavke.xaml
    /// </summary>
    public partial class WindowPostavke : Window
    {
        private const string postavkeJezika = "../../../TekstualneDatoteke/PostavkeJezika.txt";
        private const string postavkePrvenstva = "../../../TekstualneDatoteke/PostavkePrvenstva.txt";
        private const string postavkeRezolucija = "../../../TekstualneDatoteke/PostavkeRezolucija.txt";
        private string odabranoPrvenstvo;

        public WindowPostavke()
        {
            var ucitaniJezik = Repozitorij.UcitajPostavkeJezika(postavkeJezika);
            SetCulture(ucitaniJezik);
            InitializeComponent();
        }

        private void SetCulture(string kultura)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(kultura);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(kultura);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var odabranaRezolucija = Repozitorij.UcitajStringIzDatoteke(postavkeRezolucija);
            //lblOdabranaRezolucija.Content = lblOdabranaRezolucija.Content.ToString().Substring(0, lblOdabranaRezolucija.Content.ToString().LastIndexOf('(') + 1);
            lblOdabranaRezolucija.Content += " " + odabranaRezolucija;
            odabranoPrvenstvo = Repozitorij.UcitajStringIzDatoteke(postavkePrvenstva);
            DohvatiLabeluOdabranoPrvenstvo();
            if (odabranoPrvenstvo == "Male")
            {
                btnMuskoPrvenstvo.IsEnabled = false;
            }
            else if (odabranoPrvenstvo=="Female")
            {
                btnZenskoPrvenstvo.IsEnabled = false;
            }

            if (odabranaRezolucija == "Fullscreen")
            {
                btnFullscreen.IsEnabled = false;
            }
            else if (odabranaRezolucija == "1920x1080")
            {
                btn1920x1080.IsEnabled = false;
            }
            else if (odabranaRezolucija == "1536x864")
            {
                btn1536x864.IsEnabled = false;
            }
            else if (odabranaRezolucija == "1280x720")
            {
                btn1280x720.IsEnabled = false;
            }
        }

        private void DohvatiLabeluOdabranoPrvenstvo()
        {
            if (odabranoPrvenstvo == "Male" || odabranoPrvenstvo == "Muško prvenstvo")
            {
                lblOdabranoPrvenstvo.Content += " " + Resursi.Stringovi.stringGumbMusko;
            }
            else if (odabranoPrvenstvo == "Female" || odabranoPrvenstvo == "Žensko prvenstvo")
            {
                lblOdabranoPrvenstvo.Content += " " + Resursi.Stringovi.stringGumbZensko;
            }
            else
            {
                lblOdabranoPrvenstvo.Content += "";
            }
        }

        private void btnHrvatski_Click(object sender, RoutedEventArgs e)
        {
            Repozitorij.SpremiStringUDatoteku(postavkeJezika, "hr");
            this.Hide();
            new WindowPostavke().ShowDialog();
            this.Close();
        }

        private void btnEngleski_Click(object sender, RoutedEventArgs e)
        {
            Repozitorij.SpremiStringUDatoteku(postavkeJezika, "en");
            this.Hide();
            new WindowPostavke().ShowDialog();
            this.Close();
        }

        private void btnMuskoPrvenstvo_Click(object sender, RoutedEventArgs e)
        {
            OdabirPrvenstvaIspisULabel(btnMuskoPrvenstvo.Content.ToString(), sender);
            btnZenskoPrvenstvo.IsEnabled = true;
        }

        private void OdabirPrvenstvaIspisULabel(string prvenstvo, object sender)
        {
            lblOdabranoPrvenstvo.Content = lblOdabranoPrvenstvo.Content.ToString().Substring(0, lblOdabranoPrvenstvo.Content.ToString().LastIndexOf(':') + 1);
            lblOdabranoPrvenstvo.Content += " " + prvenstvo;
            var gumb = sender as Button;
            gumb.IsEnabled = false;
        }

        private void btnZenskoPrvenstvo_Click(object sender, RoutedEventArgs e)
        {
            OdabirPrvenstvaIspisULabel(btnZenskoPrvenstvo.Content.ToString(), sender);
            btnMuskoPrvenstvo.IsEnabled = true;
        }

        private void btnFullscreen_Click(object sender, RoutedEventArgs e)
        {
            OdabirRezolucijeIspisULabel(btnFullscreen.Content.ToString(), sender, btn1920x1080, btn1536x864, btn1280x720);
        }

        private void OdabirRezolucijeIspisULabel(string rezolucija, object sender, Button gumb1, Button gumb2, Button gumb3)
        {
            lblOdabranaRezolucija.Content = lblOdabranaRezolucija.Content.ToString().Substring(0, lblOdabranaRezolucija.Content.ToString().LastIndexOf(':') + 1);
            lblOdabranaRezolucija.Content += " " + rezolucija;

            var gumb = sender as Button;
            gumb.IsEnabled = false;
            gumb1.IsEnabled = true;
            gumb2.IsEnabled = true;
            gumb3.IsEnabled = true;
        }

        private void btn1920x1080_Click(object sender, RoutedEventArgs e)
        {
            OdabirRezolucijeIspisULabel(btn1920x1080.Content.ToString(), sender, btnFullscreen, btn1536x864, btn1280x720);
        }

        private void btn1536x864_Click(object sender, RoutedEventArgs e)
        {
            OdabirRezolucijeIspisULabel(btn1536x864.Content.ToString(), sender, btnFullscreen, btn1920x1080, btn1280x720);
        }

        private void btn1280x720_Click(object sender, RoutedEventArgs e)
        {
            OdabirRezolucijeIspisULabel(btn1280x720.Content.ToString(), sender, btnFullscreen, btn1920x1080, btn1536x864);
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            var odabirPrvenstva = lblOdabranoPrvenstvo.Content.ToString().Substring(lblOdabranoPrvenstvo.Content.ToString().IndexOf(':') + 2);
            Repozitorij.SpremiPostavkePrvenstva(postavkePrvenstva, odabirPrvenstva);

            var odabranaRezolucija = lblOdabranaRezolucija.Content.ToString().Substring(lblOdabranaRezolucija.Content.ToString().IndexOf(':') + 2);
            Repozitorij.SpremiStringUDatoteku(postavkeRezolucija, odabranaRezolucija);
            
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    btnPotvrdi_Click(sender, e);
                    break;
                case Key.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
