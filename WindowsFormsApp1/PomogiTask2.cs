using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class PomogiTask2
    {
        public static void UploadDefaultImage(PictureBox pictureBox)
        {
            const string imagePath = "..\\..\\Resources\\Images\\DefaultImage.bmp";
            pictureBox.Image = Image.FromFile(imagePath);
        }
    }
}
