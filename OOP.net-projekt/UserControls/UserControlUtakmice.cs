using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP.net_projekt.UserControls
{
    public partial class UserControlUtakmice : UserControl, IComparable<UserControlUtakmice>
    {
        public UserControlUtakmice()
        {
            InitializeComponent();
        }

        public UserControlUtakmice(string domacin, string gost, string lokacija, long brojPosjetitelja) : this()
        {
            lblDomacin.Text = domacin.ToString();
            lblGost.Text = gost.ToString();
            lblLokacija.Text = lokacija.ToString();
            lblBrojPosjetitelja.Text = brojPosjetitelja.ToString();
        }

        public Label DomacinLabel
        {
            get { return labelaDomacin; }
            set { labelaDomacin.Text = value.Text; }
        }

        public Label GostLabel
        {
            get { return labelaGost; }
            set { labelaGost.Text = value.Text; }
        }

        public Label LokacijaLabel
        {
            get { return labelaLokacija; }
            set { labelaLokacija.Text = value.Text; }
        }

        public Label PosjetiteljiLabel
        {
            get { return labelaPosjetitelji; }
            set { labelaPosjetitelji.Text = value.Text; }
        }

        public string Lokacija 
        { 
            get { return lblLokacija.Text; }
        }
        public string DomaciTim
        {
            get { return lblDomacin.Text; }
        }
        public string GostTim
        {
            get { return lblGost.Text; }
        }
        public int BrojPosjetitelja
        {
            get { return int.Parse(lblBrojPosjetitelja.Text); }
            //set { lblBrojPosjetitelja.Text += value; }
        }

        public Image SlikaStadiona 
        {
            get => pbStadion.Image; 
        }

        public int CompareTo(UserControlUtakmice other) => -BrojPosjetitelja.CompareTo(other.BrojPosjetitelja);
    }
}
