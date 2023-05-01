using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Sim_Web.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive;
using VirusSimulator_UI.Models;
using VirusSimulator_UI.Steps;

namespace VirusSimulator_UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public Stopwatch SimulationTimer = new Stopwatch();
        private SimulationWelcomeStep simulationStep;


        public DispatcherTimer LiveTime;

        public MainWindowViewModel() : base()
        {
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
        [Reactive]
        public string SimulatorName { get; set; }
        public IBitmap AnalyzerBitmap { get; set; }
        public IBitmap StartSimulationButton { get; set; }
        public IBitmap StopSimulationButton { get; set; }
        public IBitmap PauseSimulationButton { get; set; }
        [Reactive]
        public int? AllPeople { get; set; }
        [Reactive]
        public int? AllHealthyPeoples { get; set; }
        [Reactive]
        public int? AllInfectedPeoples { get; set; }
        [Reactive]
        public int? AllDeadPeoples { get; set; }

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
        public UserControl MyPointedDatasView { get; set; }
        [Reactive]
        public bool SimulationButtonVisible{ get; set; }
        [Reactive]
        public bool ChartsButtonVisible { get; set; }

        private async void StartSimulationClicked()
        {
            if (!Simulator.RunningSimulation && (ChangableViews.GetType().Name == "SimulationPrepareView" ||
                ChangableViews.GetType().Name == "ChartsView"))
            {
                SimulatorName = $"Virus: {Simulator.VirusName}";
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

            SimulatorName = "";
            PopupWindowExitSimulationStep mypopup = new PopupWindowExitSimulationStep(this);
            if(Simulator.RunningSimulation)
            {
                mypopup.GetVM().BackButtonVisible = true;
            }
            mypopup.GetWindow().Show();
            Simulator.RunningSimulation = false;
            Simulator.Iteration = 0;
            //mainWindow.SetViewForPeople(new UserControl());
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
            if (charts == null)
            {
                mainWindow.SetView(new ChartsStep().GetScreenContent());
            }
            else
            {
                mainWindow.SetView(charts.GetScreenContent());
            }
        }

        private void SwitchToimulation()
        {
            MainWindowStep mainWindow = (MainWindowStep)WorkFlowManager.GetStep("MainWindowStep");
            SimulationPrepareStep mySimulationPrepareStep = (SimulationPrepareStep)WorkFlowManager.GetStep("SimulationPrepareStep");
            mainWindow.SetView(mySimulationPrepareStep.GetScreenContent());
        }
    }
}