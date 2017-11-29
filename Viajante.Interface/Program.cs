using System;
using System.Windows.Forms;
using Viajante.Interface.Telas;

namespace Viajante.Interface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InicializarAutoMapper();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void InicializarAutoMapper()
        {
            AutoMapperConfig.AutoMapperConfig.RegisterMappings();
        }
    }
}
