using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        private Pen MyPen = new Pen(Color.Black, 1);
        private Pen MyPen1 = new Pen(Color.Black, 1);
        private Pen MyPen2 = new Pen(Color.Red, 1);
        //private Brush MyBrush = new SolidBrush(Color.Black);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Move(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawEllipse(MyPen, e.X - 20, e.Y - 20, 40, 40);
                g.Save();
            }
            if (e.Button==MouseButtons.Right && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawRectangle(MyPen, e.X - 20, e.Y - 20, 40, 40);
                g.Save();
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Point point1 = new Point(e.X, e.Y - 20);
            Point point2 = new Point(e.X + 20, e.Y + 20);
            Point point3 = new Point(e.X - 20, e.Y + 20);
            Point[] curvePoints = { point1, point2, point3 };
            g.DrawPolygon(MyPen, curvePoints);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = "X=" + e.X.ToString() + ";Y=" + e.Y.ToString();
            if(e.Button==MouseButtons.Left)
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(MyPen, e.X, e.Y, e.X + 1, e.Y);
                g.Save();
            }
            else if(e.Button==MouseButtons.Right)
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(MyPen, e.X-4, e.Y-4, e.X + 4, e.Y + 4);
                g.Save();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad1) MyPen = MyPen1;
            if (e.KeyCode == Keys.NumPad2) MyPen = MyPen2;
            if (e.KeyCode == Keys.Q) this.Close();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Cursor = Cursors.Cross;
        }

        private void pictureBox1_DragLeave(object sender, EventArgs e)
        {
            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Cursor = Cursors.Default;
        }
    }
}
