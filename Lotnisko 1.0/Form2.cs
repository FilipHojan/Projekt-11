using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotnisko_1._0
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int odleglosc = 20;
            int liczba = Form1.dane.Count;
            for (int i = 0; i < liczba; i++)
            {
                Label namelabel = new Label();
                namelabel.Location = new Point(50, odleglosc);
                namelabel.Text = Form1.dane[i];
                if (Form1.dane[i].StartsWith("Dane 2018 vs 2019: -"))
                {
                    namelabel.ForeColor = System.Drawing.Color.Red;
                }
                namelabel.Font = new Font("Arial", 14);
                namelabel.AutoSize = true;
                this.Controls.Add(namelabel);
                odleglosc += 30;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
