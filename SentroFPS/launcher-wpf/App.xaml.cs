using System;
using System.IO;
using System.Windows;

namespace SentroFPS.Launcher
{
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            try
            {
                File.WriteAllText("SentroFPS_log.txt", $"[{DateTime.Now}] Lancement du programme\n");

                var app = new App();
                var mainWindow = new MainWindow();
                app.Run(mainWindow);

                File.AppendAllText("SentroFPS_log.txt", $"[{DateTime.Now}] Fenêtre principale affichée\n");
            }
            catch (Exception ex)
            {
                File.AppendAllText("SentroFPS_log.txt", $"[{DateTime.Now}] Erreur : {ex}\n");
                MessageBox.Show(ex.ToString(), "Erreur SentroFPS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
