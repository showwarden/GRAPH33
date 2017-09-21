using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { radioButton1_CheckedChanged(sender,e);}
            if (radioButton2.Checked) { radioButton2_CheckedChanged(sender, e); }
            if (radioButton3.Checked) { radioButton3_CheckedChanged(sender, e); }
        }


        Series series = new Series();
        
        private void button4_Click(object sender, EventArgs e)
        {
            series.Objects[0] = new Function17();
          series.Objects[0].Name = "F1";
            series.Objects[1] = new Derivative17();
            series.Objects[1].Name = "D1";
            series.Objects[2] = new Integral17();
            series.Objects[2].Name = "I1";
            series.Objects[3] = new Function17();
            series.Objects[3].Name = "F2";
            series.Objects[4] = new Derivative17();
            series.Objects[4].Name = "D2";
            series.Objects[5] = new Integral17();
            series.Objects[5].Name = "I2";
            series.Objects[6] = new Integral17();
            series.Objects[6].Name = "I3";
            series.Objects[7] = new Integral17();
            series.Objects[7].Name = "I4";
            series.Objects[8] = new Derivative17();
            series.Objects[8].Name = "D3";

            PopulateListbox();
        }
       
        void PopulateListbox2()
        {
            
            listBox1.Items.Clear();
            
            for (int i = 0; i < 12 && series.tutt[i] != null; i++)
                listBox1.Items.Add(series.tutt[i]);
            
        }
        void PopulateListbox()
        {
            listBox1.Items.Clear();

            for (int i = 0; i < 12 && series.Objects[i] != null; i++)
                listBox1.Items.Add(series.Objects[i].Name);
        }

        private void button5_Click(object sender, EventArgs e)
        {            
            series.Save2File("Test.txt");
            PopulateListbox();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            
            try
            {

                StreamReader rdr = new StreamReader("Test.txt");
                int cnt = 0;

                while (!rdr.EndOfStream && cnt < 12)
                {
                    listBox1.Items.Add(rdr.ReadLine());
                    cnt++;

                }


                rdr.Close();
            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message, "Ошибка чтения из файла");
            }
            
            
        }
      
        private void button6_Click(object sender, EventArgs e)
        {
            series.tutt = null;
            series.Objects = null;
            series.Objects = new FuncBase[12];
            PopulateListbox();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Function17 Gi = new Function17();

            Gi.graf(pictureBox1.Width, pictureBox1.Height, (trackBar1.Value));
            pictureBox1.Image = Gi.Bitmap;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Derivative17 Gi = new Derivative17();

            Gi.graf(pictureBox1.Width, pictureBox1.Height, trackBar1.Value);

            pictureBox1.Image = Gi.Bitmap;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Integral17 Gi = new Integral17();
            Gi.graf(pictureBox1.Width, pictureBox1.Height, trackBar1.Value);
            pictureBox1.Image = Gi.Bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
    }
}
