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
            StartSimulationButton = new Bitmap(@"Assets/startSimulation.png");
            PauseSimulationButton = new Bitmap(@"Assets/pauseSimulation.png");
            StopSimulationButton = new Bitmap(@"Assets/stopSimulation.png");
            SimulationWelcomeStep simulationStep = new SimulationWelcomeStep(this);
            ChangableViews = simulationStep.GetScreenContent();
            StartSimulationButtonClicked = ReactiveCommand.Create(StartSimulationClicked);
            PauseSimulationClickedCliced = ReactiveCommand.Create(PauseSimulationClicked);
            StopSimulationClickedClicked = ReactiveCommand.Create(StopSimulationClicked);
        }
        private string caption = "Default text";
        [Reactive]
        public string Caption
        {
            get => caption;
            set => this.RaiseAndSetIfChanged(ref caption, value);
        }

        public IBitmap AnalyzerBitmap { get; set; }
        public IBitmap StartSimulationButton { get; set; }
        public IBitmap StopSimulationButton { get; set; }
        public IBitmap PauseSimulationButton { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> StartSimulationButtonClicked { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> PauseSimulationClickedCliced { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> StopSimulationClickedClicked { get; set; }

        [Reactive]
        public UserControl ChangableViews { get; set; }

        private void StartSimulationClicked()
        {
            //mainWindowViewModel.ChangableViews = new SimulationPrepareStep().GetScreenContent();
        }
        private void PauseSimulationClicked()
        {

        }
        private void StopSimulationClicked()
        {

        }
    }
}