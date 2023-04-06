using Avalonia.Controls;
using ReactiveUI;
using Sim_Web.Db;
using Sim_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusSimulator_UI.ViewModels;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI.Steps
{
    public class OpenSimulatorStep : BaseStep
    {
        OpenSimulatorViewModel openSimulatorViewModel { get; set; }
        OpenSimulatorView openSimulatorView { get; set; }
        public OpenSimulatorStep()
        {
            openSimulatorViewModel = new OpenSimulatorViewModel();
            openSimulatorView = new OpenSimulatorView() { DataContext = openSimulatorViewModel};
            openSimulatorViewModel.BackButtonClicked = ReactiveCommand.Create(GoBack);
            openSimulatorViewModel.YesButtonClicked = ReactiveCommand.Create(OkButton);
            WorkFlowManager.SaveStep(this);
        }

        private void OkButton()
        {
            GetWindow().Close();
            MainWindowStep myMainWindow = (MainWindowStep)WorkFlowManager.GetStep("MainWindowStep");
            
            var a = openSimulatorViewModel.selectedItem.Split(" ");
            DataContext dataContext = new DataContext();
            SimulationRun mySimulationRun = dataContext.simulationRuns.Where(x => x.Id.ToString() == a[0]).FirstOrDefault();
            SimulationPrepareStep simulationPrepareStep = new SimulationPrepareStep(mySimulationRun);
            myMainWindow.SetView(simulationPrepareStep.GetScreenContent());
            //throw new NotImplementedException();
        }

        private void GoBack()
        {
            throw new NotImplementedException();
        }

        public override UserControl GetScreenContent()
        {
            throw new NotImplementedException();
        }
        public Window GetWindow()
        {
            return openSimulatorView;
        }
    }
}
