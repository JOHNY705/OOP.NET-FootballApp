using OOP.net_projekt.Resources;
using PodatkovniSloj;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OOP.net_projekt.UserControls
{
    public partial class UserControlIgrac : UserControl
    {
        private string datotekaJezika = "PostavkeJezika.txt";
        public UserControlIgrac()
        {
            InitializeComponent();  
        }

        public UserControlIgrac(string nazivIgraca, string pozicija, string broj, bool kapetan) : this()
        {
            lblPunoIme.Text = nazivIgraca.ToString();
            lblPozicija.Text = pozicija.ToString();
            switch (pozicija)
            {
                case "Forward":
                    lblPozicija.Text = MojiResursi.napadacString;
                    break;
                case "Midfield":
                    lblPozicija.Text = MojiResursi.veznjakString;
                    break;
                case "Defender":
                    lblPozicija.Text = MojiResursi.branicString;
                    break;
                case "Goalie":
                    lblPozicija.Text = MojiResursi.vratarString;
                    break;
            }
            lblBroj.Text = broj.ToString();
            if (kapetan)
            {
                lblKapetan.Text = MojiResursi.kapetanString;
            }
            else
            {
                lblKapetan.Text = string.Empty;
            }
        }

        public UserControlIgrac(string nazivIgraca, string pozicija, string broj, bool kapetan, bool najdraziIgrac, string putanjaSlike) : this(nazivIgraca, pozicija, broj, kapetan)
        {
            var kultura = Repozitorij.UcitajPostavkeJezika(datotekaJezika);
            if (kultura == "hr")
            {
                switch (pozicija)
                {
                    case "Forward":
                        lblPozicija.Text = MojiResursi.napadacString;
                        break;
                    case "Midfield":
                        lblPozicija.Text = MojiResursi.veznjakString;
                        break;
                    case "Defender":
                        lblPozicija.Text = MojiResursi.branicString;
                        break;
                    case "Goalie":
                        lblPozicija.Text = MojiResursi.vratarString;
                        break;
                }
            }
            else
            {
                switch (pozicija)
                {
                    case "Napadač":
                        lblPozicija.Text = MojiResursi.napadacString;
                        break;
                    case "Veznjak":
                        lblPozicija.Text = MojiResursi.veznjakString;
                        break;
                    case "Branič":
                        lblPozicija.Text = MojiResursi.branicString;
                        break;
                    case "Vratar":
                        lblPozicija.Text = MojiResursi.vratarString;
                        break;
                }
            }
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
                pbIgrac.Image = Image.FromFile(putanjaSlike);
            }
        }

        public string NazivIgraca 
        { 
            get { return lblPunoIme.Text; } 
            set {} 
        }

        public string Pozicija 
        { 
            get { return lblPozicija.Text; } 
            set {} 
        }

        public string Broj 
        { 
            get { return lblBroj.Text; }
            set {}
        }

        public bool Kapetan 
        { 
            get 
            {
                if (lblKapetan.Text.Trim().Length != 0)
                {
                    return true;
                }
                return false;
            } 
            set {} 
        }

        public PictureBox NajdraziIgrac 
        {
            get
            {
                return pbNajdraziIgrac;
            }
            set
            {
                pbNajdraziIgrac.Image = value.Image;
            }
        }

        public PictureBox SlikaIgraca 
        { 
            get
            {
                return pbIgrac;
            }
            set
            {
                pbIgrac.Image = value.Image;
            }
        }

        private void UserControlIgrac_MouseDown(object sender, MouseEventArgs e)
        {
            var igrac = sender as UserControlIgrac;
            igrac.DoDragDrop(igrac, DragDropEffects.Move);
        }
    }
}                 