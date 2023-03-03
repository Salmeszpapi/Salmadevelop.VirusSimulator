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
    public  class SimulationStep
    {
        SimulationViewModel mySimulationViewModel;
        SimulationView simulationView;
        public SimulationStep()
        {
            mySimulationViewModel = new SimulationViewModel();
            simulationView = new SimulationView() { DataContext = mySimulationViewModel };
        }

        public UserControl GetScreenContent()
        {
            return simulationView;
        }
    }
}
