using System.Windows;

namespace SentroFPS.Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // <— OBLIGATOIRE sinon la fenêtre ne se charge pas
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mise à jour des paramètres (exemple)", "SentroFPS");
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Lancement du jeu (exemple)", "SentroFPS");
        }
    }
}
