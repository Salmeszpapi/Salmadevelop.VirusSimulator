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
    public class PopupWindowExitSimulationViewModel : ViewModelBase
    {

        public PopupWindowExitSimulationViewModel()
        {

        }

        [Reactive]
        public ReactiveCommand<Unit, Unit> BackButtonClicked { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> YesButtonClicked { get; set; }
    }
}
