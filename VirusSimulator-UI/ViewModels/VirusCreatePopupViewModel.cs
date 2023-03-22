using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace VirusSimulator_UI.ViewModels
{
    public class VirusCreatePopupViewModel : ViewModelBase
    {
        public event EventHandler PropertyChanged;
        public VirusCreatePopupViewModel()
        {

        }
        [Reactive]
        public ReactiveCommand<Unit, Unit> CreateButton { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> BackButton { get; set; }
        private int probabilityToDead { get; set; }
        private int probabilityToInfect { get; set; }
        private int itarationDay { get; set; }
        private int Healthy { get; set; }
        public int InfectionChanceSlider { get; set; }
        public int ChanceToCureSlider { get; set; }
        public int ChanceToDeadSlider { get; set; }
        public int IncubationPeriodSlider { get; set; }
        [Reactive]
        public bool VirusTypeDefault { get; set; } = true;
        [Reactive]
        public bool VirusTypeSpecial { get; set; }

    }
}
