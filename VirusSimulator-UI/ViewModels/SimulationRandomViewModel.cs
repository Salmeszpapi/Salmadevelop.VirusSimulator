using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace VirusSimulator_UI.ViewModels
{
    public class SimulationRandomViewModel : ViewModelBase
    {
        public SimulationRandomViewModel()
        {

        }
        [Reactive]
        public ReactiveCommand<Unit, Unit> BackButtonClicked { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> ApproveButtonClicked { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> RandomButtonClicked { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> RandomizeButton { get; set; }
        [Reactive]
        public string Nodes { get; set; }
        [Reactive]
        public string MinConnections { get; set; }
        [Reactive]
        public string MaxConnections { get; set; }

    }
}
