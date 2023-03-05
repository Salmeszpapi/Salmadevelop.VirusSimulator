using Avalonia.Controls;
using Avalonia.Media.Imaging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;
using VirusSimulator_UI.Steps;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";

        public MainWindowViewModel() : base()
        {
            AnalyzerBitmap = new Bitmap(@"Assets/cat.jpg");
            SimulationWelcomeStep simulationStep = new SimulationWelcomeStep(this);
            ChangableViews = simulationStep.GetScreenContent();
        }
        private string caption = "Default text";
        [Reactive]
        public string Caption
        {
            get => caption;
            set => this.RaiseAndSetIfChanged(ref caption, value);
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