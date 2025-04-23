using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab2
{
    public partial class Form1 : Form
    {

        private ArrayList coordinates = new ArrayList();

        public Form1()
        {
            InitializeComponent();

            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                this.coordinates.Add(p);
                this.Invalidate();
            } 
            else if (e.Button == MouseButtons.Right)
            {
                coordinates.Clear();
                this.Invalidate();
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            const int WIDTH = 10;
            const int HEIGHT = 10;
            Graphics g = e.Graphics;

            foreach(Point p in this.coordinates)
            {
                g.FillEllipse(Brushes.Black, p.X - WIDTH / 2, p.Y - WIDTH / 2, WIDTH, HEIGHT);
            }

            if(checkBox2.Checked && checkBox3.Checked)
            {
                MessageBox.Show("Error: Both check boxes can't be checked, either one or none must be checked.");
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
            else if (checkBox2.Checked)
            {
                for(int i = 0; i < this.coordinates.Count; i++)
                {
                    Point current = (Point)this.coordinates[i];
                    Point next = (Point)this.coordinates[(i + 1) % coordinates.Count]; // % coordinates.Count makes the last point loop back around and connect to the first
                    
                    g.DrawLine(Pens.Black, current, next);
                }
            }
            else if (checkBox3.Checked)
            {
                for(int i = 0; i < this.coordinates.Count; i++)
                {
                    for(int j = i + 1; j < coordinates.Count; j++)
                    {
                        g.DrawLine(Pens.Black, (Point)this.coordinates[i], (Point)this.coordinates[j]);
                    }
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
