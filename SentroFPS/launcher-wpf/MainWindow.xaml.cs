using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace SentroFPS.Launcher
{
    public partial class MainWindow : Window
    {
        private readonly Services.ConfigService _configService = new();
        private Models.RemoteConfig? _config;

        public MainWindow()
        {
            InitializeComponent();
            MouseLeftButtonDown += (_, __) => DragMove(); // drag sans barre
            _ = LoadConfig();
        }

        private async Task LoadConfig()
        {
            try
            {
                Announcement.Text = "Chargement de la configuration...";
                var url = "https://raw.githubusercontent.com/TON_USER/sentrofps-config/main/config.json";
                _config = await _configService.FetchAsync(url);
                Announcement.Text = _config.Announcement ?? "";
                ChkFps.IsChecked = _config.Toggles?.FpsBoost ?? false;
                ChkPng.IsChecked = _config.Toggles?.PngEnabled ?? false;
            }
            catch (Exception ex)
            {
                Announcement.Text = "Impossible de charger la config.";
                Debug.WriteLine(ex);
                MessageBox.Show(ex.Message, "SentroFPS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_config is null)
            {
                MessageBox.Show("Config introuvable");
                return;
            }

            try
            {
                BtnUpdate.IsEnabled = false;
                Announcement.Text = "Application des options...";
                await Services.GameService.ApplyOptionsAsync(_config, (bool)ChkFps.IsChecked!, (bool)ChkPng.IsChecked!);
                Announcement.Text = "Options appliquées ✔";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
            finally
            {
                BtnUpdate.IsEnabled = true;
            }
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (_config is null)
            {
                MessageBox.Show("Config introuvable");
                return;
            }

            try
            {
                Services.GameService.Launch(_config);
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Close_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}
