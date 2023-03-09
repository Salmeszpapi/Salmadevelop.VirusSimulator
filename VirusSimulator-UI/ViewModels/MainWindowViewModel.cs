using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Styling;
using Avalonia.Threading;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using VirusSimulator_UI.Models;
using VirusSimulator_UI.Steps;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public string Greeting => "Welcome to Avalonia!";
        [Reactive]
        private DateTime startingSimulatoinTime { get; set; }
        [Reactive]
        private Stopwatch SimulationTimer { get; set; }
        private SimulationWelcomeStep simulationStep;

        private DateTime s = new DateTime();
        private TimeSpan ts = new TimeSpan(0, 0, 0);

        DispatcherTimer LiveTime;

        public MainWindowViewModel() : base()
        {
            AnalyzerBitmap = new Bitmap(@"Assets/cat.jpg");
            StartSimulationButton = new Bitmap(@"Assets/startSimulation.png");
            PauseSimulationButton = new Bitmap(@"Assets/pauseSimulation.png");
            StopSimulationButton = new Bitmap(@"Assets/stopSimulation.png");
            simulationStep = new SimulationWelcomeStep(this);
            ChangableViews = simulationStep.GetScreenContent();
            StartSimulationButtonClicked = ReactiveCommand.Create(StartSimulationClicked);
            PauseSimulationClickedCliced = ReactiveCommand.Create(PauseSimulationClicked);
            StopSimulationClickedClicked = ReactiveCommand.Create(StopSimulationClicked);
            BackToWelcomeViewButton = ReactiveCommand.Create(BackToWelcomeView);

            s = s.Date + ts;

            LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromMilliseconds(1);
            LiveTime.Tick += timer_Tick;
            SimulationTimer = new Stopwatch();

            SimulationTime = "0:0:0:0";
        }

        [Reactive]
        public string SimulationTime { get; set; }
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
        public ReactiveCommand<Unit, Unit> BackToWelcomeViewButton { get; set; }

        [Reactive]
        public UserControl ChangableViews { get; set; }

        private void StartSimulationClicked()
        {
            if(ChangableViews.GetType().Name == "SimulationPrepareView")
            {
                SimulationPrepareStep myPreparestep = (SimulationPrepareStep)WorkFlowManager.GetStep("SimulationPrepareStep");
                LiveTime.Start();
                SimulationTimer.Start();
                Simulator.RunningSimulation = true;
                Simulator.StartSimulation(myPreparestep.GetView().myRectanglesPoints);
                
            }
        }
        private void PauseSimulationClicked()
        {
            if(ChangableViews.GetType().Name == "SimulationPrepareView")
            {
                LiveTime.Stop();
                SimulationTimer.Stop();
                Simulator.StopSimulation();
                Simulator.RunningSimulation = false;
            }
        }
        private void StopSimulationClicked()
        {
            if (ChangableViews.GetType().Name == "SimulationPrepareView")
            {
                PopupWindowExitSimulationStep mypopup= new PopupWindowExitSimulationStep();
                mypopup.GetWindow().Show();
                LiveTime.Stop();
                SimulationTime = "0:0:0:0";
                SimulationTimer.Stop();
                SimulationTimer.Reset();
                Simulator.RunningSimulation = false;
                Simulator.StopSimulation();
            }
        }

        private void BackToWelcomeView()
        {
            ChangableViews = simulationStep.GetScreenContent();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            var timeSpan = SimulationTimer.Elapsed;
            
            SimulationTime = $"{timeSpan.Hours}:{timeSpan.Minutes}:{timeSpan.Seconds}:{timeSpan.Milliseconds}";
        }
    }
}