using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication12
{
    public partial class Form1 : Form
    {
        private Pen MyPen = new Pen(Color.Black, 2);
        Node1 node1 = new Node1();
        Node2 node2 = new Node2();
        Node3 node3 = new Node3();
        Node4 node4 = new Node4();
        Node5 node5 = new Node5();

        public Form1()
        {
            InitializeComponent();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.Controls.Add(pictureBox1);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            
            SolidBrush brush = new SolidBrush(ForeColor);
            g.DrawEllipse(MyPen, node1.getX(), node1.getY(), 20, 20);
            g.DrawString("1", Font, brush , node1.getX()+5, node1.getY()+4);
            g.DrawEllipse(MyPen, node2.getX(), node2.getY(), 20, 20);
            g.DrawString("2", Font, brush, node2.getX() + 5, node2.getY() + 4);
            g.DrawEllipse(MyPen, node3.getX(), node3.getY(), 20, 20);
            g.DrawString("3", Font, brush, node3.getX() + 5, node3.getY() + 4);
            g.DrawEllipse(MyPen, node4.getX(), node4.getY(), 20, 20);
            g.DrawString("4", Font, brush, node4.getX() + 5, node4.getY() + 4);
            g.DrawEllipse(MyPen, node5.getX(), node5.getY(), 20, 20);
            g.DrawString("5", Font, brush, node5.getX() + 5, node5.getY() + 4);


            using(GraphicsPath capPath = new GraphicsPath())
            {
                capPath.AddLine(-5, -7, 0, 0);
                capPath.AddLine(5, -7, 0, 0);
                MyPen.CustomEndCap = new System.Drawing.Drawing2D.CustomLineCap(null, capPath);
            }

            g.DrawLine(MyPen, node1.getX() + 19, node1.getY() + 9, node2.getX(), node2.getY() + 13); // 1->2
            g.DrawLine(MyPen, node1.getX() + 19, node1.getY() + 9, node3.getX(), node3.getY() + 7); // 1->3
            g.DrawLine(MyPen, node2.getX() + 19, node2.getY() + 8, node4.getX(), node4.getY() + 10); // 2->4
            g.DrawLine(MyPen, node3.getX() + 9, node3.getY(), node2.getX() + 9, node2.getY() + 19); // 3->2
            g.DrawLine(MyPen, node3.getX() + 19, node3.getY() + 14 , node5.getX(), node5.getY() + 10); // 3->5
            g.DrawLine(MyPen, node5.getX() + 9, node5.getY(), node4.getX() + 9, node4.getY() + 19); // 5->4

            g.DrawString("10", Font, brush, (node1.getX() + node2.getX()) / 2, ((node1.getY() + node2.getY()) / 2) - 4);
            g.DrawString("7", Font, brush, ((node1.getX() + node3.getX()) / 2) + 3, ((node1.getY() + node3.getY()) / 2) + 10);
            g.DrawString("1", Font, brush, ((node3.getX() + node2.getX()) / 2) - 3, (node3.getY() + node2.getY()) / 2);
            g.DrawString("1", Font, brush, (node3.getX() + node5.getX()) / 2, ((node3.getY() + node5.getY()) / 2) + 12);
            g.DrawString("11", Font, brush, (node2.getX() + node4.getX()) / 2, ((node2.getY() + node4.getY()) / 2) - 4);
            g.DrawString("0", Font, brush, ((node5.getX() + node4.getX()) / 2) - 3, (node5.getY() + node4.getY()) / 2);

            g.Save();
        }
    }

    class Node1
    {
        private int x = 50;
        private int y = 120;
       public int getX()
        {
            return x;
        }
       public int getY()
        {
            return y;
        }
    }

    class Node2
    {
        private int x = 170;
        private int y = 60;
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
    }



    class Node3
    {
        private int x = 170;
        private int y = 180;
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }

    }

    class Node4
    {
        private int x = 290;
        private int y = 20;
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
    }

    class Node5
    {
        private int x = 290;
        private int y = 230;
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
    }

}
