using System;
using System.Windows.Forms;

namespace FinalHP1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Asegúrate de que este sea el nombre de tu formulario principal
        }
    }
}
