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
        public Stopwatch SimulationTimer = new Stopwatch();
        private SimulationWelcomeStep simulationStep;


        public DispatcherTimer LiveTime;

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
            ChartsViewButtonClicked = ReactiveCommand.Create(SwitchToCharts);
            SimulationViewClicked = ReactiveCommand.Create(SwitchToimulation);

            LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromMilliseconds(1);
            LiveTime.Tick += timer_Tick;
        }
        [Reactive]
        public string SimulationTime2 { get; set; }
        public IBitmap AnalyzerBitmap { get; set; }
        public IBitmap StartSimulationButton { get; set; }
        public IBitmap StopSimulationButton { get; set; }
        public IBitmap PauseSimulationButton { get; set; }
        [Reactive]
        public int AllPeople { get; set; }
        [Reactive]
        public int AllHealthyPeoples { get; set; }
        [Reactive]
        public int AllInfectedPeoples { get; set; }
        [Reactive]
        public int AllDeadPeoples { get; set; }

        [Reactive]
        public ReactiveCommand<Unit, Unit> StartSimulationButtonClicked { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> PauseSimulationClickedCliced { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> StopSimulationClickedClicked { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> BackToWelcomeViewButton { get; set; }

        [Reactive]
        public ReactiveCommand<Unit, Unit> ChartsViewButtonClicked { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> SimulationViewClicked { get; set; }

        [Reactive]
        public UserControl ChangableViews { get; set; }
        [Reactive]
        public bool SimulationButtonVisible{ get; set; }
        [Reactive]
        public bool ChartsButtonVisible { get; set; }

        private void StartSimulationClicked()
        {
            if(!Simulator.RunningSimulation && (ChangableViews.GetType().Name == "SimulationPrepareView" ||
                ChangableViews.GetType().Name == "ChartsView"))
            {
                var a = ChangableViews.GetType().Name;
                SimulationPrepareStep myPreparestep = (SimulationPrepareStep)WorkFlowManager.GetStep("SimulationPrepareStep");
                LiveTime.Start();
                SimulationTimer.Start();
                Simulator.RunningSimulation = true;
                Simulator.StartSimulation(myPreparestep.GetView().myRectanglesPoints);
                Simulator.SimulatorState = SimulatorStateEnum.Run;
                SimulationButtonVisible = true;
                ChartsButtonVisible = true;

                if(WorkFlowManager.GetStep("ChartsStep") is null)
                {
                    ChartsStep chartsStep = new ChartsStep();
                }
            }
        }
        private void PauseSimulationClicked()
        {
            if(Simulator.RunningSimulation)
            {
                LiveTime.Stop();
                SimulationTimer.Stop();
                Simulator.RunningSimulation = false;
                Simulator.SimulatorState = SimulatorStateEnum.Pause;
            }
        }
        private void StopSimulationClicked()
        {

            LiveTime.Stop();
            SimulationTimer.Stop();
            Simulator.RunningSimulation = false;
            PopupWindowExitSimulationStep mypopup = new PopupWindowExitSimulationStep(this);
            mypopup.GetWindow().Show();

        }

        private void BackToWelcomeView()
        {
            ChangableViews = simulationStep.GetScreenContent();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            SimulationTime2 = Simulator.Iteration + " Days";

            var myPeopleList = Simulator.GetPeopleData();
            AllPeople = myPeopleList[0] - myPeopleList[3];
            AllHealthyPeoples = myPeopleList[1];
            AllInfectedPeoples = myPeopleList[2];
            AllDeadPeoples= myPeopleList[3];
        }
        private void SwitchToCharts()
        {
            MainWindowStep mainWindow = (MainWindowStep)WorkFlowManager.GetStep("MainWindowStep");
            ChartsStep charts = (ChartsStep)WorkFlowManager.GetStep("ChartsStep");
            mainWindow.SetView(charts.GetScreenContent());
        }

        private void SwitchToimulation()
        {
            MainWindowStep mainWindow = (MainWindowStep)WorkFlowManager.GetStep("MainWindowStep");
            SimulationPrepareStep mySimulationPrepareStep = (SimulationPrepareStep)WorkFlowManager.GetStep("SimulationPrepareStep");
            mainWindow.SetView(mySimulationPrepareStep.GetScreenContent());
        }
    }
}