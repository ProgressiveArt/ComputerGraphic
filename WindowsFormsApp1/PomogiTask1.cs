using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class PomogiTask1
    {
        public static void UploadImage(OpenFileDialog openFileDialog, PictureBox pictureBox, PictureBox pictureBox2, TextBox textbox, TextBox textbox2)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            var imagePath = openFileDialog.FileName;

            pictureBox.Image = Image.FromFile(imagePath);
            SetFileInfo(textbox, imagePath);
            textbox2.Text = DrawBitmapImageResult(imagePath, pictureBox2);

            MessageBox.Show($"ЭТО ПОБЕДА!!!");
        }

        public static void UploadDefaultImage(PictureBox pictureBox, PictureBox pictureBox2, TextBox textbox, TextBox textbox2)
        {
            const string imagePath = "..\\..\\Resources\\Images\\DefaultImage.bmp";
            pictureBox.Image = Image.FromFile(imagePath);
            SetFileInfo(textbox, imagePath);
            textbox2.Text = DrawBitmapImageResult(imagePath, pictureBox2);
            MessageBox.Show($"ЭТО ПОБЕДА!!!");
        }

        private static void SetFileInfo(TextBox textbox, string path)
        {
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                textbox.Text = new StringBuilder().AppendLine("File info:")
                    .AppendLine()
                    .AppendLine("Name: " + fileInf.Name)
                    .AppendLine("CreationTime: " + fileInf.CreationTime)
                    .AppendLine("Size: " + fileInf.Length)
                    .ToString();
            }
        }

        private static string DrawBitmapImageResult(string imagePath, PictureBox pictureBox)
        { 
            Bitmap srcImage = new Bitmap(Image.FromFile(imagePath));
            var sb = new StringBuilder();
            int[][] result = new int[srcImage.Height][];
            Bitmap Temp = new Bitmap(srcImage.Width, srcImage.Height);
            for (var y = 0; y < srcImage.Height; y++)
            {
                result[y] = new int[srcImage.Width];
                for (var x = 0; x < srcImage.Width; x++)
                {
                    Color srcPixel = srcImage.GetPixel(x, y);
                    result[y][x] = srcPixel.ToArgb();
                    sb.Append(result[y][x]);
                    Temp.SetPixel(x, y, Color.FromArgb(result[y][x]));
                }
                sb.Append('\n');
            }

            pictureBox.Image = Temp;
            return sb.ToString();
        }
    }
}
