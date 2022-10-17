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
    public partial class UserControlRangGolovi : UserControl, IComparable<UserControlRangGolovi>
    {
        public UserControlRangGolovi()
        {
            InitializeComponent();
        }

        public UserControlRangGolovi(string nazivIgraca, bool najdraziIgrac, string putanjaSlike) : this()
        {
            lblNazivIgraca.Text = nazivIgraca.ToString();
            if (najdraziIgrac)
            {
                pbNajdraziIgrac.Image = Slike.goldenstar;
            }
            else
            {
                pbNajdraziIgrac.Image = null;
            }
            if (putanjaSlike.Trim().Length != 0)
            {
                pbSlikaIgraca.Image = Image.FromFile(putanjaSlike);
            }
        }

        public string NazivIgraca 
        { 
            get { return lblNazivIgraca.Text; }
            private set {} 
        }

        public Image NajdraziIgrac 
        { 
            get { return pbNajdraziIgrac.Image; }
        }

        public Image SlikaIgraca 
        { 
            get { return pbSlikaIgraca.Image; }
        }

        public int BrojGolova 
        {
            get { return int.Parse(lblBrojGolova.Text); }
            set { lblBrojGolova.Text += value; } 
        }

        public Label GoloviLabela 
        { 
            get { return lblDogadaj; }
            set { lblDogadaj.Text = value.Text; }
        }

        public int CompareTo(UserControlRangGolovi other) => -BrojGolova.CompareTo(other.BrojGolova);
    }
}
