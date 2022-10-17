using PodatkovniSloj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Projekt
{
    /// <summary>
    /// Interaction logic for WindowRezolucija.xaml
    /// </summary>
    public partial class WindowRezolucija : Window
    {
        private string postavkeRezolucija = "../../../TekstualneDatoteke/PostavkeRezolucija.txt";
        private string odabranaRezolucija;

        public WindowRezolucija()
        {
            odabranaRezolucija = Repozitorij.UcitajStringIzDatoteke(postavkeRezolucija);
            if (odabranaRezolucija.Trim().Length != 0)
            {
                OtvoriNoviProzor();
            }
            InitializeComponent();
        }

        private void OdabirRezolucijeIspisULabel(string rezolucija, object sender, Button gumb1, Button gumb2, Button gumb3)
        {
            btnPotvrdi.IsEnabled = true;
            lblOdabranaRezolucija.Content = lblOdabranaRezolucija.Content.ToString().Substring(0, lblOdabranaRezolucija.Content.ToString().LastIndexOf(':') + 1);
            lblOdabranaRezolucija.Content += " " + rezolucija;
            
            var gumb = sender as Button;
            gumb.IsEnabled = false;
            gumb1.IsEnabled = true;
            gumb2.IsEnabled = true;
            gumb3.IsEnabled = true;
        }

        private void btnFullscreen_Click(object sender, RoutedEventArgs e)
        {
            OdabirRezolucijeIspisULabel(btnFullscreen.Content.ToString(), sender, btn1920x1080, btn1536x864, btn1280x720);
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
            odabranaRezolucija = lblOdabranaRezolucija.Content.ToString().Substring(lblOdabranaRezolucija.Content.ToString().IndexOf(':') + 2);
            Repozitorij.SpremiStringUDatoteku(postavkeRezolucija, odabranaRezolucija);
            OtvoriNoviProzor();
        }

        private void OtvoriNoviProzor()
        {
            this.Hide();
            new WindowPregledReprezentacije(odabranaRezolucija).ShowDialog();
            this.Close();
        }
    }
}
