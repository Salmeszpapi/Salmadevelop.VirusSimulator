using Avalonia.Controls;
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
        public PopupWindowExitSimulationStep() 
        {
            myPopupWindowExitSimulationViewModel = new PopupWindowExitSimulationViewModel();
            myPopupWindowExitSimulationView = new PopupWindowExitSimulationView(){ DataContext = myPopupWindowExitSimulationViewModel };
            myPopupWindowExitSimulationViewModel.BackButtonClicked = ReactiveCommand.Create(GoBack);
            myPopupWindowExitSimulationViewModel.YesButtonClicked = ReactiveCommand.Create(StopSimulation);
            WorkFlowManager.SaveStep(this);
        }

        public override UserControl GetScreenContent()
        {
            throw new NotImplementedException();
        }
        public Window GetWindow()
        {
            return myPopupWindowExitSimulationView;
        }

        private void StopSimulation()
        {
            MainWindowStep mainWindow = (MainWindowStep)WorkFlowManager.GetStep("MainWindowStep");
            SimulationWelcomeStep simulationWelcomeStep = (SimulationWelcomeStep)WorkFlowManager.GetStep("SimulationWelcomeStep");
            mainWindow.SetView(simulationWelcomeStep.GetScreenContent());
            myPopupWindowExitSimulationView.Close();
        }

        private void GoBack()
        {
            Simulator.RunningSimulation = true;
            myPopupWindowExitSimulationView.Close();
        }
    }
}
