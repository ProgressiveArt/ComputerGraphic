using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class PomogiTask4
    {
        public static Image UploadImage(string imagePath, PictureBox pictureBox)
        { 
            var image = Image.FromFile(imagePath);
            pictureBox.Image = image;
            return image;
        }

        public static Image UploadDefaultImage(PictureBox pictureBox)
        {
            const string imagePath = "..\\..\\Resources\\Images\\DefaultImage.bmp";
            var image = Image.FromFile(imagePath);
            pictureBox.Image = image;
            return image;
        }
    }
}
