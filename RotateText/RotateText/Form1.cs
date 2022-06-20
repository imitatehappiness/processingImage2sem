using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotateText
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        String Path = @"D:\DOCUMENTS\programm\study\processingImage2sem\testRotateTextSmall.jpg";

        public Form1()
        {
            InitializeComponent();
            label1.Text = "Angle: ";

        }

        private void LoadImg_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);

            pictureBox1.Image = bmp;
        }
        private Bitmap rotateBmp(int angle)
        {
            int fi = angle;
            int Cx, Cy;

            int W = bmp.Width;
            int H = bmp.Height;
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
                    NewBitmap.SetPixel(u, v, Color.White);

                }
            }
            for (int u = 0; u < W; u++)
            {
                for (int v = 0; v < H; v++)
                {

                    int x = (int)(Cx + (u - Cx) * cos + (v - Cy) * sin);
                    int y = (int)(Cy - (u - Cx) * sin + (v - Cy) * cos);
                    if (x >= 0 && y >= 0 && x < W && y < H)
                        NewBitmap.SetPixel(u, v, bmp.GetPixel(x, y));

                }
            }
            return NewBitmap;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int maxWhite = 0;
            int angleRes = 0;

            for (int angle = -10; angle < 10; angle++)
            {
                Bitmap BMP = rotateBmp(angle);
                int sum = 0;
                for (int y = 0; y < BMP.Height; y++)
                {
                    bool addSum = true;
                    for (int x = 0; x < BMP.Width; x++)
                    {
                        int R = BMP.GetPixel(x, y).R;
                        int G = BMP.GetPixel(x, y).G;
                        int B = BMP.GetPixel(x, y).B;

                        if (R!=255 || G!=255 || B!=255) {
                            addSum = false;
                            break;
                        } 
                    }
                    if (addSum) {
                        sum++;
                    }
                }

                if (sum > maxWhite)
                {
                    maxWhite = sum;
                    angleRes = angle;
                }


            }

            label1.Text = "Angle: " + angleRes.ToString();
            Bitmap resBmp = rotateBmp(angleRes);
            pictureBox1.Image = resBmp;
        }
    }
}
