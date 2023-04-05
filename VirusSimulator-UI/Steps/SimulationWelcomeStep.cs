using Avalonia.Controls;
using Avalonia.Logging;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusSimulator_UI.Models;
using VirusSimulator_UI.ViewModels;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI.Steps
{
    public class SimulationWelcomeStep : BaseStep
    {
        SimulationWelcomeViewModel mySimulationViewModel;
        SimulationWelcomeView simulationView;
        MainWindowViewModel mainWindowViewModel;
        public SimulationWelcomeStep(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            mySimulationViewModel = new SimulationWelcomeViewModel();
            simulationView = new SimulationWelcomeView() { DataContext = mySimulationViewModel };
            mySimulationViewModel.CreateButtonClicked = ReactiveCommand.Create(CreateSimulationClicked);
            mySimulationViewModel.OpenButtonClicked = ReactiveCommand.Create(OpenSimulationClicked);
            mySimulationViewModel.RandomButtonClicked = ReactiveCommand.Create(RandomSimulationClicked);
            WorkFlowManager.SaveStep(this);
        }

        public override UserControl GetScreenContent()
        {
            return simulationView;
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }

        private void CreateSimulationClicked()
        {
            VirusCreatePopupStep virusCreatePopupStep = new VirusCreatePopupStep();
            virusCreatePopupStep.GetView().Show();
        }
        private void OpenSimulationClicked()
        {
            OpenSimulatorStep openSimulator = new OpenSimulatorStep();
            openSimulator.GetWindow().Show();
        }
        private void RandomSimulationClicked()
        {
            var a = new SimulationRandomStep(mainWindowViewModel);
            a.GetWindow().Show();
            //mainWindowViewModel.ChangableViews = new SimulationRandomStep(NewWindowType.Random).GetScreenContent();
        }
    }
}
