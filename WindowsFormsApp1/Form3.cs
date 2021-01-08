using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private const string taskDescription = "Дана произвольная картинка, мышкой указать точку и залить область";

        private Color color = Color.Black;
        private string selection = "Circle";

        public Form3()
        {
            InitializeComponent();
            Size = new Size(1280, 720);
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox2.Text = "Размер";
            numericUpDown1.Value = 10;
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 500;
            button1.Text = "Выбрать цвет";
            button2.Text = "Очистить";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Pomogi.SetTaskDescription(textBox1, 2, taskDescription);
            PomogiTask2.UploadDefaultImage(pictureBox1);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);

            PointF[] curvePoints =
            {
                        new PointF(e.X, e.Y),
                        new PointF(e.X, e.Y + (int)numericUpDown1.Value),
                        new PointF(e.X + (int)numericUpDown1.Value, e.Y + (int)numericUpDown1.Value/2)
            };

            switch (selection)
            {
                case "Triangle":
                    g.FillPolygon(new SolidBrush(color), curvePoints);
                    break;
                case "Cube":
                    g.FillRectangle(new SolidBrush(color), e.X, e.Y, (int)numericUpDown1.Value, (int)numericUpDown1.Value);
                    break;
                case "Circle":
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, (int)numericUpDown1.Value, (int)numericUpDown1.Value);
                    break;
                default:
                    g.FillEllipse(new SolidBrush(color), e.X, e.Y, (int)numericUpDown1.Value, (int)numericUpDown1.Value);
                    break;
            }

            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = color;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                color = MyDialog.Color;
                Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                Graphics grf = Graphics.FromImage(bmp);
                grf.Clear(color);
                pictureBox2.Image = bmp;
                pictureBox2.Refresh();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                selection = radioButton.Text;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                selection = radioButton.Text;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                selection = radioButton.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose(); 
                PomogiTask2.UploadDefaultImage(pictureBox1);
            }
        }
    }
}
