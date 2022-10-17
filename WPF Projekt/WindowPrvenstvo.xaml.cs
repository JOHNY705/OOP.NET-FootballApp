using PodatkovniSloj;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Projekt
{
    /// <summary>
    /// Interaction logic for WindowPrvenstvo.xaml
    /// </summary>
    public partial class WindowPrvenstvo : Window
    {
        private string postavkePrvenstvo = "../../../TekstualneDatoteke/PostavkePrvenstva.txt";

        public WindowPrvenstvo()
        {
            var odabranoPrvenstvo = Repozitorij.UcitajPostavkePrvenstva(postavkePrvenstvo);
            if (odabranoPrvenstvo.ToString().Trim().Length != 0)
            {
                OtvoriNoviProzor();
            }
            InitializeComponent();
        }

        private void btnMusko_Click(object sender, RoutedEventArgs e)
        {
            OdabirPrvenstvaIspisULabel(btnMusko.Content.ToString(), sender);
            btnZensko.IsEnabled = true;
        }

        private void btnZensko_Click(object sender, RoutedEventArgs e)
        {
            OdabirPrvenstvaIspisULabel(btnZensko.Content.ToString(), sender);
            btnMusko.IsEnabled = true;
        }

        private void OdabirPrvenstvaIspisULabel(string prvenstvo, object sender)
        {
            btnPotvrdi.IsEnabled = true;
            lblOdabranoPrvenstvo.Content = lblOdabranoPrvenstvo.Content.ToString().Substring(0, lblOdabranoPrvenstvo.Content.ToString().LastIndexOf(':') + 1);
            lblOdabranoPrvenstvo.Content += " " + prvenstvo;
            var gumb = sender as Button;
            gumb.IsEnabled = false;
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            var odabirPrvenstva = lblOdabranoPrvenstvo.Content.ToString().Substring(lblOdabranoPrvenstvo.Content.ToString().IndexOf(':') + 2);
            Repozitorij.SpremiPostavkePrvenstva(postavkePrvenstvo, odabirPrvenstva);
            OtvoriNoviProzor();
        }

        private void OtvoriNoviProzor()
        {
            this.Hide();
            new WindowRezolucija().ShowDialog();
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
