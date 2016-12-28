using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic_Sq
{
    public partial class Form1 : Form
    {
        Bitmap bmp = new Bitmap(1000, 1000);
        public Form1()
        {
            InitializeComponent();
        }
        int m = 0, n = 0;   int u = 50, p = 50;    int tx = 500, ty = 350;

        private void button1_Click(object sender, EventArgs e)
        { colorDialog2.ShowDialog();
            pictureBox1.BackColor = colorDialog2.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;colorDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToInt16(textBox1.Text)+1).ToString();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            if ((m == 0) && (n == 0))
            {
                sq();
                m = m + 1; ;
                n = 0;
            }
            else if ((m < tx) && (n == 0))
            {
                sq();
                m = m + 1;
                n = 0;
            }
            else if ((m == tx) && (n == 0))
            {
                sq();
                n = n + 1;
                m = m;
            }

            else if ((m == tx) && (n < ty))
            {
                sq();
                n = n + 1;
                m = m;
            }
            else if ((m == tx) && (n == ty))
            {
                sq();
                m = m - 1;
                n = n;
            }
            else if ((m > 0) && (n == ty))
            {
                sq();
                m = m - 1;
                n = n;
            }
            else if ((m == 0) && (n <= ty))
            {
                sq();
                n = n - 1;
                m = 0;
            }

            this.Text = tx.ToString() + " :Tx , " + ty.ToString() + ":Ty " + " , " + m.ToString()+" , "+n.ToString()+" " ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.Blue;  tx = 500; ty = 350;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {if (trackBar1.Value != 0)
                textBox1.Text = Convert.ToString(trackBar1.Value * 10);
            else
                textBox1.Text = "1";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
                tx = Convert.ToUInt16(textBox2.Text);
                m = 0; n = 0;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
                ty = Convert.ToUInt16(textBox3.Text);
                m = 0; n = 0;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(trackBar2.Value * 50);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(trackBar3.Value * 50);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(textBox1.Text)!=1)
            {
                textBox1.Text = (Convert.ToInt16(textBox1.Text) - 1).ToString();
            }
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            p = Convert.ToUInt16(textBox5.Text);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(trackBar5.Value * 5);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            textBox5.Text = Convert.ToString(trackBar4.Value * 5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            trackBar5.Value = 10; textBox5.Text = "50";
            trackBar4.Value = 10; textBox4.Text = "50";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 0; textBox1.Text = "1";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            u = Convert.ToUInt16(textBox4.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(textBox1.Text) != 0)
                timer1.Interval = Convert.ToInt16(textBox1.Text);
            else
                timer1.Interval = 1;
        }

        public void sq()
        {
            pictureBox1.Image = bmp; 
            for (int i = m; i <= m + u; i++)
            {
                for (int j = n; j <= n + p; j++)
                {
                    bmp.SetPixel(i, j, colorDialog1.Color);

                }
            }
        }
    }
}
