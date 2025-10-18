using System;
using System.IO;
using System.Windows;

namespace SentroFPS.Launcher
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            File.WriteAllText("sentro_debug.txt", $"[{DateTime.Now}] Entrée dans Main()\n");

            var app = new App();
            var window = new MainWindow();
            app.Run(window);

            File.AppendAllText("sentro_debug.txt", $"[{DateTime.Now}] Fenêtre affichée\n");
        }
    }
}
