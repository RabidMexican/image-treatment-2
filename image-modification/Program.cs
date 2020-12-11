using System;
using System.Windows.Forms;

using image_modification.views;

namespace image_modification
{
    static class Program
    {
        /// The main entry point for the application
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ExampleWindow());
        }

    }
}
