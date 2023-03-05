using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusSimulator_UI.ViewModels;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI.Steps
{
    public class SimulationPrepareStep : BaseStep
    {
        private SimulationPrepareView simulationPrapareView;
        private SimulationPrepareViewModel simulationPrepareViewModel;
        public SimulationPrepareStep()
        {
            simulationPrepareViewModel = new SimulationPrepareViewModel();
            simulationPrapareView = new SimulationPrepareView() { DataContext = simulationPrepareViewModel };
        }

        public override UserControl GetScreenContent()
        {
            return simulationPrapareView;
        }
    }
}
