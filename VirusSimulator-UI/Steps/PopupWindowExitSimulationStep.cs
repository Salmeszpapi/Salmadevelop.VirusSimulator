﻿using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusSimulator_UI.Models;
using VirusSimulator_UI.ViewModels;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI.Steps
{
    public class PopupWindowExitSimulationStep : BaseStep
    {
        private PopupWindowExitSimulationViewModel myPopupWindowExitSimulationViewModel;
        private PopupWindowExitSimulationView myPopupWindowExitSimulationView;
        private MainWindowViewModel mainWindowViewModel;
        private SimulationPrepareStep simulationPrepareStep;
        public PopupWindowExitSimulationStep(MainWindowViewModel mainWindowViewModel,SimulationPrepareStep simulationPrepareStep) 
        {
            myPopupWindowExitSimulationViewModel = new PopupWindowExitSimulationViewModel();
            myPopupWindowExitSimulationView = new PopupWindowExitSimulationView(){ DataContext = myPopupWindowExitSimulationViewModel };
            myPopupWindowExitSimulationViewModel.BackButtonClicked = ReactiveCommand.Create(GoBack);
            myPopupWindowExitSimulationViewModel.YesButtonClicked = ReactiveCommand.Create(StopSimulation);
            this.mainWindowViewModel = mainWindowViewModel;
            Simulator.SimulatorState = SimulatorStateEnum.Pause;
            this.simulationPrepareStep = simulationPrepareStep;

            WorkFlowManager.SaveStep(this);
        }

        public override UserControl GetScreenContent()
        {
            throw new NotImplementedException();
        }

        public PopupWindowExitSimulationViewModel GetVM()
        {
            return myPopupWindowExitSimulationViewModel;
        }
        public Window GetWindow()
        {
            return myPopupWindowExitSimulationView;
        }

        private void StopSimulation()
        {
            MainWindowStep mainWindow = (MainWindowStep)WorkFlowManager.GetStep("MainWindowStep");
            PeoplesInNodeStep myPeoplesInNodeStep = (PeoplesInNodeStep)WorkFlowManager.GetStep("PeoplesInNodeStep");
            SimulationWelcomeStep simulationWelcomeStep = (SimulationWelcomeStep)WorkFlowManager.GetStep("SimulationWelcomeStep");
            mainWindow.SetView(simulationWelcomeStep.GetScreenContent());

            mainWindowViewModel.LiveTime.Stop();
            mainWindowViewModel.SimulationTimer.Stop();
            mainWindowViewModel.SimulationTimer.Reset();
            mainWindowViewModel.SimulationTime2 = "";
            Simulator.RunningSimulation = false;
            
            Simulator.SimulatorState = SimulatorStateEnum.Stop;
            Simulator.Iteration = 0;
            mainWindowViewModel.SimulationButtonVisible = false;
            mainWindowViewModel.ChartsButtonVisible = false;

            mainWindowViewModel.AllDeadPeoples = null;
            mainWindowViewModel.AllInfectedPeoples = null;
            mainWindowViewModel.AllHealthyPeoples = null;
            mainWindowViewModel.AllPeople = null;

            mainWindowViewModel.MyPointedDatasView = null;
            WorkFlowManager.DeleteStep("ChartsStep");
            myPopupWindowExitSimulationView.Close();

            //myPeoplesInNodeStep.TearDown();
            WorkFlowManager.DeleteStep("PeoplesInNodeStep");
            Simulator.IsSimulatiorLoaded =false;

        }

        private void GoBack()
        {
            Simulator.RunningSimulation = true;
            Simulator.StartSimulation(simulationPrepareStep.GetView().myRectanglesPoints);
            Simulator.SimulatorState = SimulatorStateEnum.Run;
            mainWindowViewModel.LiveTime.Start();
            mainWindowViewModel.SimulationTimer.Start();
            myPopupWindowExitSimulationView.Close();
        }
    }
}
