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
    public partial class Form1 : Form
    {
        public string klasa;
        public string kto; //nauczyciel
        public int iD;
        public int idNauczyciel;
        public bool kolumna3istnienie = false;
        public bool kolumna4istnienie = false;
        public bool kolumna5istnienie = false;
        public int okno = 1; //identyyfikator dla Form1

        public Form1()
        {
            InitializeComponent();
            Menu menu = new Menu(this);
            menu.Show();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        public void Odswiez()
        {
            //usuwanie 3 kolumny
            if (kolumna3istnienie == true)
            {
                dataGridView1.Columns.Remove("Ilość ocen");
            }

            //usuwanie 4 kolumny
            if (kolumna4istnienie == true)
            {
                dataGridView1.Columns.Remove("Mediana");
            }

            //usuwanie 5 kolumny
            if (kolumna5istnienie == true)
            {
                dataGridView1.Columns.Remove("Srednia");
            }

            dataGridView1.ReadOnly = true;
            using (DziennikDataContext db = new DziennikDataContext())
            {
                var display = (from u in db.Uczens
                               where (u.Klasa == this.klasa)
                               orderby u.Nazwisko
                               select new
                               {
                                   u.IdUczen,
                                   u.Imie,
                                   u.Nazwisko,
                               });
                dataGridView1.DataSource = display;
                dataGridView1.Columns[0].Visible = false;

                //dodawanie "3" kolumny
                DataGridViewColumn kolumna3 = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                kolumna3.CellTemplate = cell;
                kolumna3.Name = "Ilość ocen";
                dataGridView1.Columns.Insert(3, kolumna3);
                kolumna3istnienie = true;

                //wpisywanie ilosci ocen do 3 kolumny
                int iloscWierszy = dataGridView1.RowCount;
                int idd;
                for (int i = 0; i < iloscWierszy; i++)
                {
                    idd = (int)dataGridView1[0, i].Value;
                    int iloscOcen = (from u in db.Ocenas
                                     where (u.IdUczen == idd && u.IdNauczyciel == idNauczyciel)
                                     select u.Stopien).Count();
                    dataGridView1[3, i].Value = iloscOcen;
                }

                //dodawanie "4" kolumny
                DataGridViewColumn kolumna4 = new DataGridViewColumn();
                DataGridViewCell cell4 = new DataGridViewTextBoxCell();
                kolumna4.CellTemplate = cell4;
                kolumna4.Name = "Mediana";
                dataGridView1.Columns.Insert(4, kolumna4);
                kolumna4istnienie = true;

                //wpisywanie mediany do 4 kolumny
                iloscWierszy = dataGridView1.RowCount;
                
                for (int i = 0; i < iloscWierszy; i++)
                {
                    idd = (int)dataGridView1[0, i].Value;
                    var mediana = (from u in db.Ocenas
                                   where (u.IdUczen == idd && u.IdNauczyciel == idNauczyciel)
                                   orderby u.Stopien
                                   select new
                                   {
                                       Ocena = u.Stopien
                                   }).ToArray();
                    int dlugoscCiagu = mediana.GetLength(0);
                    if (dlugoscCiagu == 0)
                    {
                        dataGridView1[4, i].Value = " ";
                    }
                    else if (dlugoscCiagu == 1)
                    {
                        dataGridView1[4, i].Value = (double)mediana[0].Ocena;
                    }
                    else if (dlugoscCiagu == 2)
                    {
                        dataGridView1[4, i].Value = (double)(mediana[0].Ocena + mediana[1].Ocena) / 2.0;
                    }
                    else if (dlugoscCiagu % 2 != 0)
                    {
                        int index;
                        index = ((dlugoscCiagu + 1) / 2);
                        dataGridView1[4, i].Value = (double)mediana[index].Ocena;
                    }
                    else if (dlugoscCiagu % 2 == 0)
                    {
                        int index;
                        index = ((dlugoscCiagu + 1) / 2);
                        dataGridView1[4, i].Value =
                            (double)(mediana[index].Ocena + mediana[index + 1].Ocena) /2.0;
                    }   
                } 

                //dodawanie "5" kolumny
                DataGridViewColumn kolumna5 = new DataGridViewColumn();
                DataGridViewCell cell5 = new DataGridViewTextBoxCell();
                kolumna5.CellTemplate = cell5;
                kolumna5.Name = "Srednia";
                dataGridView1.Columns.Insert(5, kolumna5);
                kolumna5istnienie = true;

                //wpisywanie sredniej do 5 kolumny
                iloscWierszy = dataGridView1.RowCount;
                for (int i = 0; i < iloscWierszy; i++)
                {
                    
                    idd = (int)dataGridView1[0, i].Value;
                    var srednia = (from u in db.Ocenas
                                   where (u.IdUczen == idd && u.IdNauczyciel == idNauczyciel)
                                   select new
                                   {
                                       Ocena = u.Stopien
                                   }).ToArray();
                    
                    double suma = 0;
                    for (int j = 0; j < srednia.GetLength(0); j++ )
                    {
                            suma += (double)srednia[j].Ocena;
                    }

                    dataGridView1[5, i].Value = (suma / srednia.GetLength(0)).ToString("F2");
                    if (dataGridView1[5, i].Value.ToString() == "nie jest liczbą")
                    {
                        dataGridView1[5, i].Value = "";
                    }
                }
                

                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void button1_Click(object sender, EventArgs e)  //menu
        {
            Lazy<Menu> menu = new Lazy<Menu>(() => new Menu(this));
            menu.Value.Show();
        }

        private void button2_Click(object sender, EventArgs e) //pozkaz
        {
            try
            {
                iD = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdUczen"].Value);
                Lazy<Pokaz> pokaz = new Lazy<Pokaz>(() => new Pokaz(this, iD));
                pokaz.Value.Show();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Proszę wybrać ucznia",
                    "Brak wyboru",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e) //dodaj ocene
        {
            try
            {
                iD = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdUczen"].Value);
                Lazy<DodajOcene> ocena = new Lazy<DodajOcene>(() => new DodajOcene(this, iD, okno));
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
    }
}
