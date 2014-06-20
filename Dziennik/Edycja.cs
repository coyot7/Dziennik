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
    public partial class Edycja : Form
    {
        public Form1 wsk;
        private string kto { get; set; }
        private int ID { get; set; }

        public Edycja()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public Edycja(Form1 other)
        {
            InitializeComponent();
            this.wsk = other;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            using (DziennikDataContext db = new DziennikDataContext())
            {
                if (comboBox1.SelectedItem.ToString() == "Nauczyciele")
                {
                    var Nauczyciel = db.GetTable<Nauczyciel>();

                    dataGridView1.DataSource = Nauczyciel;
                    dataGridView1.Columns[0].Visible = false;
                }
                if (comboBox1.SelectedItem.ToString() == "Uczniowie")
                {
                    var Uczen = db.GetTable<Uczen>();

                    dataGridView1.DataSource = Uczen;
                    dataGridView1.Columns[0].Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) //dodawanie
        {
            Lazy<Dodawacz> dodawanie = new Lazy<Dodawacz>(() => new Dodawacz(wsk));
            dodawanie.Value.Show();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e) //update
        {
            try
            {
                if (comboBox1.SelectedItem.ToString() == "Nauczyciele")
                {
                    ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdNauczyciel"].Value);
                    kto = comboBox1.SelectedItem.ToString();
                }
                if (comboBox1.SelectedItem.ToString() == "Uczniowie")
                {
                    ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdUczen"].Value);
                    kto = comboBox1.SelectedItem.ToString();
                }
                Lazy<Popraw> popraw = new Lazy<Popraw>(() => new Popraw(ID, kto, wsk));
                popraw.Value.Show();
                this.Dispose();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Proszę wskazać osobę do poprawy.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e) //usun
        {
            try
            {
                if (comboBox1.SelectedItem.ToString() == "Nauczyciele")
                {
                    ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdNauczyciel"].Value);
                    kto = comboBox1.SelectedItem.ToString();
                }
                if (comboBox1.SelectedItem.ToString() == "Uczniowie")
                {
                    ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdUczen"].Value);
                    kto = comboBox1.SelectedItem.ToString();
                }

                Lazy<Usun> usun = new Lazy<Usun>(() => new Usun(ID, kto, wsk));
                usun.Value.Show();
                this.Dispose();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Proszę wskazać osobę do usunięcia.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Edycja_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            this.wsk.Odswiez();
        }
    }
}
