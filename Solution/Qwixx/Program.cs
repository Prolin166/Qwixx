 using System;
 using System.Windows.Forms;
 using Autofac;
 using Qwixx.FrontEnd;

 namespace Qwixx
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ContainerBuilder();
            IContainer container = new AutoFacContainer(builder).Configure();

            Application.Run(container.Resolve<MainView>());

        }
    }
}
