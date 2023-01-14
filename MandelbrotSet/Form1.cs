using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Matlab;
namespace MandelbrotSet
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

        private void Form1_Shown(object sender, EventArgs e)
        {
        }
        private double map(double value, double start, double end, double a, double b)
        {
            return (value - start) * (b - a) / (end - start) + a;
        }
        private void drowMandelbort(int iter,int n)
        {
            double minZome = -2,MaxZome=2;
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            Bitmap bitmap = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    double x = map(i, 0, w, minZome, MaxZome);
                    double y = map(j, 0, h, minZome, MaxZome);
                    Complex c = new Complex(x, y);
                    Complex z = 0;
                    int k = 0;
                    do
                    {
                        z = z*z + c;
                        if (z.ABS > 2) break;
                        k++;
                    } while (k < iter);
                    Color co1 = Color.Black;
                    double hu = Math.Sqrt(k * 1.0 / iter);
                    if (iter != k) co1 = SuperColor.FromAhsl(hu * 100);
                    bitmap.SetPixel(i, j, co1);

                }
            }
            pictureBox1.Image = bitmap;
        }
        private void drawJuliaSet(int iter, Complex c)
        {
            double minZome = -2, MaxZome = 2;
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            Bitmap bitmap = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    double x = map(i, 0, w, minZome, MaxZome);
                    double y = map(j, 0, h, minZome, MaxZome);
                    Complex z = new Complex(x,y);
                    int k = 0;
                    do
                    {
                        z = z * z + c;
                        if (z.ABS > MaxZome-minZome) break;
                        k++;
                    } while (k < iter);
                    Color co1 = Color.Black;
                    double hu=Math.Sqrt(k*1.0/iter);
                    if (iter != k) co1 = SuperColor.FromAhsl(hu * 100);
                    bitmap.SetPixel(i, j, co1);

                }
            }
            pictureBox1.Image = bitmap;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            drowMandelbort(255,2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Complex c = Complex.Parse(comboBox1.Text);
                drawJuliaSet(255, c);
            }
            catch
            { }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //double x = map(Form1.MousePosition.X, 0, Width, -1, 1);
            //double y = map(Form1.MousePosition.Y, 0, Height, -1, 1);
            //Complex c = new Complex(x, y);
            //drawJuliaSet(100, c);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //double angel = 0;
            //while (true)
            //{
            //    Complex c = Maths.Cos(angel);
            //    drawJuliaSet(100, c);
            //    angel+=0.02;
            //}

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
    }
}
