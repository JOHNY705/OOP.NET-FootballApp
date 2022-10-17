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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Projekt
{
    /// <summary>
    /// Interaction logic for UserControlIgrac.xaml
    /// </summary>
    public partial class UserControlIgrac : UserControl
    {
        public UserControlIgrac()
        {
            InitializeComponent();
        }

        public UserControlIgrac(string punoIme, string broj) : this()
        {
            nazivIgraca.Text = punoIme;
            brojIgraca.Content = broj;
        }

        public UserControlIgrac(string punoIme, string broj, string putanja, string brojGolova, string brojZutih, bool kapetan, string pozicija) : this(punoIme, broj)
        {
            if (putanja.Trim().Length != 0)
            {
                Putanja = putanja;
                slikaIgraca.Source = new BitmapImage(new Uri(putanja));
            }
            else
            {
                Putanja = "";
            }
            BrojGolova = brojGolova;
            BrojZutih = brojZutih;
            Kapetan = kapetan;
            Pozicija = pozicija;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new WindowPregledIgraca(nazivIgraca.Text, brojIgraca.Content.ToString(), Pozicija, BrojGolova, BrojZutih, Kapetan, Putanja).Show();
        }

        public string BrojGolova { get; set; }
        public string BrojZutih { get; set; }
        public bool Kapetan { get; set; }
        public string Pozicija { get; set; }
        public string Putanja { get; set; }
    }
}
