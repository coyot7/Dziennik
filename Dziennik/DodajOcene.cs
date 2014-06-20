using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dziennik
{
    public partial class DodajOcene : Form
    {
        public Form1 wsk;
        public int idUczen;
        public int okno = 0; //wartosc 1 wywolal Form1, 2 wywowalal Pokaz
        public Pokaz wskP;
        bool czyMoznaDodac = false;

        public DodajOcene()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public DodajOcene(Form1 glowny, int ID, int okno)
        {
            InitializeComponent();
            wsk = glowny;
            idUczen = ID;
            this.okno = okno;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            using (DziennikDataContext db = new DziennikDataContext())
            {
                Uczen uczniak = db.Uczens.Single(p => p.IdUczen == ID);
                label1.Text = uczniak.Imie.Trim() + " " + uczniak.Nazwisko.Trim();
            }

            DateTime dataDzisiejsza = DateTime.Now;
            textBox2.Text = dataDzisiejsza.ToShortDateString();
        } //konstruktor dla okna Form1

        public DodajOcene(Form1 glowny, int ID, int okno, Pokaz glowny2) //konstruktor dla okna Pokaz
        {
            InitializeComponent();
            wsk = glowny;
            idUczen = ID;
            this.okno = okno;
            wskP = glowny2;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            using (DziennikDataContext db = new DziennikDataContext())
            {
                Uczen uczniak = db.Uczens.Single(p => p.IdUczen == ID);
                label1.Text = uczniak.Imie.Trim() + " " + uczniak.Nazwisko.Trim();
            }

            DateTime dataDzisiejsza = DateTime.Now;
            textBox2.Text = dataDzisiejsza.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ocenaStr = textBox1.Text.ToString();
            double ocenaDec = 0;

            foreach (char item in ocenaStr.ToCharArray())
            {
                if (ocenaStr.Length > 2)
                {
                    MessageBox.Show("Błędnie wprowadzona ocena.",
                                "Dodawanie wpisu", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    break;
                }
                if (item == '+')
                {
                    ocenaDec += 0.33;
                }
                if (item == '-')
                {
                    ocenaDec -= 0.33;
                }
                if (item > 48 && item < 55)
                {
                    ocenaDec += char.GetNumericValue(item);
                    czyMoznaDodac = true;
                }
                
            }
            if (ocenaStr.Length < 3 && czyMoznaDodac == true)
            {
                using (DziennikDataContext db = new DziennikDataContext())
                {
                    try
                    {
                        Ocena nota = new Ocena();
                        nota.IdNauczyciel = wsk.idNauczyciel;
                        nota.IdUczen = this.idUczen;
                        nota.Stopien = Convert.ToDecimal(ocenaDec);
                        nota.Data = Convert.ToDateTime(textBox2.Text);
                        nota.Opis = textBox3.Text.ToString();
                        nota.Poprawa = false;
                        db.Ocenas.InsertOnSubmit(nota);
                        db.SubmitChanges();
                        MessageBox.Show("Dodano wpis poprawnie.",
                                    "Dodawanie wpisu", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                        this.Close();
                        if (okno == 1)
                        {
                            wsk.Odswiez();
                        }
                        if (okno == 2)
                        {
                            wskP.Odswiez();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Źle wprowadzono ocenę lub datę",
                                   "Błąd", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    }
                }
            }
            if (ocenaDec == 0 || ocenaDec == -0.33 || ocenaDec == 0.33)
            {
                MessageBox.Show("Źle wprowadzono ocenę lub datę",
                                   "Błąd", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
        }
    }
}
