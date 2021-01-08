using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        private const string taskDescription = "Реализовать приложение для обрезки и вращения картинки";

        public Image Image { get; private set; }
        public Form5()
        {
            InitializeComponent();
            trackBar1.Value = 0;
            textBox2.Enabled = false;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Pomogi.SetTaskDescription(textBox1, 4, taskDescription);      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            Image = PomogiTask4.UploadImage(openFileDialog1.FileName ,pictureBox1);
            UpdateScrollBar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image = PomogiTask4.UploadDefaultImage(pictureBox1);
            UpdateScrollBar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)
            {
                MessageBox.Show("Нужно указать направление обрезки");
                return;
            }

            if(pictureBox1.Image == null)
            {
                MessageBox.Show("Сначала загрузите изображение");
                return;
            }

            Bitmap srcImage = new Bitmap(Image);
            CropImage(srcImage, trackBar1.Value);
        }

        private void CropImage(Bitmap image, int cropStep)
        { 
            int minX = 0;
            int minY = 0;
            int maxX = image.Width;
            int maxY = image.Height;
            int cropX = 0;
            int cropY = 0;
            
            if (radioButton1.Checked)
            {
                if (image.Width - cropStep > 0)
                {
                    minX = cropStep;
                }
                else
                {
                    MessageBox.Show("Невозможно больше обрезать изображение");
                    return;
                }
            }

            if (radioButton2.Checked)
            {
                if (image.Width - cropStep > 0)
                {
                    maxX -= cropStep;
                }
                else
                {
                    MessageBox.Show("Невозможно больше обрезать изображение");
                    return;
                }
            }


            if (radioButton3.Checked)
            {
                if (image.Height - cropStep > 0)
                {
                    maxY -= cropStep;
                }
                else
                {
                    MessageBox.Show("Невозможно больше обрезать изображение");
                    return;
                }
            }

            if (radioButton4.Checked)
            {
                if (image.Height - cropStep > 0)
                {
                    minY = cropStep;
                }
                else
                {
                    MessageBox.Show("Невозможно больше обрезать изображение");
                    return;
                }
            }
                
            Bitmap temp = new Bitmap(image.Width, image.Height);
            for (var y = minY; y < maxY; y++)
            {
                for (var x = minX; x < maxX; x++)
                {
                    temp.SetPixel(x, y, image.GetPixel(x, y));
                }
            }

            Image = temp;
            pictureBox1.Image = Image;

            UpdateScrollBar();
            pictureBox1.Refresh();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScrollBar();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScrollBar();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScrollBar();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateScrollBar();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar1.Value + "px";
            trackBar1.Refresh();
        }

        private void UpdateScrollBar()
        {
            trackBar1.Value = 0;
            if (pictureBox1.Image != null)
            {
                if (radioButton1.Checked || radioButton2.Checked)
                {
                    trackBar1.Maximum = Image.Width;
                }
                else
                {
                    trackBar1.Maximum = Image.Height;
                }
                trackBar1.Refresh();
            }
            textBox2.Text = trackBar1.Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = Image;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Image = Image;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Image = Image;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = Image;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox1.Image = Image;
        }
    }
}