using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenDrawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        bool darken_mod = false;
        bool blood_mod = false;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (darken_mod)
            {
                darken();
            }

            if (blood_mod)
            {
                blood();
            }
        }

        List<Rectangle> blood_items = new List<Rectangle>();
        int c = 2;
        void blood()
        {
            Invalidate();
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                //g.DrawRectangle(Pens.Black, r.Next(136) * 10, r.Next(76) * 10, 10, 10);
                Rectangle rect = new Rectangle( r.Next(1366), 10, 10, 10);
                blood_items.Add(rect);
                g.FillRectangle(Brushes.DarkRed, rect);

                foreach (Rectangle rr in blood_items)
                {
                    Rectangle rr_ = new Rectangle(rr.X, rr.Y + c, 10, 10);
                    g.FillRectangle(Brushes.DarkRed, rr_);
                }
                c++;
            }
        }

        Random r = new Random();
        void darken()
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                //g.DrawRectangle(Pens.Black, r.Next(136) * 10, r.Next(76) * 10, 10, 10);
                g.FillRectangle(Brushes.Black, r.Next(1366), r.Next(768), 20, 20);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            darken_mod = true;
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            blood_mod = true;
            timer1.Start();
        }
    }
}
