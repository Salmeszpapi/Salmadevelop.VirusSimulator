using Avalonia.Controls;
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
    public class SimulationRandomStep 
    {
        private RandomPopupView simulationPrapareView;
        private SimulationRandomViewModel simulationPrepareViewModel;
        public SimulationRandomStep()
        {
            simulationPrepareViewModel = new SimulationRandomViewModel();
            simulationPrapareView = new RandomPopupView() { DataContext = simulationPrepareViewModel };
        }

        public Window GetWindow()
        {
            return simulationPrapareView;
        }
    }
}
