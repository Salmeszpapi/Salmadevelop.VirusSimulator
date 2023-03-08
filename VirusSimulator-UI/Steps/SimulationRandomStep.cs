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
    public class SimulationRandomStep : BaseStep
    {
        private RandomPopupView simulationRandomView;
        private SimulationRandomViewModel simulationPrepareViewModel;
        private MainWindowViewModel MainWindowViewModel;
        public SimulationRandomStep(MainWindowViewModel mainWindowViewModel)
        {
            this.MainWindowViewModel = mainWindowViewModel;
            simulationPrepareViewModel = new SimulationRandomViewModel();
            simulationRandomView = new RandomPopupView() { DataContext = simulationPrepareViewModel };
            simulationPrepareViewModel.BackButtonClicked = ReactiveCommand.Create(GoBack);
            simulationPrepareViewModel.ApproveButtonClicked = ReactiveCommand.Create(CreateRandomGraph);
        }

        public override UserControl GetScreenContent()
        {
            throw new NotImplementedException();
        }

        public Window GetWindow()
        {
            return simulationRandomView;
        }
        private void GoBack()
        {
            simulationRandomView.Close();
        }
        private void CreateRandomGraph()
        {
            
            var mySimulationPrepareStep = new SimulationPrepareStep(NewWindowType.Random);


            MainWindowViewModel.ChangableViews = mySimulationPrepareStep.GetScreenContent();
            simulationRandomView.Close();
        }
    }
}
