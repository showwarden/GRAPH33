using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    class Series
    {
        FuncBase[] objects;
        public string[] tutt=new string[12];

        public FuncBase[] Objects
        {
            get { return objects; }
            set { objects = value; }
        }

        public Series()
        { 
            objects = new FuncBase[12];
        }

        public void Save2File(string fileName)
        {
            try
            {
                StreamWriter    wrt = new StreamWriter(fileName);
                string          line;

                foreach (var o in Objects)
                {
                    if (o != null)
                    {
                        line = o.Name + "|" + o.A + "|" + o.B + "|" + o.N;
                        wrt.WriteLine(line);
                    }
                    else
                        break;
                }
                wrt.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка записи в файл");
            }
        }

       
    }
}
