using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for WindowPregledIgraca.xaml
    /// </summary>
    public partial class WindowPregledIgraca : Window
    {
        public WindowPregledIgraca()
        {
            InitializeComponent();
        }

        public WindowPregledIgraca(string nazivIgraca, string broj, string pozicija, string brojGolova, string brojZutih, bool kapetan, string putanja) : this()
        {
            lblNazivIgraca.Content = nazivIgraca;
            lblBrojIgraca.Content = broj;
            lblPozicija.Content = pozicija;
            lblGolovi.Content = brojGolova;
            lblZutiKartoni.Content = brojZutih;
            if (kapetan)
            {
                lblKapetan.Content = Resursi.Stringovi.stringKapetan;
            }
            else
            {
                lblKapetan.Content = "";
            }
            if (putanja.Trim().Length != 0)
            {
                slikaIgraca.Source = new BitmapImage(new Uri(putanja));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
