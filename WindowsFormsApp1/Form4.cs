using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        private const string taskDescription = "Реализовать алгоритм Брезенхема растеризации отрезка, реализовать алгоритм DDA растеризации отрезка";
        int startBresenhamPointX, startBresenhamPointY;
        int startDDAPointX, startDDAPointY;

        public Form4()
        {
            InitializeComponent();
            Size = new Size(1280, 720);
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Text = "Алгоритм Брезенхема растеризации отрезка";
            textBox3.Text = "Алгоритм DDA растеризации отрезка";
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Pomogi.SetTaskDescription(textBox1, 3, taskDescription);

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics grf = Graphics.FromImage(bmp);
            grf.Clear(Color.White);
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();

            Bitmap bmp2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics grf2 = Graphics.FromImage(bmp2);
            grf2.Clear(Color.White);
            pictureBox2.Image = bmp2;
            pictureBox2.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startBresenhamPointX != 0 && startBresenhamPointY != 0)
                PomogiTask3.BresenhamLine(startBresenhamPointX, startBresenhamPointY, e.X, e.Y, pictureBox1);

            startBresenhamPointX = e.X;
            startBresenhamPointY = e.Y;
        }

        

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (startDDAPointX != 0 && startDDAPointY != 0)
                PomogiTask3.LineDDA(startDDAPointX, startDDAPointY, e.X, e.Y, pictureBox2);

            startDDAPointX = e.X;
            startDDAPointY = e.Y;
        }
    }
}
