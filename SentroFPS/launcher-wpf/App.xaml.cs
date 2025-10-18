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
                File.WriteAllText("SentroFPS_log.txt", "Lancement SentroFPS.exe à " + DateTime.Now + "\n");

                var app = new App();
                var window = new MainWindow();
                app.Run(window);

                File.AppendAllText("SentroFPS_log.txt", "MainWindow lancée avec succès.\n");
            }
            catch (Exception ex)
            {
                File.AppendAllText("SentroFPS_log.txt", "ERREUR : " + ex + "\n");
                MessageBox.Show(ex.ToString(), "Crash SentroFPS");
            }
        }
    }
}
