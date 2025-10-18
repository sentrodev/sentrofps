using System;
using System.Windows;

namespace SentroFPS.Launcher
{
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += (s, e) =>
            {
                MessageBox.Show(e.Exception.ToString(), "Erreur au démarrage");
                e.Handled = true;
            };
        }
    }
}
