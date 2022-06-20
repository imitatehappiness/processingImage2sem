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

namespace num1
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        float R, G, B;
        String Path = @"D:\DOCUMENTS\programm\study\processingImage2sem\test500px.jpg";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // e.Graphics.DrawImage(new Bitmap(@"D:\DOCUMENTS\photo\zen.jpg"), 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            pictureBox1.Image = bmp;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            for (int x = 0; x < bmp.Width; x++) {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    byte gray = (byte)(0.3 * r + 0.59 * g + 0.11 * b);
                    bmp.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox1.Image = bmp;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            R = (float)trackBar1.Value / 100;
            label1.Text = "Red: " + R.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            G = (float)trackBar2.Value / 100;
            label2.Text = "Green: " + G.ToString();

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            B = (float)trackBar3.Value / 100;
            label3.Text = "Blue: " + B.ToString();

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label5.Text = "p: " + (float)trackBar4.Value;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    byte gray = (byte)(r * R + g * G + b * B);
                    bmp.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            int p = (int)trackBar4.Value;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    if (r >= p) {
                        r = (byte)(255 - r);
                    }
                    if (g >= p) {
                        g = (byte)(255 - g);
                    }
                    if (b >= p)
                    {
                        b = (byte)(255 - b);
                    }
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            int p = (int)trackBar4.Value;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    byte gray = (byte)(0.3 * r + 0.59 * g + 0.11 * b);
                    if (gray >= p)
                    {
                        gray = (byte)(255 - gray);
                    }
                    bmp.SetPixel(x, y, Color.FromArgb( gray, gray, gray));
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            int p = (int)trackBar4.Value;
 
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    byte gray = (byte)(0.3 * r + 0.59 * g + 0.11 * b);
                    if (gray > p)
                    {
                        gray = 255;
                    }
                    else {
                        gray = 0;
                    }
                    bmp.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            int Q1 = 50;
            int Q2 = 150;
 
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    byte gray = (byte)(0.3 * r + 0.59 * g + 0.11 * b);
                    if (gray < Q1)
                    {
                        gray = 0;
                    }
                    else if (gray > Q2)
                    {
                        gray = 255;
                    }
                    else {
                        gray = (byte)((float)(gray - Q1) / (Q2 - Q1) * 255);
                    }
                    bmp.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            int Q1 = 50;
            int Q2 = 150;
 
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    byte gray = (byte)(r + g + b);
                    if (r < Q1)
                    {
                        r = 0;

                    }
                    else if (r > Q2)
                    {
                        r = 255;

                    }
                    else
                    {
                        r = (byte)((float)(r - Q1) / (Q2 - Q1) * 255);

                        //gray = (byte)((float)(gray - Q1) / (Q2 - Q1) * 255);
                    }
                    if (g < Q1)
                    {
                        g = 0;

                    }
                    else if (g > Q2)
                    {
                        g = 255;

                    }
                    else
                    {
                        g = (byte)((float)(g - Q1) / (Q2 - Q1) * 255);

                        //gray = (byte)((float)(gray - Q1) / (Q2 - Q1) * 255);
                    }
                    if (b < Q1)
                    {
                        b = 0;

                    }
                    else if (b > Q2)
                    {
                        b = 255;

                    }
                    else
                    {
                        b = (byte)((float)(b - Q1) / (Q2 - Q1) * 255);

                        //gray = (byte)((float)(gray - Q1) / (Q2 - Q1) * 255);
                    }
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            int p = (int)trackBar4.Value;
 
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    if (r > p)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = 0;
                    }

                    if (g > p)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = 0;
                    }

                    if (b > p)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = 0;
                    }
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            int Q1 = 50;
            int Q2 = 150;
 
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    byte gray = (byte)(0.3 * r + 0.59 * g + 0.11 * b);
                    gray = (byte)(Q1 + gray * (Q2 - Q1) / 255);
                    bmp.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox1.Image = bmp;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            int Q1 = 50;
            int Q2 = 150;
 
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    r = (byte)(Q1 + r * (Q2 - Q1) / 255);
                    g = (byte)(Q1 + g * (Q2 - Q1) / 255);
                    b = (byte)(Q1 + b * (Q2 - Q1) / 255);
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            int gamma = 2;
 
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;
                    byte gray = (byte)(0.3 * r + 0.59 * g + 0.11 * b);

                    int res = (int)(255 * Math.Pow(((float)gray / 255), gamma));
                    gray = (byte)(res);

                    bmp.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            float gamma = (float)(2);
 
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    byte r = pixel.R;
                    byte g = pixel.G;
                    byte b = pixel.B;

                    float res1 = (float)(255 * Math.Pow(((float)r / 255), gamma));
                    r = (byte)(res1);

                    float res2 = (float)(255 * Math.Pow(((float)g / 255), gamma));
                    g = (byte)(res2);

                    float res3 = (float)(255 * Math.Pow(((float)b / 255), gamma));
                    b = (byte)(res3);
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            int levelCount = (int)numericUpDown1.Value;
            var m = 256 / levelCount;

 
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (levelCount > 0) {
                        Color pixel = bmp.GetPixel(x, y);
                        byte r = (byte)((pixel.R / m) * m);
                        byte g = (byte)((pixel.G / m) * m);
                        byte b = (byte)((pixel.B / m) * m);

                        bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }

                }
            }
            pictureBox1.Image = bmp;

        }

        Color[] colorVar = { Color.Black, Color.Blue, Color.Green, Color.Red, Color.Yellow };

        private void button15_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            int levelCount = colorVar.Count() - 1;
            var m = 255 / levelCount ;

 
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    int  indR = pixel.R / m ;
                    int  indG = pixel.G / m ;
                    int  indB = pixel.B / m ;

                    bmp.SetPixel(x, y, Color.FromArgb(colorVar[(int)indR].R, colorVar[(int)indR].G, colorVar[(int)indR].B));
                    

                }
            }
            pictureBox1.Image = bmp;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 1) {
                numericUpDown1.Value = 1;
            }
        }

       


        /// ////////////////////////////        /// ////////////////////////////


        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = 4;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
