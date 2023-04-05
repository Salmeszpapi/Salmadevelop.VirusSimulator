using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusSimulator_UI.Interfaces;
using VirusSimulator_UI.ViewModels;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI.Steps
{
    internal class MainWindowStep : BaseStep, IBaseViewReturnal
    {
        private MainWindowViewModel mainWindowViewModel;
        private MainWindow mainWindow;
        public MainWindowStep()
        {
            mainWindowViewModel = new MainWindowViewModel();
            mainWindow = new MainWindow() { DataContext = mainWindowViewModel };
            WorkFlowManager.SaveStep(this);
        }
        public override UserControl GetScreenContent()
        {
            throw new NotImplementedException();
        }
        public Window GetScreenWindow() 
        {
            return mainWindow;
        }
        public void SetView(UserControl userControl)
        {
            mainWindowViewModel.ChangableViews = userControl;
        }

        public void SetViewForPeople(UserControl userControl)
        {
            mainWindowViewModel.MyPointedDatasView = userControl;
        }
    }
}
