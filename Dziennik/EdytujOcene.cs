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
    public partial class EdytujOcene : Form
    {
        public int idUczen;
        public int okno;
        public Pokaz wskP;
        public int idOcena;
        public Form1 wsk;

        public EdytujOcene()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public EdytujOcene(int ID, int okno, Pokaz glowny2, int idOcena, Form1 other) 
        {
            InitializeComponent();
            idUczen = ID;
            this.okno = okno;
            wskP = glowny2;
            this.idOcena = idOcena;
            wsk = other;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            using (DziennikDataContext db = new DziennikDataContext())
            {
                Uczen uczniak = db.Uczens.Single(p => p.IdUczen == ID);
                label1.Text = uczniak.Imie.Trim() + " " + uczniak.Nazwisko.Trim();
                textBox1.Text = db.Ocenas.Single(p => p.IdOcena == idOcena).Stopien.ToString();
                textBox2.Text = db.Ocenas.Single(p => p.IdOcena == idOcena).Data.ToShortDateString();
                textBox3.Text = db.Ocenas.Single(p => p.IdOcena == idOcena).Opis.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DziennikDataContext db = new DziennikDataContext())
            {
                try
                {
                    Ocena nota = db.Ocenas.Single(p => p.IdOcena == idOcena);
                    nota.Stopien = Convert.ToDecimal(textBox1.Text);
                    nota.Data = Convert.ToDateTime(textBox2.Text.ToString());
                    nota.Opis = textBox3.Text.ToString();
                    
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
                catch (Exception ex)
                {
                    MessageBox.Show("Źle wprowadzono ocenę lub datę\n" +ex,
                               "Błąd", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                }
            }
        }
    }
}
