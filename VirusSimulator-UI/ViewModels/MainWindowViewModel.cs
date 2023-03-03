using Avalonia.Controls;
using Avalonia.Media.Imaging;
using ReactiveUI.Fody.Helpers;
using VirusSimulator_UI.Steps;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";

        //public IBitmap IconWarningBitmap => AssetsManager.Instance.GetImage(AssetsImages.IconWarning);

        public MainWindowViewModel() : base()
        {
            AnalyzerBitmap = new Bitmap(@"Assets/cat.jpg");
            SimulationStep simulationStep = new SimulationStep();
            ChangableViews = simulationStep.GetScreenContent();
        }
        [Reactive]
        public IBitmap AnalyzerBitmap { get; set; }
        [Reactive]
        public UserControl ChangableViews { get; set; }

        public string WelcomeHeader { get; }

        public string WelcomeText1 { get; }

        public string WelcomeText2 { get; }

        public string WelcomeText3 { get; }


    }
}