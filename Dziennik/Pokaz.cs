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
    public partial class Pokaz : Form
    {
        public Form1 wsk;
        public int iD;
        public int okno = 2; //identyfikator dla Pokaz
        public int idOcena;

        public Pokaz()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public Pokaz(Form1 other, int ID)
        {
            InitializeComponent();
            wsk = other;
            this.iD = ID;
            Odswiez();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public void Odswiez()
        {
            using (DziennikDataContext db = new DziennikDataContext())
            {
                Uczen uczniak = db.Uczens.Single(p => p.IdUczen == iD);
                label1.Text = uczniak.Imie.Trim() + " " + uczniak.Nazwisko.Trim();

                dataGridView1.ReadOnly = true;
                var display = (from o in db.Ocenas 
                               join n in db.Nauczyciels on o.IdNauczyciel equals n.IdNauczyciel
                               where (o.IdUczen == iD && n.IdNauczyciel == wsk.idNauczyciel)
                               select new
                               {
                                   o.IdUczen,
                                   o.IdOcena,
                                   o.Stopien,
                                   o.Data,
                                   o.Opis
                               });
                dataGridView1.DataSource = display;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e) //dodawanie oceny
        {
            try
            {
                Lazy<DodajOcene> ocena = new Lazy<DodajOcene>(() => new DodajOcene(wsk, iD, okno, this));
                ocena.Value.Show();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Proszę wybrać ucznia",
                    "Brak wyboru",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Pokaz_FormClosed(object sender, FormClosedEventArgs e) //zamykanie okna
        {
            wsk.Odswiez();
        }

        private void button2_Click(object sender, EventArgs e) //edytowanie wpisu oceny
        {
            try
            {
                idOcena = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOcena"].Value);

                Lazy<EdytujOcene> ocena = new Lazy<EdytujOcene>(() => 
                    new EdytujOcene(iD, okno, this, idOcena, wsk));
                ocena.Value.Show();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Proszę wybrać ucznia",
                    "Brak wyboru",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e) //usuwanie wpisu
        {
                idOcena = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOcena"].Value);

             var odpowiedz = MessageBox.Show("Czy na pewno chcesz usunąć tę ocenę?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (odpowiedz == DialogResult.No)
            {
            }
            if (odpowiedz == DialogResult.Yes)
            {
                try
                {
                    using (DziennikDataContext db = new DziennikDataContext())
                    {
                        var noty = (from o in db.Ocenas
                                    where o.IdOcena == idOcena
                                    select o);

                        foreach (var item in noty)
                        {
                            db.Ocenas.DeleteOnSubmit(item);
                            db.SubmitChanges();
                        }
                    }
                    Odswiez();
                }
                catch (Exception bl)
                {
                    MessageBox.Show("Błąd połączenia z bazą\n" + bl);
                }
            }
            
        }
    }
}
