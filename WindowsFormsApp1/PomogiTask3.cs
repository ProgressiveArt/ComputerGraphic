using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class PomogiTask3
    {
        public static void BresenhamLine(int x0, int y0, int x1, int y1, PictureBox pictureBox)
        {
            Graphics gr = Graphics.FromImage(pictureBox.Image);
            var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

            if (steep)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }


            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }

            int dx = x1 - x0;
            int dy = Math.Abs(y1 - y0);
            int error = dx / 2;
            int ystep = (y0 < y1) ? 1 : -1;
            int y = y0;

            for (int x = x0; x <= x1; x++)
            {
                DrawPoint(steep ? y : x, steep ? x : y, gr, pictureBox);
                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }

        private static void Swap(ref int x, ref int y)
        {
            var temp = x;
            x = y;
            y = temp;
        }

        private static void DrawPoint(int x, int y, Graphics gr, PictureBox pictureBox)
        {
            gr.FillRectangle(Brushes.Black, x, y, 1, 1);
            pictureBox.Refresh();
        }

        public static void LineDDA(int x0, int y0, int x1, int y1, PictureBox pictureBox)
        {
            Graphics gr = Graphics.FromImage(pictureBox.Image);

            int deltaX = Math.Abs(x0 - x1);
            int deltaY = Math.Abs(y0 - y1);

            int length = Math.Max(deltaX, deltaY);

            if (length == 0)
            {
                gr.FillEllipse(Brushes.Black, x0, y0, 1, 1);
                pictureBox.Refresh();
                return;
            }

            double dX = (x1 - x0) / (double)length;
            double dY = (y1 - y0) / (double)length;

            double x = x0;
            double y = y0;

            length++;
            while (length >= 0)
            {
                gr.FillRectangle(Brushes.Black, (int)x, (int)y, 1, 1);
                pictureBox.Refresh();

                x += dX;
                y += dY;
                length--;
            }
            pictureBox.Refresh();
        }
    }
}
