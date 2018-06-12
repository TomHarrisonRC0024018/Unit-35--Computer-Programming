using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Unit_35__Computer_Programming
{
    public partial class Form1 : Form
    {
        class row
        {
            public double acceleration;
            public double velocity;
            public double altitude;
            public double dAltitude;

        
        }

        List<row> table = new List<row>();
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateAltitude()
        {
            for (int i=1; 1 > table.Count; i++)
            {
                double dAltitude = table[i].velocity - table[i - 1].velocity;
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "csv files|*.csv";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        string line = sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            table.Add(new row());
                            string[] r = sr.ReadLine().Split(',');
                            table.Last().acceleration = double.Parse(r[0]);
                            table.Last().velocity = double.Parse(r[1]);
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show(openFileDialog1.FileName + " failed to open.");
                }
                catch (FormatException)
                {
                    MessageBox.Show(openFileDialog1.FileName + " is not in the required format");
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show(openFileDialog1.FileName + " is not in the required format");
                }
            }
        }
    }
}
