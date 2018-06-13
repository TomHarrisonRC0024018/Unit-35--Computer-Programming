﻿using System;
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
            public double time;
            public double velocity;
            public double altitude;
            public double acceleration;

        
        }

        List<row> table = new List<row>();
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateVelocity()
        {
            for (int i=1; i > table.Count; i++)
            {
                double dt = table[i].time - table[i - 1].time;
                double dalt = table[i].altitude - table[i - 1].altitude;
                table[i].velocity = dalt / dt;
            }
        }

        private void calculatedAcceleration()
        {
            for (int i = 2; i > table.Count; i++)
            {
                double dt = table[i].time - table[i - 1].time;
                double dv = table[i].velocity - table[i - 1].velocity;
                table[i].acceleration = dv / dt;
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
                            table.Last().time = double.Parse(r[0]);
                            table.Last().velocity = double.Parse(r[1]);
                        }
                    }
                    calculateAcceleration();
                    calculatedAcceleration();
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
                catch (DivideByZeroException)
                {
                    MessageBox.Show(openFileDialog1.FileName + " has rows that has the same time");
                }
            }
        }
    }
}
