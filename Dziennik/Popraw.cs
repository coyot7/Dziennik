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
    public partial class Popraw : Form
    {
        public Form1 wsk;
        private int ID { get; set; }
        private string kto { get; set; }

        public Popraw()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public Popraw(int ID, string kto, Form1 other)
        {
            this.wsk = other;
            this.ID = ID;
            this.kto = kto;

            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            using (DziennikDataContext db = new DziennikDataContext())
            {
                if (kto == "Nauczyciele")
                {
                    label3.Text = "Przedmiot";

                    textBox1.Text = (from p in db.Nauczyciels
                                     where p.IdNauczyciel == ID
                                     select p.Imie
                                     ).Single();
                    textBox2.Text = (from p in db.Nauczyciels
                                     where p.IdNauczyciel == ID
                                     select p.Nazwisko
                                     ).Single();
                    textBox3.Text = (from p in db.Nauczyciels
                                     where p.IdNauczyciel == ID
                                     select p.Przedmiot
                                     ).Single();
                }
                
                if (kto == "Uczniowie")
                {
                    label3.Text = "Klasa";

                    textBox1.Text = (from p in db.Uczens
                                     where p.IdUczen == ID
                                     select p.Imie
                                     ).Single();
                    textBox2.Text = (from p in db.Uczens
                                     where p.IdUczen == ID
                                     select p.Nazwisko
                                     ).Single();
                    textBox3.Text = (from p in db.Uczens
                                     where p.IdUczen == ID
                                     select p.Klasa
                                     ).Single();
                }
            }
        } //automatyczne wypełnieni pól starymi wartościami

        private void button1_Click(object sender, EventArgs e)
        {
            using (DziennikDataContext db = new DziennikDataContext())
            {
                if (kto == "Nauczyciele")
                {
                    label3.Text = "Przedmiot";

                    Nauczyciel belfer = db.Nauczyciels.Single(p => p.IdNauczyciel == ID);

                    belfer.Imie = textBox1.Text;    
                    belfer.Nazwisko = textBox2.Text;
                    belfer.Przedmiot = textBox3.Text;
                    
                    try
                    {
                        db.SubmitChanges();

                        MessageBox.Show("Wpis został poprawiony",
                            "Poprawianie", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception bl)
                    {
                        MessageBox.Show("Błąd połączenia z bazą\n" + bl);
                    }
                }
                if (kto == "Uczniowie")
                {
                    label3.Text = "Klasa";

                    Uczen szkolniak = db.Uczens.Single(p => p.IdUczen == ID);
                    
                    szkolniak.Imie = textBox1.Text;
                    szkolniak.Nazwisko = textBox2.Text;
                    szkolniak.Klasa = textBox3.Text.ToUpper();

                    try
                    {
                        db.SubmitChanges();

                        MessageBox.Show("Wpis został poprawiony",
                            "Poprawianie", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (System.Data.SqlClient.SqlException)
                    {
                        MessageBox.Show("Żle wprowadzona klasa. Proszę wpisać poprawną wartość np. 2A",
                            "błąd",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Popraw_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Lazy<Edycja> edycja = new Lazy<Edycja>(() => new Edycja(wsk));
            edycja.Value.Show();
        }
    }
}
