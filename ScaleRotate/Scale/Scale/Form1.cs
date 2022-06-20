using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scale
{
    public partial class Form1 : Form
    {
        PictureBox newImg = new PictureBox();
        Bitmap bmp;
        float sizeX;
        bool interpolation;
         int begin_x;
         int begin_y;
         int new_x;
         int new_y;
        bool resize = false; 
        String Path = @"D:\DOCUMENTS\programm\study\processingImage2sem\test500px.jpg";
        public Form1()
        {
            InitializeComponent();
            interpolation = false;
            sizeX = 1;

        }

        private void LoadPic_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);
            OldImg.Image = bmp;
            newImg.Parent = OldImg;
            newImg.BackColor = Color.Transparent;
            newImg.SizeMode = PictureBoxSizeMode.AutoSize;
            newImg.BorderStyle = BorderStyle.Fixed3D;

            newImg.Visible = false;
        }

        private void OldImg_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                begin_x = e.X;
                begin_y = e.Y;
                newImg.Left = e.X;
                newImg.Top = e.Y;
                newImg.Width = 0;
                newImg.Height = 0;
                newImg.Visible = false;
                resize = true;
            }

        }

        private void OldImg_MouseMove(object sender, MouseEventArgs e)
        {
            if (resize == true)
            {
                newImg.Left = begin_x;
                newImg.Top = begin_y;
                newImg.Width = e.X - begin_x;
                newImg.Height = e.Y - begin_y;
                newImg.Visible = true;
            }
        }
        private void OldImg_MouseUp(object sender, MouseEventArgs e)
        {
            newImg.Width = 0;
            newImg.Height = 0;
 
            if (resize == true)
            {
                new_x = e.X;
                new_y = e.Y;
                newImg.Left = begin_x;
                newImg.Top = begin_y;
                newImg.Width  = new_x - begin_x;
                newImg.Height = new_y - begin_y;
                newImg.Visible = true;
            }
            resize = false;
        }

        static public Image Copy(Image srcBitmap, Rectangle section)
        {
            // Вырезаем выбранный кусок картинки
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);
                
            }
  
            //Возвращаем кусок картинки.
            return bmp;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
            if ((float)trackBar1.Value < 0) {
                sizeX = 1 - (float)trackBar1.Value / -10;
            } else
{
                sizeX  = (float)trackBar1.Value + 1;
            }
           
            label1.Text = "increase: " + sizeX.ToString();
        }

        private void Scale_Click(object sender, EventArgs e)
        {
            
            if (!interpolation)
            {
                int W = (int)(ClientSize.Width * sizeX);
                int H = (int)(ClientSize.Height * sizeX);
                
                Bitmap NewBitmap = new Bitmap(W, H);
                for (int x = begin_x; x < new_x; x++)
                {
                    for (int y = begin_y; y < new_y; y++)
                    {
                        //F(x, y)
                        //X = X0 + (x - x0)*(L/l)
                        //Y = Y0 + (y - y0)*(L/l)
                        int X_new = (int)Math.Round(0 + (x - begin_x) * sizeX, 1, MidpointRounding.AwayFromZero);
                        int Y_new = (int)Math.Round(0 + (y - begin_y) * sizeX, 1, MidpointRounding.AwayFromZero);
                        //F^(-1)(X, Y)
                        //x = x0 + (X - X0)*(l/L)
                        //y = y0 + (Y - Y0)*(l/L)
                        int X_old = (int)Math.Round(begin_x + (X_new - 0) * (1 / sizeX), 1, MidpointRounding.AwayFromZero);
                        int Y_old = (int)Math.Round(begin_y + (Y_new - 0) * (1 / sizeX), 1, MidpointRounding.AwayFromZero);

                        Color pixel_old = bmp.GetPixel(X_old, Y_old);

                        NewBitmap.SetPixel(X_new, Y_new, pixel_old);


                    }//end y
                }//end x
                if (sizeX <= 1)
                    NewImg.Image = NewBitmap;
                else
                {
                    for (int x = 0; x < (new_x - begin_x) * sizeX; x++)
                    {
                        for (int y = 0; y < (new_y - begin_y) * sizeX; y++)
                        {
                            //F(x, y)
                            //X = X0 + (x - x0)*(L/l)
                            //Y = Y0 + (y - y0)*(L/l)
                            //int X_new = (int)Math.Round(0 + (x - begin_x) * sizeX, 1, MidpointRounding.AwayFromZero);
                            //int Y_new = (int)Math.Round(0 + (y - begin_y) * sizeX, 1, MidpointRounding.AwayFromZero);
                            //F^(-1)(X, Y)
                            //x = x0 + (X - X0)*(l/L)
                            //y = y0 + (Y - Y0)*(l/L)
                            int X_old = (int)Math.Round(begin_x + (x) * (1 / sizeX), 1, MidpointRounding.AwayFromZero);
                            int Y_old = (int)Math.Round(begin_y + (y) * (1 / sizeX), 1, MidpointRounding.AwayFromZero);

                            Color pixel_old = bmp.GetPixel(X_old, Y_old);

                            NewBitmap.SetPixel(x, y, pixel_old);


                        }//end y
                    }//end x 
                    NewImg.Image = NewBitmap;

                }
            }
            else {

                Bitmap picture = (Bitmap)OldImg.Image;

                int xMax = new_x - begin_x;
                int yMax = new_y - begin_y;

                int[,] Rm = new int[xMax, yMax];
                int[,] Gm = new int[xMax, yMax];
                int[,] Bm = new int[xMax, yMax];
                int W = (int)(ClientSize.Width * sizeX);
                int H = (int)(ClientSize.Height * sizeX);


                Bitmap NewBitmap = new Bitmap(W, H);
                for (int x = begin_x; x < new_x; x++)
                {
                    for (int y = begin_y; y < new_y; y++)
                    {
                        //F(x, y)
                        //X = X0 + (x - x0)*(L/l)
                        //Y = Y0 + (y - y0)*(L/l)
                        int X_new = (int)Math.Round(0 + (x - begin_x) * sizeX, 1, MidpointRounding.AwayFromZero);
                        int Y_new = (int)Math.Round(0 + (y - begin_y) * sizeX, 1, MidpointRounding.AwayFromZero);
                        //F^(-1)(X, Y)
                        //x = x0 + (X - X0)*(l/L)
                        //y = y0 + (Y - Y0)*(l/L)
                        int X_old = (int)Math.Round(begin_x + (X_new - 0) * (1 / sizeX), 1, MidpointRounding.AwayFromZero);
                        int Y_old = (int)Math.Round(begin_y + (Y_new - 0) * (1 / sizeX), 1, MidpointRounding.AwayFromZero);

                        Color pixel_old = bmp.GetPixel(X_old, Y_old);
                        Rm[x - begin_x, y - begin_y] = pixel_old.R;
                        Gm[x - begin_x, y - begin_y] = pixel_old.G;
                        Bm[x - begin_x, y - begin_y] = pixel_old.B;
                        NewBitmap.SetPixel(X_new, Y_new, pixel_old);
                    }//end y
                }//end x

                if (sizeX <= 1)
                    NewImg.Image = NewBitmap;
                else
                {      
                    int resizeXmax = Convert.ToInt32(Math.Floor((new_x - begin_x) * sizeX));
                    int resizeYmax = Convert.ToInt32(Math.Floor((new_y - begin_y) * sizeX));

                    if (resizeXmax < 1){
                        resizeXmax = 1;
                    }
                    if (resizeYmax < 1){
                        resizeYmax = 1;
                    }

                    double xStep = Convert.ToDouble((new_x - begin_x)-1) / Convert.ToDouble(resizeXmax-1);
                    double yStep = Convert.ToDouble((new_y - begin_y)-1) / Convert.ToDouble(resizeYmax-1);

                    if (Double.IsInfinity(xStep) == true){
                        xStep = 1;
                    }
                    if (Double.IsInfinity(yStep) == true){
                        yStep = 1;
                    }

                    double[,] RRm = new double[resizeXmax, resizeYmax];
                    double[,] RGm = new double[resizeXmax, resizeYmax];
                    double[,] RBm = new double[resizeXmax, resizeYmax];

                    for (double yCur = 0; Math.Round(yCur, 1) <= yMax - 1; yCur += yStep)
                    {
                        for (double xCur = 0; Math.Round(xCur, 1) <= xMax - 1; xCur += xStep)
                        {
                            double x = Math.Round(xCur / xStep, 0);
                            double y = Math.Round(yCur / yStep, 0);
                            double x1 = Math.Floor(xCur);
                            double y1 = Math.Floor(yCur);
                            if (xCur == Math.Floor(xCur) & xCur >= 1 || xCur > xMax - 1)
                            {
                                x1--;
                            }
                            if (yCur == Math.Floor(yCur) & yCur >= 1 || yCur > yMax - 1)
                            {
                                y1--;
                            }

                            double x2 = x1 + 1;
                            double y2 = y1 + 1;
                            int xi = Convert.ToInt32(x);
                            int yi = Convert.ToInt32(y);
                            int xi1 = Convert.ToInt32(x1);
                            int yi1 = Convert.ToInt32(y1);
                            int xi2 = Convert.ToInt32(x2);
                            int yi2 = Convert.ToInt32(y2);

                            RRm[xi, yi] = Rm[xi1, yi1] * (x2 - xCur) * (y2 - yCur) + Rm[xi2, yi1] * (xCur - x1) * (y2 - yCur) + Rm[xi1, yi2] * (x2 - xCur) * (yCur - y1) + Rm[xi2, yi2] * (xCur - x1) * (yCur - y1);
                            RGm[xi, yi] = Gm[xi1, yi1] * (x2 - xCur) * (y2 - yCur) + Gm[xi2, yi1] * (xCur - x1) * (y2 - yCur) + Gm[xi1, yi2] * (x2 - xCur) * (yCur - y1) + Gm[xi2, yi2] * (xCur - x1) * (yCur - y1);
                            RBm[xi, yi] = Bm[xi1, yi1] * (x2 - xCur) * (y2 - yCur) + Bm[xi2, yi1] * (xCur - x1) * (y2 - yCur) + Bm[xi1, yi2] * (x2 - xCur) * (yCur - y1) + Bm[xi2, yi2] * (xCur - x1) * (yCur - y1);
                        }
                    }

                    for (int j = 0; j < resizeYmax; j++)
                    {
                        for (int i = 0; i < resizeXmax; i++)
                        {
                            NewBitmap.SetPixel(i, j, Color.FromArgb(Convert.ToInt32(RRm[i, j]), Convert.ToInt32(RGm[i, j]), Convert.ToInt32(RBm[i, j])));
                        }
                    }
                    NewImg.Image = NewBitmap;
                }
            }

        }

        private void Interpolation_CheckedChanged(object sender, EventArgs e)
        {
            interpolation = !interpolation;
        }

        private void Rotate1_Click(object sender, EventArgs e)
        {
            int fi = (int)Angel.Value;
            int Cx, Cy;

            int W = new_x - begin_x;  
            int H = new_y - begin_y; 
            Cx = (W) / 2;
            Cy = (H) / 2;
            double cos, sin;
            Bitmap NewBitmap = new Bitmap(bmp.Width, bmp.Height);

            cos = Math.Cos(Math.PI / 180 * fi);
            sin = Math.Sin(Math.PI / 180 * fi);

            for (int u = 0; u < W; u++)
            {
                for (int v = 0; v < H; v++)
                {
                    int x = (int)(Cx + (u - Cx) * cos + (v - Cy) * sin);
                    int y = (int)(Cy - (u - Cx) * sin + (v - Cy) * cos);
                    if(x>=0 && y>=0 && x<W && y<H)
                        NewBitmap.SetPixel(u, v, bmp.GetPixel(x + begin_x, y + begin_y));
                }
            }
            NewImg.Image = NewBitmap;
        }

        private void RGBHistogram_Click(object sender, EventArgs e)
        {
            int width = bmp.Width, height = bmp.Height;
            Bitmap NewBitmap = new Bitmap(width, height);

            int[] R = new int[256];
            int[] G = new int[256];
            int[] B = new int[256];
            int i, j;
            Color color;
            for (i = 0; i < bmp.Width; ++i)
                for (j = 0; j < bmp.Height; ++j)
                {
                    color = bmp.GetPixel(i, j);
                    ++R[color.R];
                    ++G[color.G];
                    ++B[color.B];
                }
            int max = 0;
            for (i = 0; i < 256; ++i)
            {
                if (R[i] > max)
                    max = R[i];
                if (G[i] > max)
                    max = G[i];
                if (B[i] > max)
                    max = B[i];
            }
            double point = (double)max / height;
            for (i = 0; i < width - 3; ++i)
            {
                for (j = height - 1; j > height - R[i / 3] / point; --j)
                {
                    NewBitmap.SetPixel(i, j, Color.Red);
                }
                ++i;
                for (j = height - 1; j > height - G[i / 3] / point; --j)
                {
                    NewBitmap.SetPixel(i, j, Color.Green);
                }
                ++i;
                for (j = height - 1; j > height - B[i / 3] / point; --j)
                {
                    NewBitmap.SetPixel(i, j, Color.Blue);
                }
            }
            NewImg.Image = NewBitmap;
        }
    }
}
