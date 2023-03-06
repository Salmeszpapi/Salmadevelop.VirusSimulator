using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusSimulator_UI.ViewModels
{
    public class SimulationPrepareViewModel
    {
        public string Mydata { get; set; }
        public string ImagePath{ get; set; }
        public SimulationPrepareViewModel()
        {
            ImagePath = @"C:\Diploma\ApplicationCore\VirusSimulator-UI\Assets\cat.jpg";
        }
    }
}
