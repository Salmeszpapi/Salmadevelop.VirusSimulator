using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Sim_Web.Db;
using Sim_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace VirusSimulator_UI.ViewModels
{
    public class OpenSimulatorViewModel : ViewModelBase
    {
        public OpenSimulatorViewModel()
        {
            TransferToString();
        }

        private void TransferToString()
        {
            DataContext dataContext = new DataContext();
            var a = dataContext.simulationRuns.ToList();
            mysimulationRuns = new List<string>();
            foreach (var item in a)
            {
                mysimulationRuns.Add(item.Id + " " + item.VirusName);
            }
        }
        [Reactive]
        public List<string> mysimulationRuns { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> BackButtonClicked { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> YesButtonClicked { get; set; }
    }
}
