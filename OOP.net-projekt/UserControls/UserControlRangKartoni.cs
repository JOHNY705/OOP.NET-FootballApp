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
    public partial class UserControlRangKartoni : UserControl, IComparable<UserControlRangKartoni>
    {
        public UserControlRangKartoni()
        {
            InitializeComponent();
        }

        public UserControlRangKartoni(string nazivIgraca, bool najdraziIgrac, string putanjaSlike) : this()
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
            private set { }
        }

        public Image NajdraziIgrac 
        { 
            get { return pbNajdraziIgrac.Image; } 
        }

        public Image SlikaIgraca 
        { 
            get { return pbSlikaIgraca.Image; } 
        }

        public int BrojZutihKartona
        { 
            get { return int.Parse(lblBrojKartona.Text); }
            set { lblBrojKartona.Text += value; }
        }

        public Label KartoniLabela
        {
            get { return lblDogadaj; }
            set { lblDogadaj.Text = value.Text; }
        }

        public int CompareTo(UserControlRangKartoni other) => -BrojZutihKartona.CompareTo(other.BrojZutihKartona);

        //public PictureBox SlikaIgraca 
        //{ 
        //    get
        //    {
        //        return pbSlikaIgraca;
        //    }
        //    set
        //    {
        //        pbSlikaIgraca.Image = value.Image;
        //    }
        //}
    }
}
