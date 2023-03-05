using Avalonia.Controls;
using Avalonia.Logging;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            mainWindowViewModel.Caption = "New text";
            mySimulationViewModel.CreateButtonClicked = ReactiveCommand.Create(CreateSimulationClicked);
            //CreateSimulationClicked(mainWindowViewModel);
        }

        public override UserControl GetScreenContent()
        {
            return simulationView;
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }
        private void CreateSimulationClicked2()
        {

        }

        private void CreateSimulationClicked()
        {
            mainWindowViewModel.ChangableViews = new SimulationPrepareStep().GetScreenContent();
        }
        private void OpenSimulationClicked(MainWindowViewModel mainWindowViewModel)
        {

        }
        private void RandomSimulationClicked(MainWindowViewModel mainWindowViewModel)
        {

        }
    }
}
