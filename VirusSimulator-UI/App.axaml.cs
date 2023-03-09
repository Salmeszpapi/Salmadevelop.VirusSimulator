using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using VirusSimulator_UI.Steps;
using VirusSimulator_UI.ViewModels;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                MainWindowStep mainWindow = new MainWindowStep();

                desktop.MainWindow = mainWindow.GetScreenWindow();

            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}