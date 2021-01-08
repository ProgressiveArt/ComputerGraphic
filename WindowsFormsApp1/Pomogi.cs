using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Pomogi
    {
        public static void SetTaskDescription(TextBox textbox, int taskNumber, string taskDescription)
        {
            textbox.Text = new StringBuilder().AppendLine("Задание №" + taskNumber).Append(": " + taskDescription).ToString();
        }
    }
}
