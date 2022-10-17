using PodatkovniSloj;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string datotekaJezika = "../../../TekstualneDatoteke/PostavkeJezika.txt";
        public MainWindow()
        {
            var kultura = Repozitorij.UcitajPostavkeJezika(datotekaJezika);
            if (kultura != String.Empty)
            {
                this.Hide();
                new WindowPrvenstvo().ShowDialog();
                this.Close();
            }
            else
            {
                SetCulture("hr");
            }
            InitializeComponent();
        }

        private void SetCulture(string kultura)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(kultura);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(kultura);
        }

        private void btnHrvatski_Click(object sender, RoutedEventArgs e)
        {
            SetCulture("hr");
            Repozitorij.SpremiPostavkeJezika(datotekaJezika);
            this.Hide();
            new WindowPrvenstvo().ShowDialog();
            this.Close();
        }

        private void btnEngleski_Click(object sender, RoutedEventArgs e)
        {
            SetCulture("en");
            Repozitorij.SpremiPostavkeJezika(datotekaJezika);
            this.Hide();
            new WindowPrvenstvo().ShowDialog();
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            Repozitorij.SpremiPostavkeJezika(datotekaJezika);
            this.Hide();
            new WindowPrvenstvo().ShowDialog();
            this.Close();
        }
    }
}
