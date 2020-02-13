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

namespace ProgressBars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Timer t = new Timer();
        double pbUnit;
        int pbWIDTH, pbHEIGHT, pbComplete;
        Bitmap bmp;
        Graphics g;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            t.Interval = 50;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbWIDTH = pictureBox1.Width;
            pbHEIGHT = pictureBox1.Height;
            pbUnit = pbWIDTH / 100.0;
            //pbComplete = 0;
            bmp = new Bitmap(pbWIDTH, pbHEIGHT);
            pbComplete = 0;

            string path = Path.GetTempFileName();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            pbComplete++;
            if (pbComplete > 100)
            {
                pbComplete = 0;
                g.Dispose();
                t.Stop();
                MessageBox.Show("Loadup is done");
            }


            g = Graphics.FromImage(bmp);
            g.Clear(Color.LightSkyBlue);
            // Something wrong wtih drawing, wtf is 1-10% at restart?
            // The thing accelerates with each click. No garbage collector prob? Or double to int conversion dispersion?   // (int) Math.Round((pbComplete * pbUnit)
            // ^Each click accelerates the thing - probably the reason of the bug
            g.FillRectangle(Brushes.CornflowerBlue, new Rectangle(0, 0, (int)(pbComplete * pbUnit), pbHEIGHT));
            g.DrawString(pbComplete + "%", new Font("Arial", pbHEIGHT / 2), Brushes.Black, new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));
            //
            pictureBox1.Image = bmp;




            /*System.IO.StreamWriter textFile = new System.IO.StreamWriter(@"c:\textfile.txt");
            textFile.WriteLine("Test words");
            textFile.Close();*/

            /*if (!File.Exists(@"C:\Users\Public\test.rtf")) File.Create(@"C:\Users\Public\test.rtf");
            StreamWriter output = new StreamWriter(@"C:\Users\Public\test.rtf");
            output.WriteLine("test");
            output.Close();*/


        }
    }
}
