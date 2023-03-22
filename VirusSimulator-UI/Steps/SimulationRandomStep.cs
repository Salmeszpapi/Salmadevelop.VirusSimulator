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
        private SimulationRandomViewModel mySimulationRandomViewModel;
        private MainWindowViewModel MainWindowViewModel;

        public SimulationRandomStep(MainWindowViewModel mainWindowViewModel)
        {
            this.MainWindowViewModel = mainWindowViewModel;
            mySimulationRandomViewModel = new SimulationRandomViewModel();
            simulationRandomView = new RandomPopupView() { DataContext = mySimulationRandomViewModel };
            mySimulationRandomViewModel.BackButtonClicked = ReactiveCommand.Create(GoBack);
            mySimulationRandomViewModel.ApproveButtonClicked = ReactiveCommand.Create(CreateRandomGraph);
            mySimulationRandomViewModel.RandomizeButton = ReactiveCommand.Create(Randomize);
            WorkFlowManager.SaveStep(this);
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
            var mySimulationPrepareStep = new SimulationPrepareStep(NewWindowType.Random, mySimulationRandomViewModel.Nodes,
                mySimulationRandomViewModel.MinConnections, mySimulationRandomViewModel.MaxConnections);

            //MainWindowViewModel.ChangableViews = mySimulationPrepareStep.GetScreenContent();
            simulationRandomView.Close();

            VirusCreatePopupStep virusCreatePopupStep = new VirusCreatePopupStep(NewWindowType.Random, mySimulationRandomViewModel.Nodes,
                mySimulationRandomViewModel.MinConnections, mySimulationRandomViewModel.MaxConnections);
            virusCreatePopupStep.GetView().Show();

        }

        private void Randomize()
        {
            mySimulationRandomViewModel.Nodes = new Random().Next(1, 100).ToString();
            mySimulationRandomViewModel.MinConnections = new Random().Next(1, 3).ToString();
            mySimulationRandomViewModel.MaxConnections = new Random().Next(5, 10).ToString();
        }
    }
}
