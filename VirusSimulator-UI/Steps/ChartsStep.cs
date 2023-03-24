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
    internal class ChartsStep : BaseStep
    {
        private ChartsViewModel ChartsViewModel;
        private ChartsView ChartsView;
        public ChartsStep()
        {
            ChartsViewModel = new ChartsViewModel();
            ChartsView = new ChartsView() { DataContext = ChartsViewModel };
            ChartsViewModel.Test2Async(ChartsView);
            WorkFlowManager.SaveStep(this);
        }

        public override UserControl GetScreenContent()
        {
            return ChartsView;
        }
    }
}
