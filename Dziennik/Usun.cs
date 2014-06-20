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
    public partial class Usun : Form
    {
        public Form1 wsk;
        private int ID { get; set; }
        private string kto { get; set; }

        public Usun()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public Usun(int ID, string kto, Form1 other)  //automatyczne wypełnieni pól starymi wartościami
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
                    label4.Text = "osoba uczy przedmiotu";

                    label2.Text = (from p in db.Nauczyciels
                                     where p.IdNauczyciel == ID
                                     select p.Imie
                                     ).Single();
                    label3.Text = (from p in db.Nauczyciels
                                     where p.IdNauczyciel == ID
                                     select p.Nazwisko
                                     ).Single();
                    label5.Text = (from p in db.Nauczyciels
                                     where p.IdNauczyciel == ID
                                     select p.Przedmiot
                                     ).Single();
                }
                
                if (kto == "Uczniowie")
                {
                    label4.Text = "z klasy";

                    label2.Text = (from p in db.Uczens
                                     where p.IdUczen == ID
                                     select p.Imie
                                     ).Single();
                    label3.Text = (from p in db.Uczens
                                     where p.IdUczen == ID
                                     select p.Nazwisko
                                     ).Single();
                    label5.Text = (from p in db.Uczens
                                     where p.IdUczen == ID
                                     select p.Klasa
                                     ).Single();
                }
            }
        }

        private void Usun_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Lazy<Edycja> edycja = new Lazy<Edycja>(() => new Edycja(wsk));
            edycja.Value.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var odpowiedz = MessageBox.Show("Czy na pewno chcesz usunąć tę osobę?\n"+
            "Zostaną usunięte także oceny !!",
                "Potwierdzenie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (odpowiedz == DialogResult.No)
            {
                this.Close();
            }
            if (odpowiedz == DialogResult.Yes)
            {
                using (DziennikDataContext db = new DziennikDataContext())
                {
                    if (kto == "Nauczyciele")
                    {
                        var noty = (from n in db.Ocenas
                                    where n.IdNauczyciel == ID
                                    select n);
                        try
                        {
                            foreach (var item in noty)
                            {
                                db.Ocenas.DeleteOnSubmit(item);
                                db.SubmitChanges();
                            }
                        }
                        catch (Exception bl)
                        {
                            MessageBox.Show("Błąd połączenia z bazą\n" + bl);
                        }

                        Nauczyciel belfer = db.Nauczyciels.Single(p => p.IdNauczyciel == ID);
                        try
                        {
                            db.Nauczyciels.DeleteOnSubmit(belfer);
                            db.SubmitChanges();

                            MessageBox.Show("Wpis został usunięty",
                                "Usuwanie", MessageBoxButtons.OK,
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
                        var noty = (from n in db.Ocenas
                                    where n.IdUczen == ID
                                    select n);
                        try
                        {
                            foreach (var item in noty)
                            {
                                db.Ocenas.DeleteOnSubmit(item);
                                db.SubmitChanges();
                            }
                        }
                        catch (Exception bl)
                        {
                            MessageBox.Show("Błąd połączenia z bazą\n" + bl);
                        }

                        Uczen szkolniak = db.Uczens.Single(p => p.IdUczen == ID);
                        try
                        {
                            db.Uczens.DeleteOnSubmit(szkolniak);
                            db.SubmitChanges();

                            MessageBox.Show("Wpis został usunięty",
                                "Usuwanie", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception bl)
                        {
                            MessageBox.Show("Błąd połączenia z bazą\n" + bl);
                        }
                    }
                }
            }

        }
    }
}
