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
    public partial class Dodawacz : Form
    {
        public Form1 wsk;

        public Dodawacz()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public Dodawacz(Form1 other)
        {
            InitializeComponent();
            this.wsk = other;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DziennikDataContext db = new DziennikDataContext())
            {
                if (comboBox1.SelectedItem.ToString() == "Nauczyciel")
                {
                    label4.Text = "Przedmiot";
                    label4.Update();
                    label5.Text = "   ";
                    label5.Update();
                }
                if (comboBox1.SelectedItem.ToString() == "Uczeń")
                {
                    label4.Text = "Klasa";
                    label4.Update();
                    label5.Text = "Polę klasa należy uzupełnić\ncyfrą oraz literą np. 2A";
                    label5.Update();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DziennikDataContext db = new DziennikDataContext())
            {
                try
                {
                    if (comboBox1.SelectedItem.ToString() == "Nauczyciel")
                    {
                        Nauczyciel belfer = new Nauczyciel
                        {
                            Imie = textBox1.Text,
                            Nazwisko = textBox2.Text,
                            Przedmiot = textBox3.Text
                        };
                        try
                        {
                            db.Nauczyciels.InsertOnSubmit(belfer);
                            db.SubmitChanges();

                            MessageBox.Show("Dodano wpis poprawnie.",
                                "Dodawanie wpisu", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception bl)
                        {
                            MessageBox.Show("Błąd połączenia z bazą\n" + bl);
                        }

                    }
                    if (comboBox1.SelectedItem.ToString() == "Uczeń")
                    {
                        Uczen uczniak = new Uczen
                        {
                            Imie = textBox1.Text,
                            Nazwisko = textBox2.Text,
                            Klasa = textBox3.Text.ToUpper()
                        };
                        try
                        {
                            db.Uczens.InsertOnSubmit(uczniak);
                            db.SubmitChanges();

                            MessageBox.Show("Dodano wpis poprawnie.",
                                "Dodawanie wpisu", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            this.Close();
                        }
                        
                        catch (System.Data.SqlClient.SqlException)
                        {
                            MessageBox.Show("Źle wprowadzono polę klasa.\nProszę poprawić.",
                                "Bład dodawania wpisu", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }

                    }

                }
                catch (System.NullReferenceException)
                {
                    MessageBox.Show("Proszę wybrać osobę z rozwijanej listy",
                        "Błąd dodawania", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void Dodawacz_FormClosed(object sender, FormClosedEventArgs e)
        {
            Lazy<Edycja> edycja = new Lazy<Edycja>(() => new Edycja(wsk));
            edycja.Value.Show();
        } 
    }
}
