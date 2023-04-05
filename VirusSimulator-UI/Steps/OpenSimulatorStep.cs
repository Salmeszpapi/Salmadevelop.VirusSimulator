using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusSimulator_UI.ViewModels;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI.Steps
{
    public class OpenSimulatorStep : BaseStep
    {
        OpenSimulatorViewModel openSimulatorViewModel { get; set; }
        OpenSimulatorView openSimulatorView { get; set; }
        public OpenSimulatorStep()
        {
            openSimulatorViewModel = new OpenSimulatorViewModel();
            openSimulatorView = new OpenSimulatorView() { DataContext = openSimulatorViewModel};
            openSimulatorViewModel.BackButtonClicked = ReactiveCommand.Create(GoBack);
            openSimulatorViewModel.YesButtonClicked = ReactiveCommand.Create(OkButton);
            WorkFlowManager.SaveStep(this);
        }

        private void OkButton()
        {
            GetWindow().Close();
            //throw new NotImplementedException();
        }

        private void GoBack()
        {
            throw new NotImplementedException();
        }

        public override UserControl GetScreenContent()
        {
            throw new NotImplementedException();
        }
        public Window GetWindow()
        {
            return openSimulatorView;
        }
    }
}
