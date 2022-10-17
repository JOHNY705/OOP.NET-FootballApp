using System.Windows;

namespace WPF_Projekt
{
    /// <summary>
    /// Interaction logic for WindowInformacijeReprezentacije.xaml
    /// </summary>
    public partial class WindowInformacijeReprezentacije : Window
    {
        public WindowInformacijeReprezentacije()
        {
            InitializeComponent();
        }

        public WindowInformacijeReprezentacije(string drzava, string fifaKod, long pobjede, long izjednaceno, long porazi, long odigranoUtakmica, long goloviZa, 
            long goloviProtiv, long golRazlika) : this()
        {
            lblDrzava.Content = drzava;
            lblFifaKod.Content = fifaKod;
            lblPobjede.Content = pobjede;
            lblNerijeseno.Content = izjednaceno;
            lblPorazi.Content = porazi;
            lblOdigrano.Content = odigranoUtakmica;
            lblGoalsFor.Content = goloviZa;
            lblGoalsAgainst.Content = goloviProtiv;
            lblDifferential.Content = golRazlika;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
