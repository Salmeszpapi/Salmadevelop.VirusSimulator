using Avalonia.Controls;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmds.DBus;
using VirusSimulator_UI.Models;
using VirusSimulator_UI.ViewModels;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI.Steps
{
    public class VirusCreatePopupStep : BaseStep
    {
        private VirusCreatePopupView virusCreatePopupView;
        private VirusCreatePopupViewModel virusCreatePopupViewModel;
        private SimulationPrepareView simulationPrapareView;

        private bool IsRandomArrived;
        private NewWindowType newWindowType;
        private string node;
        private string min;
        private string max;

        public VirusCreatePopupStep()
        {
            virusCreatePopupViewModel= new VirusCreatePopupViewModel();
            virusCreatePopupView= new VirusCreatePopupView() {DataContext = virusCreatePopupViewModel };

            virusCreatePopupViewModel.CreateButton = ReactiveCommand.Create(CreateButtonClicked);
            virusCreatePopupViewModel.BackButton = ReactiveCommand.Create(BackButtonClicked);
        }
        public VirusCreatePopupStep(NewWindowType newWindowType, string node,string min,string max)
        {
            virusCreatePopupViewModel = new VirusCreatePopupViewModel();
            virusCreatePopupView = new VirusCreatePopupView() { DataContext = virusCreatePopupViewModel };

            virusCreatePopupViewModel.CreateButton = ReactiveCommand.Create(CreateButtonClicked);
            virusCreatePopupViewModel.BackButton = ReactiveCommand.Create(BackButtonClicked);

            IsRandomArrived = true;
            this.node = node;
            this.min = min;
            this.max = max;
            this.newWindowType= newWindowType;


        }
        public override UserControl GetScreenContent()
        {
            throw new NotImplementedException();
        }
        public Window GetView()
        {
            return virusCreatePopupView;
        }
        private void CreateButtonClicked()
        {
            Simulator.IsSimulatiorLoaded = false;
            if (virusCreatePopupViewModel.VirusTypeSpecial)
            {
                Simulator.InfectionChance = virusCreatePopupViewModel.InfectionChanceSlider / 100.0;
                Simulator.PROPABILITYTOBEDEAD = virusCreatePopupViewModel.ChanceToDeadSlider / 100.0;
                Simulator.PROPABILITYTOCURE = virusCreatePopupViewModel.ChanceToCureSlider / 100.0;
                Simulator.MaxIterationCount = virusCreatePopupViewModel.IncubationPeriodSlider;
                virusCreatePopupView.Hide();

            }// here we are restoring default values of simulator 
            else
            {
                var myVirus = virusCreatePopupViewModel.SelectedVirus;
                if(myVirus == "Default" || string.IsNullOrEmpty(myVirus))
                {
                    Simulator.InfectionChance = 0.06;
                    Simulator.MaxIterationCount = 13;
                    Simulator.PROPABILITYTOBEDEAD = 0.25;
                    Simulator.PROPABILITYTOCURE = 0.3;
                    Simulator.VirusName = "Default";
                }
                else
                {
                    var myTypeVirusObject = virusCreatePopupViewModel.Virusmodels.Where(x => x.Name == myVirus).FirstOrDefault();

                    Simulator.InfectionChance = myTypeVirusObject.InfectionSeverity;
                    Simulator.MaxIterationCount = (int)myTypeVirusObject.IncubationTime;
                    Simulator.PROPABILITYTOBEDEAD = myTypeVirusObject.ProbabilityToDead;
                    Simulator.PROPABILITYTOCURE = myTypeVirusObject.ProbabilityToCure;
                    Simulator.VirusName = myTypeVirusObject.Name;
                }


            }


            if (IsRandomArrived)
            {
                MainWindowStep mainWindow = (MainWindowStep)WorkFlowManager.GetStep("MainWindowStep");
                var prepareView = new SimulationPrepareStep(newWindowType, node, min, max).GetScreenContent();
                //simulationPrapareView = new SimulationPrepareView(newWindowType, node, min, max) { DataContext = simulationPrapareView };
                mainWindow.SetView(prepareView);
                virusCreatePopupView.Hide();
            }
            else
            {
                MainWindowStep mainWindow = (MainWindowStep)WorkFlowManager.GetStep("MainWindowStep");
                var prepareView = new SimulationPrepareStep().GetScreenContent();
                mainWindow.SetView(prepareView);
                virusCreatePopupView.Hide();
            }

        }
        private void BackButtonClicked()
        {
            virusCreatePopupView.Hide();
        }
    }
}
