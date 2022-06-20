using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filter
{
    public partial class Form1 : Form
    {
        String Path = @"D:\DOCUMENTS\programm\study\processingImage2sem\test300px.jpg";
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(Path);
            pictureBox1.Image = bmp;
        }

        private void LowFilter_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height);
            int SIZE_ARR = (int)(numericUpDown1.Value);
            int indent = (int)(SIZE_ARR / 2);

            int[,] H1 = new int[SIZE_ARR, SIZE_ARR];
            
            int del = 0;
            for (int i = 0; i < SIZE_ARR; i++)
            {
                for (int j = 0; j < SIZE_ARR; j++)
                {
                    H1[i, j] = 1;
                    del += H1[i, j];
                }
            }

            for (int x = indent; x < bmp.Width - indent; x++)
            {
                for (int y = indent; y < bmp.Height - indent; y++)
                {
                    int responseFilterR = 0;
                    int responseFilterG = 0;
                    int responseFilterB = 0;

                    int _x = x - indent, _y = y - indent;
                    int k = 0, l = 0;
                    
                    for (int i = _x; i < SIZE_ARR + _x  ; i++) {
                        l = 0;
                        for (int j = _y; j < SIZE_ARR + _y; j++)
                        {
                            responseFilterR += H1[k, l] * bmp.GetPixel(i, j).R;
                            responseFilterG += H1[k, l] * bmp.GetPixel(i, j).G;
                            responseFilterB += H1[k, l] * bmp.GetPixel(i, j).B;
                            l++;

                        }
                        k++;
                    }

                    responseFilterR = (int)(responseFilterR  / del);
                    responseFilterG = (int)(responseFilterG  / del);
                    responseFilterB = (int)(responseFilterB  / del);
                    if (responseFilterR < 0)   { responseFilterR = 0;   }
                    if (responseFilterG < 0)   { responseFilterG = 0;   }
                    if (responseFilterB < 0)   { responseFilterB = 0;   }
                    if (responseFilterR > 255) { responseFilterR = 255; }
                    if (responseFilterG > 255) { responseFilterG = 255; }
                    if (responseFilterB > 255) { responseFilterB = 255; }
                    NewBmp.SetPixel(x, y, Color.FromArgb(responseFilterR, responseFilterG, responseFilterB));


                }
            }
            label1.Text = "done";
            pictureBox2.Image = NewBmp;
        }

        private void HightFiler_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height);
            int SIZE_ARR = (int)(numericUpDown1.Value);
            int indent = (int)(SIZE_ARR / 2);

            int[,] H1 = new int[SIZE_ARR, SIZE_ARR];

            int del = 1;

            for (int i = 0; i < SIZE_ARR; i++)
            {
                for (int j = 0; j < SIZE_ARR; j++)
                {
                    H1[i, j] = -1;
                }
            }

            H1[indent, indent] = SIZE_ARR * SIZE_ARR;

            for (int x = indent; x < bmp.Width - indent; x++)
            {
                for (int y = indent; y < bmp.Height - indent; y++)
                {
                    int responseFilterR = 0;
                    int responseFilterG = 0;
                    int responseFilterB = 0;

                    int _x = x - indent, _y = y - indent;
                    int k = 0, l = 0;

                    for (int i = _x; i < SIZE_ARR + _x; i++)
                    {
                        l = 0;
                        for (int j = _y; j < SIZE_ARR + _y; j++)
                        {
                            responseFilterR += H1[k, l] * bmp.GetPixel(i, j).R;
                            responseFilterG += H1[k, l] * bmp.GetPixel(i, j).G;
                            responseFilterB += H1[k, l] * bmp.GetPixel(i, j).B;
                            //Console.WriteLine("-------------");
                            l++;

                        }
                        k++;
                    }
                    Console.WriteLine("===========");

                    responseFilterR = (int)(responseFilterR / del);
                    responseFilterG = (int)(responseFilterG / del);
                    responseFilterB = (int)(responseFilterB / del);
                    if (responseFilterR < 0) { responseFilterR = 0; /*Math.Abs(responseFilterR);*/ }
                    if (responseFilterG < 0) { responseFilterG = 0; /*Math.Abs(responseFilterG);*/ }
                    if (responseFilterB < 0) { responseFilterB = 0; /*Math.Abs(responseFilterB);*/ }
                    if (responseFilterR > 255) { responseFilterR = 255; }
                    if (responseFilterG > 255) { responseFilterG = 255; }
                    if (responseFilterB > 255) { responseFilterB = 255; }
                    NewBmp.SetPixel(x, y, Color.FromArgb(responseFilterR, responseFilterG, responseFilterB));

                }
            }
            label1.Text = "done";
            pictureBox2.Image = NewBmp;

        }

        private void Median_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height);
            int SIZE_ARR = (int)(numericUpDown1.Value);
            int indent = (int)(SIZE_ARR / 2);

            int[] HR = new int[SIZE_ARR * SIZE_ARR];
            int[] HG = new int[SIZE_ARR * SIZE_ARR];
            int[] HB = new int[SIZE_ARR * SIZE_ARR];

            for (int x = indent; x < bmp.Width - indent; x++)
            {
                for (int y = indent; y < bmp.Height - indent; y++)
                {
               
                    int _x = x - indent, _y = y - indent;
                    int ind = 0;
                    for (int i = _x; i < SIZE_ARR + _x; i++)
                    {
                        for (int j = _y; j < SIZE_ARR + _y; j++)
                        {
                            HR[ind] = bmp.GetPixel(i, j).R;
                            HG[ind] = bmp.GetPixel(i, j).G;
                            HB[ind] = bmp.GetPixel(i, j).B;
                            ind++;

                        }
                    }

                    Array.Sort(HR);
                    Array.Sort(HG);
                    Array.Sort(HB);

                    int R, G, B;
                    R = HR[SIZE_ARR * SIZE_ARR / 2];
                    G = HG[SIZE_ARR * SIZE_ARR / 2];
                    B = HB[SIZE_ARR * SIZE_ARR / 2];

                    NewBmp.SetPixel(x, y, Color.FromArgb(R, G, B));

                }
            }
            label1.Text = "done";
            pictureBox2.Image = NewBmp;
        }

        private void Gaus_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height);
            int SIZE_ARR = (int)(numericUpDown1.Value);
            int indent = (int)(SIZE_ARR / 2);

            double sigma = 5;
            double r, s = 2.0 * sigma * sigma;
            double[,] H1 = new double[SIZE_ARR, SIZE_ARR];
            double sum = 0.0;

            for (int x = -(int)(SIZE_ARR/2); x <= (int)(SIZE_ARR / 2); x++)
            {
                for (int y = -(int)(SIZE_ARR / 2); y <= (int)(SIZE_ARR / 2); y++)
                {
                    r = Math.Sqrt(x * x + y * y);
                    H1[x + (int)(SIZE_ARR / 2), y + (int)(SIZE_ARR / 2)] = (Math.Exp(-(r) / s)) / (Math.PI * s);
                    sum += H1[x + (int)(SIZE_ARR / 2), y + (int)(SIZE_ARR / 2)];
                }
            }

            for (int i = 0; i < SIZE_ARR; ++i)
                for (int j = 0; j < SIZE_ARR; ++j)
                    H1[i, j] /= sum;

            for (int x = indent; x < bmp.Width - indent; x++)
            {
                for (int y = indent; y < bmp.Height - indent; y++)
                {
                    double responseFilterR = 0;
                    double responseFilterG = 0;
                    double responseFilterB = 0;

                    int _x = x - indent, _y = y - indent;
                    int k = 0, l = 0;

                    for (int i = _x; i < SIZE_ARR + _x; i++)
                    {
                        l = 0;
                        for (int j = _y; j < SIZE_ARR + _y; j++)
                        {
                            responseFilterR += H1[k, l] * bmp.GetPixel(i, j).R;
                            responseFilterG += H1[k, l] * bmp.GetPixel(i, j).G;
                            responseFilterB += H1[k, l] * bmp.GetPixel(i, j).B;
                            //Console.WriteLine("-------------");
                            l++;

                        }
                        k++;
                    }
                    Console.WriteLine("===========");

                    responseFilterR = (int)(responseFilterR );
                    responseFilterG = (int)(responseFilterG );
                    responseFilterB = (int)(responseFilterB );
                    if (responseFilterR < 0) { responseFilterR = 0; /*Math.Abs(responseFilterR);*/ }
                    if (responseFilterG < 0) { responseFilterG = 0; /*Math.Abs(responseFilterG);*/ }
                    if (responseFilterB < 0) { responseFilterB = 0; /*Math.Abs(responseFilterB);*/ }
                    if (responseFilterR > 255) { responseFilterR = 255; }
                    if (responseFilterG > 255) { responseFilterG = 255; }
                    if (responseFilterB > 255) { responseFilterB = 255; }
                    NewBmp.SetPixel(x, y, Color.FromArgb((int)(responseFilterR), (int)(responseFilterG), (int)(responseFilterB)));

                }
            }
            label1.Text = "done";
            pictureBox2.Image = NewBmp;

        }

        private void Laplas_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height);
            const int SIZE_ARR = 3;// (int)(numericUpDown1.Value);
            int indent = (int)(SIZE_ARR / 2);

            int[,] H1 = new int[SIZE_ARR, SIZE_ARR] { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } }; 

            for (int x = indent; x < bmp.Width - indent; x++)
            {
                for (int y = indent; y < bmp.Height - indent; y++)
                {
                    int responseFilterR = 0;
                    int responseFilterG = 0;
                    int responseFilterB = 0;

                    int _x = x - indent, _y = y - indent;
                    int k = 0, l = 0;

                    for (int i = _x; i < SIZE_ARR + _x; i++)
                    {
                        l = 0;
                        for (int j = _y; j < SIZE_ARR + _y; j++)
                        {
                            responseFilterR += H1[k, l] * bmp.GetPixel(i, j).R;
                            responseFilterG += H1[k, l] * bmp.GetPixel(i, j).G;
                            responseFilterB += H1[k, l] * bmp.GetPixel(i, j).B;
                            //Console.WriteLine("-------------");
                            l++;

                        }
                        k++;
                    }
                    Console.WriteLine("===========");

                    if (responseFilterR < 0) { responseFilterR = Math.Abs(responseFilterR); }
                    if (responseFilterG < 0) { responseFilterG = Math.Abs(responseFilterG); }
                    if (responseFilterB < 0) { responseFilterB = Math.Abs(responseFilterB); }
                    if (responseFilterR > 255) { responseFilterR = 255; }
                    if (responseFilterG > 255) { responseFilterG = 255; }
                    if (responseFilterB > 255) { responseFilterB = 255; }
                    NewBmp.SetPixel(x, y, Color.FromArgb(responseFilterR, responseFilterG, responseFilterB));

                }
            }
            label1.Text = "done";
            pictureBox2.Image = NewBmp;
        }

        private void Roberts_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height);

            for (int x = 0; x < bmp.Width - 1; x++)
            {
                for (int y = 0; y < bmp.Height - 1; y++)
                {
                    int responseFilterR = 0;
                    int responseFilterG = 0;
                    int responseFilterB = 0;

                    responseFilterR = Math.Abs(bmp.GetPixel(x, y).R - bmp.GetPixel(x + 1, y + 1).R) + Math.Abs(bmp.GetPixel(x + 1, y).R - bmp.GetPixel(x, y + 1).R);
                    responseFilterG = Math.Abs(bmp.GetPixel(x, y).G - bmp.GetPixel(x + 1, y + 1).G) + Math.Abs(bmp.GetPixel(x + 1, y).G - bmp.GetPixel(x, y + 1).G);
                    responseFilterB = Math.Abs(bmp.GetPixel(x, y).B - bmp.GetPixel(x + 1, y + 1).B) + Math.Abs(bmp.GetPixel(x + 1, y).B - bmp.GetPixel(x, y + 1).B);

                    if (responseFilterR > 255) { responseFilterR = 255; }
                    if (responseFilterG > 255) { responseFilterG = 255; }
                    if (responseFilterB > 255) { responseFilterB = 255; }
                    NewBmp.SetPixel(x, y, Color.FromArgb(responseFilterR, responseFilterG, responseFilterB));

                }
            }
            label1.Text = "done";
            pictureBox2.Image = NewBmp;
        }

        private void Sobel_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height);
            int SIZE_ARR = (int)(numericUpDown1.Value);
            int indent = (int)(SIZE_ARR / 2);

            int[,] H1 = new int[SIZE_ARR, SIZE_ARR];
            int[,] H2 = new int[SIZE_ARR, SIZE_ARR];

   

            for (int i = 0; i < SIZE_ARR; i++)
            {
                for (int j = 0; j < SIZE_ARR; j++)
                {
                    if (j == indent)
                        H1[i, j] = SIZE_ARR - 1 - 2 * i;
                    else
                        H1[i, j] = SIZE_ARR / 2 - i;
                    if (i == indent)
                        H2[i, j] = SIZE_ARR - 1 - 2 * j;
                    else
                        H2[i, j] = SIZE_ARR / 2 - j;
                }
         
            }

            for (int x = indent; x < bmp.Width - indent; x++)
            {
                for (int y = indent; y < bmp.Height - indent; y++)
                {
                    int PR = 0, PG = 0, PB = 0, QR = 0, QG = 0, QB = 0;
                    int responseFilterR = 0, responseFilterG = 0, responseFilterB = 0;

                    int _x = x - indent, _y = y - indent;
                    int k = 0, l = 0;

                    for (int i = _x; i < SIZE_ARR + _x; i++)
                    {
                        l = 0;
                        for (int j = _y; j < SIZE_ARR + _y; j++)
                        {
                            PR += H1[k, l] * bmp.GetPixel(i, j).R;
                            PG += H1[k, l] * bmp.GetPixel(i, j).G;
                            PB += H1[k, l] * bmp.GetPixel(i, j).B;

                            QR += H2[k, l] * bmp.GetPixel(i, j).R;
                            QG += H2[k, l] * bmp.GetPixel(i, j).G;
                            QB += H2[k, l] * bmp.GetPixel(i, j).B;
                            l++;

                        }
                        k++;
                    }
          
                    responseFilterR = Math.Abs(PR) + Math.Abs(QR);
                    responseFilterG = Math.Abs(PG) + Math.Abs(QG);
                    responseFilterB = Math.Abs(PB) + Math.Abs(QB);

                    if (responseFilterR > 255) { responseFilterR = 255; }
                    if (responseFilterG > 255) { responseFilterG = 255; }
                    if (responseFilterB > 255) { responseFilterB = 255; }
               
                    NewBmp.SetPixel(x, y, Color.FromArgb(responseFilterR, responseFilterG, responseFilterB));
                }
            }
            label1.Text = "done";
            pictureBox2.Image = NewBmp;
        }

        private void Previt_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height);
            int SIZE_ARR = (int)(numericUpDown1.Value);
            int indent = (int)(SIZE_ARR / 2);

            int[,] H1 = new int[SIZE_ARR, SIZE_ARR];
            int[,] H2 = new int[SIZE_ARR, SIZE_ARR];

            for (int i = 0; i < SIZE_ARR; i++)
            {
                for (int j = 0; j < SIZE_ARR; j++)
                {
                    H1[i, j] = 0;
                    H2[i, j] = 0;
                }
            }

            for (int i = 0; i < SIZE_ARR; i++)
            {
                H1[i, 0] = 1;
                H1[i, SIZE_ARR - 1] = -1;
                H2[0, i] = -1;
                H2[SIZE_ARR - 1, i] = 1;
            }


            for (int x = indent; x < bmp.Width - indent; x++)
            {
                for (int y = indent; y < bmp.Height - indent; y++)
                {
                    int PR = 0, PG = 0, PB = 0, QR = 0, QG = 0, QB = 0;
                    int responseFilterR = 0, responseFilterG = 0, responseFilterB = 0;

                    int _x = x - indent, _y = y - indent;
                    int k = 0, l = 0;

                    for (int i = _x; i < SIZE_ARR + _x; i++)
                    {
                        l = 0;
                        for (int j = _y; j < SIZE_ARR + _y; j++)
                        {
                            PR += H1[k, l] * bmp.GetPixel(i, j).R;
                            PG += H1[k, l] * bmp.GetPixel(i, j).G;
                            PB += H1[k, l] * bmp.GetPixel(i, j).B;

                            QR += H2[k, l] * bmp.GetPixel(i, j).R;
                            QG += H2[k, l] * bmp.GetPixel(i, j).G;
                            QB += H2[k, l] * bmp.GetPixel(i, j).B;
                            l++;

                        }
                        k++;
                    }
                    
                    responseFilterR = Math.Max(Math.Abs(PR), Math.Abs(QR));
                    responseFilterG = Math.Max(Math.Abs(PG), Math.Abs(QG));
                    responseFilterB = Math.Max(Math.Abs(PB), Math.Abs(QB));

                    if (responseFilterR > 255) { responseFilterR = 255; }
                    if (responseFilterG > 255) { responseFilterG = 255; }
                    if (responseFilterB > 255) { responseFilterB = 255; }

                    NewBmp.SetPixel(x, y, Color.FromArgb(responseFilterR, responseFilterG, responseFilterB));
                }
            }
            label1.Text = "done";
            pictureBox2.Image = NewBmp;
        }
        private int maximum(int H1, int H2, int H3, int H4, int H5, int H6, int H7, int H8) {
            int res = H1;
            if (res < H2) res = H2;
            if (res < H3) res = H3;
            if (res < H4) res = H4;
            if (res < H5) res = H5;
            if (res < H6) res = H6;
            if (res < H7) res = H7;
            if (res < H8) res = H8;

            return res;
        }

        public static Point RoundIndexToPoint(int index, int radius)
        {
            if (radius == 0)
                return new Point(0, 0);
            Point result = new Point(-radius, -radius);

            while (index < 0) index += radius * 8;
            index = index % (radius * 8);

            int edgeLen = radius * 2;

            if (index < edgeLen)
            {
                result.X += index;
            }
            else if ((index -= edgeLen) < edgeLen)
            {
                result.X = radius;
                result.Y += index;
            }
            else if ((index -= edgeLen) < edgeLen)
            {
                result.X = radius - index;
                result.Y = radius;
            }
            else if ((index -= edgeLen) < edgeLen)
            {
                result.Y = radius - index;
            }

            return result;
        }

        public static int[,] Rotate45(int [,] array)
        {
            int dim = Math.Max(array.GetLength(0), array.GetLength(0));

            int[,] result = new int[dim, dim];

            Point center = new Point((result.GetLength(0) - 1) / 2, (result.GetLength(1) - 1) / 2);
            Point center2 = new Point((array.GetLength(0) - 1) / 2, (array.GetLength(1) - 1) / 2);
            for (int r = 0; r <= (dim - 1) / 2; r++)
            {
                for (int i = 0; i <= r * 8; i++)
                {
                    Point source = RoundIndexToPoint(i, r);
                    Point target = RoundIndexToPoint(i + r, r);

                    if (!(center2.X + source.X < 0 || center2.Y + source.Y < 0 || center2.X + source.X >= array.GetLength(0) || center2.Y + source.Y >= array.GetLength(1)))
                        result[center.X + target.X, center.Y + target.Y] = array[center2.X + source.X, center2.Y + source.Y];
                }
            }
            return result;
        }

        private void Kirsh_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height);
            int SIZE_ARR = (int)(numericUpDown1.Value);
            
            int indent = (int)(SIZE_ARR / 2);
            int[,] H1 = new int[SIZE_ARR, SIZE_ARR];

            int ind_x = 0, ind_y = 0;
            int max_value = SIZE_ARR + (SIZE_ARR/2)*2;
            for (int i = 0; i < SIZE_ARR / 2; i++) {
                for (int x = ind_x; x < SIZE_ARR - ind_x; x++)
                {
                    for (int y = ind_y; y < SIZE_ARR - ind_y; y++)
                    {
                        if (x < SIZE_ARR / 2)
                        {
                            H1[x, y] = max_value;
                        }
                        else {
                            H1[x, y] = (-1)*(max_value - 2);
                        }
                    }

                }
                max_value = max_value - 4;
                ind_x++;
                ind_y++;
            }
            H1[SIZE_ARR / 2, SIZE_ARR / 2] = 0;
           
            int[,] H2 = Rotate45(H1);
            int[,] H3 = Rotate45(H2);
            int[,] H4 = Rotate45(H3);
            int[,] H5 = Rotate45(H4);
            int[,] H6 = Rotate45(H5);
            int[,] H7 = Rotate45(H6);
            int[,] H8 = Rotate45(H7);
            int[,] H9 = Rotate45(H8);

   
            for (int x = indent; x < bmp.Width - indent; x++)
            {
                for (int y = indent; y < bmp.Height - indent; y++)
                {
                    int H1R = 0, H1G = 0, H1B = 0;
                    int H2R = 0, H2G = 0, H2B = 0;
                    int H3R = 0, H3G = 0, H3B = 0;
                    int H4R = 0, H4G = 0, H4B = 0;
                    int H5R = 0, H5G = 0, H5B = 0;
                    int H6R = 0, H6G = 0, H6B = 0;
                    int H7R = 0, H7G = 0, H7B = 0;
                    int H8R = 0, H8G = 0, H8B = 0;

                    int responseFilterR = 0, responseFilterG = 0, responseFilterB = 0;

                    int _x = x - indent, _y = y - indent;
                    int k = 0, l = 0;

                    for (int i = _x; i < SIZE_ARR + _x; i++)
                    {
                        l = 0;
                        for (int j = _y; j < SIZE_ARR + _y; j++)
                        {
                            H1R += H1[k, l] * bmp.GetPixel(i, j).R;
                            H1G += H1[k, l] * bmp.GetPixel(i, j).G;
                            H1B += H1[k, l] * bmp.GetPixel(i, j).B;

                            H2R += H2[k, l] * bmp.GetPixel(i, j).R;
                            H2G += H2[k, l] * bmp.GetPixel(i, j).G;
                            H2B += H2[k, l] * bmp.GetPixel(i, j).B;

                            H3R += H3[k, l] * bmp.GetPixel(i, j).R;
                            H3G += H3[k, l] * bmp.GetPixel(i, j).G;
                            H3B += H3[k, l] * bmp.GetPixel(i, j).B;

                            H4R += H4[k, l] * bmp.GetPixel(i, j).R;
                            H4G += H4[k, l] * bmp.GetPixel(i, j).G;
                            H4B += H4[k, l] * bmp.GetPixel(i, j).B;

                            H5R += H5[k, l] * bmp.GetPixel(i, j).R;
                            H5G += H5[k, l] * bmp.GetPixel(i, j).G;
                            H5B += H5[k, l] * bmp.GetPixel(i, j).B;

                            H6R += H6[k, l] * bmp.GetPixel(i, j).R;
                            H6G += H6[k, l] * bmp.GetPixel(i, j).G;
                            H6B += H6[k, l] * bmp.GetPixel(i, j).B;

                            H7R += H7[k, l] * bmp.GetPixel(i, j).R;
                            H7G += H7[k, l] * bmp.GetPixel(i, j).G;
                            H7B += H7[k, l] * bmp.GetPixel(i, j).B;

                            H8R += H8[k, l] * bmp.GetPixel(i, j).R;
                            H8G += H8[k, l] * bmp.GetPixel(i, j).G;
                            H8B += H8[k, l] * bmp.GetPixel(i, j).B;
                            l++;
                        }
                        k++;
                    }

                    responseFilterR = maximum(Math.Abs(H1R), Math.Abs(H2R), Math.Abs(H3R), Math.Abs(H4R), Math.Abs(H5R), Math.Abs(H6R), Math.Abs(H7R), Math.Abs(H8R));
                    responseFilterG = maximum(Math.Abs(H1G), Math.Abs(H2G), Math.Abs(H3G), Math.Abs(H4G), Math.Abs(H5G), Math.Abs(H6G), Math.Abs(H7G), Math.Abs(H8G));
                    responseFilterB = maximum(Math.Abs(H1B), Math.Abs(H2B), Math.Abs(H3B), Math.Abs(H4B), Math.Abs(H5B), Math.Abs(H6B), Math.Abs(H7B), Math.Abs(H8B));

                    if (responseFilterR > 255) { responseFilterR = 255; }
                    if (responseFilterG > 255) { responseFilterG = 255; }
                    if (responseFilterB > 255) { responseFilterB = 255; }

                    NewBmp.SetPixel(x, y, Color.FromArgb(responseFilterR, responseFilterG, responseFilterB));
                }
            }
            label1.Text = "done";
            pictureBox2.Image = NewBmp;
        }

        private void Embossing_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height);
            const int SIZE_ARR = 3;// (int)(numericUpDown1.Value);
            int indent = (int)(SIZE_ARR / 2);
            int[,] H1;
            if (comboBox1.SelectedIndex == 1)
            {
                //выдавленный
                H1 = new int[SIZE_ARR, SIZE_ARR] { { 0, 1, 0 }, { -1, 0, 1 }, { 0, -1, 0 } };
            }
            else {
                //вдавленный
                H1 = new int[SIZE_ARR, SIZE_ARR] { { 0, -1, 0 }, { 1, 0, -1 }, { 0, 1, 0 } };
            }

            for (int x = indent; x < bmp.Width - indent; x++)
            {
                for (int y = indent; y < bmp.Height - indent; y++)
                {
                    int responseFilterR = 0;
                    int responseFilterG = 0;
                    int responseFilterB = 0;

                    int _x = x - indent, _y = y - indent;
                    int k = 0, l = 0;

                    for (int i = _x; i < SIZE_ARR + _x; i++)
                    {
                        l = 0;
                        for (int j = _y; j < SIZE_ARR + _y; j++)
                        {
                            responseFilterR += H1[k, l] * bmp.GetPixel(i, j).R;
                            responseFilterG += H1[k, l] * bmp.GetPixel(i, j).G;
                            responseFilterB += H1[k, l] * bmp.GetPixel(i, j).B;
                            l++;

                        }
                        k++;
                    }
                    responseFilterR += 128;
                    responseFilterG += 128;
                    responseFilterB += 128;


                    if (responseFilterR < 0) { responseFilterR = 0; }
                    if (responseFilterG < 0) { responseFilterG = 0; }
                    if (responseFilterB < 0) { responseFilterB = 0; }
                    if (responseFilterR > 255) { responseFilterR = 255; }
                    if (responseFilterG > 255) { responseFilterG = 255; }
                    if (responseFilterB > 255) { responseFilterB = 255; }
                    NewBmp.SetPixel(x, y, Color.FromArgb(responseFilterR, responseFilterG, responseFilterB));

                }
            }
            label1.Text = "done";
            pictureBox2.Image = NewBmp;
        }

      

        private void Shift_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height);
            const int SIZE_ARR = 3;// (int)(numericUpDown1.Value);
            int indent = (int)(SIZE_ARR / 2);
            int[,] H1 = new int[SIZE_ARR, SIZE_ARR];
            for (int i = 0; i < SIZE_ARR; i++)
            {
                for (int j = 0; j < SIZE_ARR; j++)
                {
                    H1[i, j] = 0;
                }
            }

            if (comboBox2.SelectedIndex == 0)
            {
                for (int i = 0; i < SIZE_ARR / 2; i++)
                {
                    H1[SIZE_ARR / 2, i] = -1;
                }
                H1[SIZE_ARR / 2, SIZE_ARR / 2] = 1;


            }
            else if (comboBox2.SelectedIndex == 1)
            {
                for (int i = 0; i < SIZE_ARR / 2; i++)
                {
                    H1 [i, SIZE_ARR / 2] = -1;
                }
                H1[SIZE_ARR / 2, SIZE_ARR / 2] = 1;

            }
            else {
                for (int i = 0; i < SIZE_ARR / 2; i++)
                {
                    H1[i, i] = -1;
                }

                H1[SIZE_ARR / 2, SIZE_ARR / 2] = 1;

            }

            for (int x = indent; x < bmp.Width - indent; x++)
            {
                for (int y = indent; y < bmp.Height - indent; y++)
                {
                    int responseFilterR = 0;
                    int responseFilterG = 0;
                    int responseFilterB = 0;

                    int _x = x - indent, _y = y - indent;
                    int k = 0, l = 0;

                    for (int i = _x; i < SIZE_ARR + _x; i++)
                    {
                        l = 0;
                        for (int j = _y; j < SIZE_ARR + _y; j++)
                        {
                            responseFilterR += H1[k, l] * bmp.GetPixel(i, j).R;
                            responseFilterG += H1[k, l] * bmp.GetPixel(i, j).G;
                            responseFilterB += H1[k, l] * bmp.GetPixel(i, j).B;
                            l++;

                        }
                        k++;
                    }

                    if (responseFilterR < 0) { responseFilterR = 0; }
                    if (responseFilterG < 0) { responseFilterG = 0; }
                    if (responseFilterB < 0) { responseFilterB = 0; }
                    if (responseFilterR > 255) { responseFilterR = 255; }
                    if (responseFilterG > 255) { responseFilterG = 255; }
                    if (responseFilterB > 255) { responseFilterB = 255; }
                    NewBmp.SetPixel(x, y, Color.FromArgb(responseFilterR, responseFilterG, responseFilterB));

                }
            }
            label1.Text = "done";
            pictureBox2.Image = NewBmp;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
