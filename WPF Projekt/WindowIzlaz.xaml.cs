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
    /// Interaction logic for WindowIzlaz.xaml
    /// </summary>
    public partial class WindowIzlaz : Window
    {
        public WindowIzlaz()
        {
            InitializeComponent();
        }

        private void btnDa_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnNe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    Application.Current.Shutdown();
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
