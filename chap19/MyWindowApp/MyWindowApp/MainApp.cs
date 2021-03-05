using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWindowApp
{
    class MainApp : Form
    {
        private string title;

        public MainApp(string title)
        {
            this.title = title;
            this.MouseClick += MainApp_MouseClick;
        }

        private void MainApp_MouseClick(object sender, MouseEventArgs e)
        {
            var result = $"sender : {sender}\r\n" +
                         $"e: {e}\r\n" +
                         $"e.X: {e.X}, e.Y : {e.Y}\r\n" +
                         $"Button: {e.Button}, Clicks : {e.Clicks}\r\n";
            MessageBox.Show(result);
        }

        static void Main()
        {
            Application.Run(new MainApp("Mouse Event App"));
        }
    }
}
