﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace WindowsFormsApplication1
{
    class Integral17 : FuncBase 
    {
        private string name0;


        public override string Name
        {
            get
            {
                return name0;
            }
            set { name0 = value; }
        }

       //double[] arr = new double[100];

       public override double A
       {
           get { return 1; }

       }

       public override double B
       {
           get { return 2; }

       }
       public override double N
       {
           get { return 100; }

       }
       
       public override float vich(double x)
            {
           //(x^2-1)^0.5 
           //
           return (float)(0.5*(x*Math.Sqrt((x*x-1))-Math.Log(Math.Sqrt(x*x-1)+x)));
            }
       
            private PointF[] listOfPoints;
            public PointF[] ListOfPoints
            {
                get { return listOfPoints; }
                private set { listOfPoints = value; }
            }
            private Bitmap bitmap;
            public Bitmap Bitmap
            {
                get { return bitmap; }
                private set { bitmap = value; }
            }
       
            public override void graf(int width, int height, float scale)
            {
                double x;
                
                double h = (B - A) / N;
                listOfPoints = new PointF[(int)N];
                for (int i = 0; i < N; i++)
                {
                    if (i == 0) { x = A + h;  } else
                        if (i == N-1) { x = B - h; } else { x = h * i + A; };
                    listOfPoints[i] = new PointF((float)x, vich(x)-vich(1+h));
                    
                }
               
                bitmap = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(bitmap);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen p = new Pen(Color.Black, 2);
                for (int i = 0; i < listOfPoints.Length; i++)
                {
                    listOfPoints[i].X = listOfPoints[i].X * scale + width / 2;
                    listOfPoints[i].Y = height / 2 - listOfPoints[i].Y * scale;
                }
                g.DrawLines(p, listOfPoints);
                g.DrawLine(p, width / 2, 0, width / 2, height);
                g.DrawLine(p, 0, height / 2, width, height / 2);
                for (int i = 10; i > -8; i--)
                {
                    Font drawFont = new Font("Arial", 14);
                    if (i < 0) { g.DrawString(System.Convert.ToString(i), drawFont, Brushes.Red, height / 2 + (i * scale - 12), 235); }
                    else if (i > 0) { g.DrawString(System.Convert.ToString(i), drawFont, Brushes.Red, height / 2 + (i * scale - 8), 235); }
                }
                for (int i = -8; i < 10; i++)
                {
                    Font drawFont = new Font("Arial", 14);
                    if (i < 0) { g.DrawString(System.Convert.ToString(i), drawFont, Brushes.Red, 233, height / 2 - (i * scale + 13)); }
                    else if (i > 0) { g.DrawString(System.Convert.ToString(i), drawFont, Brushes.Red, 235, height / 2 - (i * scale + 14)); }
                }
                for (int i = -8; i < 10; i++)
                {

                    float y = height / 2 - i * scale;
                    g.DrawLine(p, 215, y, 225, y);

                }
                for (int i = -8; i < 10; i++)
                {

                    float x1 = width / 2 - i * scale;
                    g.DrawLine(p, x1, 215, x1, 225);

                }
                
            }
    }
 
}
