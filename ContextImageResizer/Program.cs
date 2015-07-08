using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ContextImageResizer.Helpers;

namespace ContextImageResizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                RegistryHelper.AddMenu("Resize Image(s)", Application.ExecutablePath + " %1");
                MessageBox.Show("Register context menu successfully!", Application.ProductName + " - " + Application.ProductVersion);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var form = new ResizeForm();
                form.ImageFiles = args;
                Application.Run(form);
            }
        }
    }
}
