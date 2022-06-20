using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace transformationHafa
{
    public partial class Form1 : Form
    {
        String Path = @"D:\DOCUMENTS\programm\study\processingImage2sem\LineHAFA7.jpg";
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadImg_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Path);
            pictureBox1.Image = bmp;
        }

        private void LineHAFA_Click(object sender, EventArgs e)
        {

            int rMax = Math.Max(bmp.Width, bmp.Height) + 1;
            int fiMax = 360;
            int[,] MAS_PLUS = new int[fiMax, rMax];

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (bmp.GetPixel(x, y).R == 0 && bmp.GetPixel(x, y).G == 0 && bmp.GetPixel(x, y).B == 0) {
                        for (int fi = 0; fi < 180; fi++)
                        {
                            double rFloat = x * Math.Cos(fi * Math.PI / 180) + y * Math.Sin(fi * Math.PI / 180);
                            int r = (int)(Math.Abs(Math.Round(rFloat, 1, MidpointRounding.AwayFromZero)));
                                MAS_PLUS[fi, r]++;

                        }
                    }
                   
                }
            }

            int rRes = 0, fiRes = 0;
            int maxValue = 0;
            for (int x = 0; x < fiMax; x++)
            {
                for (int y = 0; y < rMax; y++)
                {
                    if (maxValue < MAS_PLUS[x, y]) {
                        maxValue = MAS_PLUS[x, y];
                        fiRes = x ;
                        rRes = y;
                    }
                }
            }
     

            bool endCycle = false;
            Point Point1 = new Point();
            for (int x = 0; x < bmp.Width ; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    double rFloat = x * Math.Cos(fiRes * Math.PI / 180) + y * Math.Sin(fiRes * Math.PI / 180);
                    int r = (int)(Math.Abs(Math.Round(rFloat, 1, MidpointRounding.AwayFromZero)));
                    if (r == rRes) {
                        Point1.X = x;
                        Point1.Y = y;
                        endCycle = true;
                        break;
                    }
                }
                if (endCycle)
                {
                    break;
                }
            }

            Point Point2 = new Point();
            rRes = 10000;
          
            double cos = Math.Cos((Math.PI / 180) * fiRes);
            double sin = Math.Sin((Math.PI / 180) * fiRes);
            Point pointRot = new Point();
            pointRot.X = Point1.X ;
            pointRot.Y = Point1.Y + rRes;
            Point2.X = Convert.ToInt32(Point1.X + (pointRot.X - Point1.X) * cos - (pointRot.Y - Point1.Y) * sin);
            Point2.Y = Convert.ToInt32(Point1.Y + (pointRot.X - Point1.X) * sin + (pointRot.Y - Point1.Y) * cos);

            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(NewBmp);
            Pen myPen = new Pen(System.Drawing.Color.Red, 3);
            g.DrawImage(pictureBox1.Image, 0, 0);
            g.DrawLine(myPen, Point1, Point2);
           
            Point Point3 = new Point(); 
            Point3.X = Convert.ToInt32(Point1.X + (Point2.X - Point1.X) * Math.Cos(Math.PI) - (Point2.Y - Point1.Y) * Math.Sin(Math.PI));
            Point3.Y = Convert.ToInt32(Point1.Y + (Point2.X - Point1.X) * Math.Sin(Math.PI) + (Point2.Y - Point1.Y) * Math.Cos(Math.PI));

            g.DrawLine(myPen, Point1, Point3);

            pictureBox1.Image = NewBmp;

        }//end func

        private void CircleHAFA_Click(object sender, EventArgs e)
        {
            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            int[,] MAS = new int[bmp.Width, bmp.Height];
            int R = 50;
            for (int x = 0; x < bmp.Width ; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (bmp.GetPixel(x, y).R == 0 && bmp.GetPixel(x, y).G == 0 && bmp.GetPixel(x, y).B == 0)
                    {
                        PointF point = new PointF(x, y);
                        PointF pointR = new PointF(x + R, y);
                        for (int angle = 0; angle < 359; angle++)
                        {
                            double angleRadian = angle * Math.PI / 180;
                            int newX = 0, newY = 0;
                            newX = Convert.ToInt32((pointR.X - point.X) * Math.Cos(angleRadian) - (pointR.Y - point.Y) * Math.Sin(angleRadian) + point.X);
                            newY = Convert.ToInt32((pointR.X - point.X) * Math.Sin(angleRadian) + (pointR.Y - point.Y) * Math.Cos(angleRadian) + point.Y);
                            if(newX > 0 && newY > 0 && newX < bmp.Width && newY<bmp.Height)
                                MAS[newX, newY]++;
                            
                        }

                    }
                }
            }//end for x

            int MAX_X = 0, MAX_Y = 0, MAXS = 0;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height ; y++)
                {
                    if (MAS[x, y] > MAXS) {
                        MAXS = MAS[x, y];
                        MAX_X = x;
                        MAX_Y = y;
                    }
                }
            }//end for x
            Graphics g = Graphics.FromImage(NewBmp);
            g.DrawImage(pictureBox1.Image, 0, 0, bmp.Width, bmp.Height);

            Pen myPenR = new Pen(System.Drawing.Color.Red, 3);
            Rectangle rect = new Rectangle(MAX_X - R, MAX_Y - R, R*2, R*2);
            g.DrawEllipse(myPenR, rect);
            
            pictureBox1.Image = NewBmp;
        }//edn func

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.X + " " + e.Y;
        }
        struct CircleValue
        {
            int x, y, R, value;
            public void set(int _x, int _y, int _R, int _value) {
                x = _x;
                y = _y;
                R = _R;
                value = _value;
            }
            public int getValue()
            {
                return value;
            }
            public int getX()
            {
                return x;
            }
            public int getY()
            {
                return y;
            }
            public int getR()
            {
                return R;
            }
        }

        

        static List<CircleValue> BubbleSort(List<CircleValue> mas)
        {
            CircleValue temp;
            for (int i = 0; i < mas.Count; i++)
            {
                for (int j = i + 1; j < mas.Count; j++)
                {
                    if (mas[i].getValue() > mas[j].getValue() && mas[i].getR() > mas[j].getR())
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }


        private void CircleHAFAAnyR_Click(object sender, EventArgs e)
        {

            Bitmap NewBmp = new Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int minR = 10, maxR = (int)(Math.Min(bmp.Width, bmp.Height)/2) + 1;
            maxR = (int)(Math.Sqrt(Math.Pow(bmp.Width, 2) + Math.Pow(bmp.Height, 2)));
            int maxX, minX, minY, maxY;
            minX = 0;
            maxX = bmp.Width;
            minY = 0;
            maxY = bmp.Height;

            int[,,] MAS = new int[maxX, maxY, maxR];
            for(int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (bmp.GetPixel(x,y).R == 0 && bmp.GetPixel(x, y).G == 0 && bmp.GetPixel(x, y).B == 0)
                    {
                        for (int Cx = minX; Cx < maxX; Cx++)
                        {
                            for (int Cy = minY; Cy < maxY; Cy++)
                            {
                                int R = (int)(Math.Sqrt(Math.Pow(x - Cx, 2) + Math.Pow(y - Cy, 2)));
                                MAS[Cx, Cy, R]++;
                            }
                        }

                    }
                        
                }
            }

            int MAX_X = 0, MAX_Y = 0, MAXS = 0, resR = 0;
            for (int x = minX; x < maxX; x++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    for (int R = minR; R < maxR; R++)
                    {
                        if (MAS[x, y, R] > MAXS)
                        {
                            MAXS = MAS[x, y, R];
                            MAX_X = x;
                            MAX_Y = y;
                            resR = R;                           
                        }
                    }
                }
            }//end for x
             //362, 130
             //39,84

            Graphics g = Graphics.FromImage(NewBmp);
            g.DrawImage(pictureBox1.Image, 0, 0, bmp.Width, bmp.Height);

            Pen myPenR = new Pen(System.Drawing.Color.Red, 3);
       
            Rectangle rect = new Rectangle(MAX_X - resR, MAX_Y - resR, resR * 2, resR * 2);
            g.DrawEllipse(myPenR, rect);

            pictureBox1.Image = NewBmp;
        }

        private Bitmap Sobel(Bitmap _bmp)
        {
            Bitmap NewBmp = new Bitmap(_bmp.Width, _bmp.Height);
            int SIZE_ARR = 3;
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
                H1[i, 0] = -1;
                H1[i, SIZE_ARR - 1] = 1;
                H2[0, i] = 1;
                H2[SIZE_ARR - 1, i] = -1;
            }
            H1[SIZE_ARR / 2, 0] = -2;
            H1[SIZE_ARR / 2, SIZE_ARR - 1] = 2;
            H2[0, SIZE_ARR / 2] = 2;
            H2[SIZE_ARR - 1, SIZE_ARR / 2] = -2;

            for (int x = indent; x < _bmp.Width - indent; x++)
            {
                for (int y = indent; y < _bmp.Height - indent; y++)
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
                            PR += H1[k, l] * _bmp.GetPixel(i, j).R;
                            PG += H1[k, l] * _bmp.GetPixel(i, j).G;
                            PB += H1[k, l] * _bmp.GetPixel(i, j).B;

                            QR += H2[k, l] * _bmp.GetPixel(i, j).R;
                            QG += H2[k, l] * _bmp.GetPixel(i, j).G;
                            QB += H2[k, l] * _bmp.GetPixel(i, j).B;
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
            return NewBmp;
        }
        private void FindMoney_Click(object sender, EventArgs e)
        {
            Bitmap NewBmp = Sobel(bmp);
            pictureBox1.Image = NewBmp;

            Bitmap NewBmpMoney = new Bitmap(NewBmp.Width, NewBmp.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int minR = 10, maxR;
            maxR = (int)(Math.Sqrt(Math.Pow(NewBmp.Width, 2) + Math.Pow(NewBmp.Height, 2)));
            int maxX, minX, minY, maxY;
            minX = 0;
            maxX = NewBmp.Width;
            minY = 0;
            maxY = NewBmp.Height;

            int[,,] MAS = new int[maxX, maxY, maxR];
            for (int x = 0; x < NewBmp.Width; x++)
            {
                for (int y = 0; y < NewBmp.Height; y++)
                {
                    if (NewBmp.GetPixel(x, y).R != 0 && NewBmp.GetPixel(x, y).G != 0 && NewBmp.GetPixel(x, y).B != 0)
                    {
                        for (int Cx = minX; Cx < maxX; Cx++)
                        {
                            for (int Cy = minY; Cy < maxY; Cy++)
                            {
                                    int R = (int)(Math.Sqrt(Math.Pow(x - Cx, 2) + Math.Pow(y - Cy, 2)));
                                    MAS[Cx, Cy, R]++; 
                            }
                        }
                    }
                }
            }

            List<CircleValue> lst = new List<CircleValue>();
            int MAX_X = 0, MAX_Y = 0, MAXS = 0, resR = 0;
            for (int x = minX; x < maxX; x++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    for (int R = minR; R < maxR; R++)
                    {
                        if (MAS[x, y, R] > MAXS)
                        {
                            MAXS = MAS[x, y, R];
                            MAX_X = x;
                            MAX_Y = y;
                            resR = R;

                            CircleValue tmp = new CircleValue();
                            tmp.set(x, y, R, MAS[x, y, R]);
                            lst.Add(tmp);
                        }
                    }
                }
            }//end for x

            lst = BubbleSort(lst);
            List<CircleValue> resLst = new List<CircleValue>();
            resLst.Add(lst[lst.Count() - 1]);
            for (int i = lst.Count - 2; i > 0; i--)
            {
                bool f = true;
                for (int j = 0; j < resLst.Count; j++)
                {
                    if (lst[i].getR() > maxX || lst[i].getR() > maxY) {
                        f = false;
                        break;
                    }
                    if (lst[i].getX() < minX + 1 || lst[i].getY() < minY + 1 || lst[i].getX() > maxX - 1 || lst[i].getY() > maxY - 1) {
                        f = false;
                        break;
                    }

                    if (lst[i].getX() - lst[i].getR() < 0) {
                        f = false;
                        break;
                    }
                    if (lst[i].getX() + lst[i].getR() > NewBmp.Width){
                        f = false;
                        break;
                    }
                    if (lst[i].getY() - lst[i].getR() < 0){
                        f = false;
                        break;
                    }
                    if (lst[i].getY() + lst[i].getR() > NewBmp.Height){
                        f = false;
                        break;
                    }

                    if (resLst[j].getX() + resLst[j].getR() > lst[i].getX())
                    {
                        if (resLst[j].getX() - resLst[j].getR() < lst[i].getX())
                        {
                            if (resLst[j].getY() + resLst[j].getR() > lst[i].getY())
                            {
                                if (resLst[j].getY() - resLst[j].getR() < lst[i].getY())
                                {
                                    if (lst[i].getR() > resLst[j].getR())
                                    {
                                        resLst[j] = lst[i];
                                        f = false;
                                        break;
                                    }
                                    else
                                    {
                                        f = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }//end for j
                if (f) {
                    resLst.Add(lst[i]);
                }
            }//end for i
            Graphics g = Graphics.FromImage(NewBmpMoney);
            g.DrawImage(pictureBox1.Image, 0, 0, NewBmp.Width, NewBmp.Height);
            Pen myPenR = new Pen(System.Drawing.Color.Red, 3);

            int curMaxValue = 5;
            int curMaxR = resLst[0].getR();
            int sum = 0;
            bool f3 = false, f1 = false;
            for (int i = 0; i < resLst.Count; i++)
            {
                Rectangle rect = new Rectangle(resLst[i].getX() - resLst[i].getR(), resLst[i].getY() - resLst[i].getR(), resLst[i].getR() * 2, resLst[i].getR() * 2);
                //Rectangle rect = new Rectangle(MAX_X - resR, MAX_Y - resR, resR * 2, resR * 2);
                if (curMaxR - 3 > resLst[i].getR())
                {
                    if (!f3)
                    {
                        curMaxR = resLst[i].getR();
                        curMaxValue = 2;
                        f3 = true;
                    }
                    else if (!f1)
                    {
                        curMaxR = resLst[i].getR();
                        curMaxValue = 1;
                        f1 = true;
                    }
                }
                sum += curMaxValue;
                g.DrawEllipse(myPenR, rect);
            }
            //for (int i = 0; i < lst.Count; i++) {
            //    Rectangle rect = new Rectangle(lst[i].getX() - lst[i].getR(), lst[i].getY() - lst[i].getR(), lst[i].getR() * 2, lst[i].getR() * 2);
            //    g.DrawEllipse(myPenR, rect);
            //}
            label2.Text = "sum: " + sum.ToString();
            pictureBox1.Image = NewBmpMoney;
        }

    }
}
