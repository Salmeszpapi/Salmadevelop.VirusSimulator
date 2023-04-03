using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using VirusSimulator_UI.Models;
using Sim_Web.Db;
using Sim_Web.Models;
using DynamicData;

namespace VirusSimulator_UI.ViewModels
{
    public class VirusCreatePopupViewModel : ViewModelBase
    {
        public event EventHandler PropertyChanged;
        public VirusCreatePopupViewModel()
        {
            GetVirusesFromDatabase();
        }

        private void GetVirusesFromDatabase()
        {
            Viruses = new List<String>();
            DataContext dataContext = new DataContext();
            Virusmodels = dataContext.VirusData.ToList();
            Viruses.Add("Default");
            foreach(var virusName in Virusmodels)
            {
                Viruses.Add(virusName.Name);
            }
        }

        [Reactive]
        public ReactiveCommand<Unit, Unit> CreateButton { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> BackButton { get; set; }
        public List<Virus> Virusmodels { get; set; }
        [Reactive]
        private List<String> Viruses { get; set; } 
        public string SelectedVirus { get; set; }   
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
        public string VirusName
        {
            get
            {
                return "";
            }
            set
            {
                if(value is not null)
                {
                    Simulator.VirusName = value;
                }
            }
        }

    }
}
