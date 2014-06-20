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
    public partial class Menu : Form
    {
        public Form1 wsk;
        public int id;

        public Menu()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public Menu(Form1 glowny)
        {
            InitializeComponent();
            wsk = glowny;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
           

            using (DziennikDataContext db = new DziennikDataContext())
            {
                var nauczyciel =
                    from c in db.Nauczyciels
                    select c;

                foreach (var item in nauczyciel)
                {
                    comboBox2.Items.Add(((item.Imie).Trim()+" "+(item.Nazwisko).Trim()));
                }

                var uczen =
                    (from u in db.Uczens
                     select new
                     {
                         klasa = u.Klasa
                     }).Distinct();

                foreach (var item in uczen)
                {
                    comboBox1.Items.Add(item.klasa);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //edycja
        {
           Lazy<Edycja> edycja = new Lazy<Edycja>(() => new Edycja(wsk));
           edycja.Value.Show();
           this.Close();
        }

        private void button1_Click(object sender, EventArgs e) //idź
        {
            try
            {
                using (DziennikDataContext db = new DziennikDataContext())
                {
                    string dana = comboBox2.SelectedItem.ToString();
                    char[] znak = new char[] {' '};
                    string[] imieInazwisko = dana.Split(znak, StringSplitOptions.RemoveEmptyEntries);

                    this.id = db.Nauczyciels.Single(p => p.Imie == imieInazwisko[0] &&
                        p.Nazwisko == imieInazwisko[1]).IdNauczyciel;
                }
                wsk.idNauczyciel = this.id;
                wsk.kto = comboBox2.SelectedItem.ToString();
                wsk.klasa = comboBox1.SelectedItem.ToString();
                wsk.Odswiez();
                this.Close();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Proszę wybrać nauczyciela prowadzącego oraz klasę.",
                    "Brak wyboru",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }
        }   
    }
}
