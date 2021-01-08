using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private const string taskDescription = "Считать и вывести bmp файл";
        public Form2()
        {
            InitializeComponent();
            Size = new Size(1280, 720);

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox4.Text = "Результат считывания и вывода bmp файла";
            textBox5.Enabled = false;
            textBox5.Text = "Оригинальное изображение и информация о нем";
            button1.Text = "Загрузить своё изображение";
            button2.Text = "Взять BMP котика из багажника";
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            openFileDialog1.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Pomogi.SetTaskDescription(textBox2, 1, taskDescription);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PomogiTask1.UploadImage(openFileDialog1, pictureBox1, pictureBox2, textBox1, textBox3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PomogiTask1.UploadDefaultImage(pictureBox1, pictureBox2, textBox1, textBox3);
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if(textBox3.Text.Length != 0)
            {
                Clipboard.SetText(textBox3.Text);
                MessageBox.Show("Текст скопирован");
            }
        }
    }
}
