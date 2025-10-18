using System;
using System.IO;
using System.Windows;

namespace SentroFPS.Launcher
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                File.AppendAllText("SentroFPS_log.txt", "Lancement SentroFPS à " + DateTime.Now + "\n");

                var main = new MainWindow();
                main.Show();

                File.AppendAllText("SentroFPS_log.txt", "MainWindow affichée avec succès.\n");
            }
            catch (Exception ex)
            {
                File.AppendAllText("SentroFPS_log.txt", "Erreur au démarrage : " + ex.ToString() + "\n");
                MessageBox.Show(ex.ToString(), "Erreur au démarrage");
            }
        }
    }
}
