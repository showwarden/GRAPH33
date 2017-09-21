using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
   
    abstract class FuncBase
    {
        

        public virtual double A { get; set; }
        public virtual double B { get; set; }
        public virtual double N { get; set; }

        public virtual string Name { get; set; }

        public abstract float vich(double x);
        public abstract void  graf(int width, int height, float scale);



        int[] arr = new int[100];
        
    }

   
}
