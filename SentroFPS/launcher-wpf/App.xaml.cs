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
                File.WriteAllText("SentroFPS_log.txt", "Démarrage de SentroFPS à " + DateTime.Now + "\n");

                var window = new MainWindow();
                window.Show();

                File.AppendAllText("SentroFPS_log.txt", "Fenêtre affichée avec succès.\n");
            }
            catch (Exception ex)
            {
                File.AppendAllText("SentroFPS_log.txt", "Erreur au démarrage : " + ex + "\n");
                MessageBox.Show(ex.ToString(), "Erreur SentroFPS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
