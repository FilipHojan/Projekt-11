using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotnisko_1._0
{
    public partial class Form1 : Form
    {
        public static List<string> dane = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        public List<Lotnisko> LoadCSV(string csvFile)
        {
            var query = from l in File.ReadLines(csvFile)
                        let data = l.Split(',')
                        select new Lotnisko
                        {
                            Miasto = data[0],
                            Wojewodztwo = data[1],
                            ICAO = data[2],
                            IATA = data[3],
                            Nazwa = data[4],
                            LPasazerow = data[5],
                            Statystyki = data[6]
                        };
            return query.ToList();
        }

        public class Lotnisko
        {
            public string Nazwa { get; set; }
            public string ICAO { get; set; }
            public string IATA { get; set; }
            public string LPasazerow { get; set; }
            public string Wojewodztwo { get; set; }
            public string Miasto { get; set; }
            public string Statystyki { get; set; }
        }

        private DataTable ReadExcel(string fileName)
        {
            IronXL.WorkBook workbook = IronXL.WorkBook.Load(fileName);
            IronXL.WorkSheet sheet = workbook.DefaultWorkSheet;
            return sheet.ToDataTable(true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            dataGridView1.DataSource = LoadCSV(dlg.FileName);
            for (int i = 1; i < 7; i++)
            {
                this.dataGridView1.Columns[i].Visible = false;
            }
            dataGridView1.AutoResizeColumn(0);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                if (checkedListBox1.CheckedIndices.Count > 0)
                {
                    string tmp = "";
                    dane.Clear();
                    //szczegoly
                    dane.Add(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    if (checkedListBox1.CheckedIndices.Contains(0))
                    {
                        tmp = "Kod ICAO: ";
                        tmp += dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                        dane.Add(tmp);
                    }
                    if (checkedListBox1.CheckedIndices.Contains(1))
                    {
                        tmp = "Kod IATA: ";
                        tmp += dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
                        dane.Add(tmp);
                    }
                    if (checkedListBox1.CheckedIndices.Contains(2))
                    {
                        tmp = "Liczba pasażerów: ";
                        tmp += dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
                        dane.Add(tmp);
                    }
                    if (checkedListBox1.CheckedIndices.Contains(3))
                    {
                        tmp = "Województwo: ";
                        tmp += dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
                        dane.Add(tmp);
                    }
                    if (checkedListBox1.CheckedIndices.Contains(4))
                    {
                        tmp = "Miasto: ";
                        tmp += dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
                        dane.Add(tmp);
                    }
                
                    Form2 form2 = new Form2();
                    form2.Show();
                }
            }
        }
    }
}
