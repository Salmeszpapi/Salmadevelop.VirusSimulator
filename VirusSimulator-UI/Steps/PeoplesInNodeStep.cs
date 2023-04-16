using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusSimulator_UI.Models;
using VirusSimulator_UI.ViewModels;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI.Steps
{
    
    internal class PeoplesInNodeStep : BaseStep
    {
        private PeoplesInNodeViewModel peoplesInNodeViewModel;
        private PeoplesInNodeView peoplesInNodeView;
        public PeoplesInNodeStep(RectanglePointer myRectanglePointer)
        {
            peoplesInNodeViewModel= new PeoplesInNodeViewModel(myRectanglePointer);
            peoplesInNodeView= new PeoplesInNodeView() {DataContext = peoplesInNodeViewModel };
            WorkFlowManager.SaveStep(this);
        }

        public override UserControl GetScreenContent()
        {
            return peoplesInNodeView;
        }
        public void UpdateData(RectanglePointer rectanglePointer)
        {
            //peoplesInNodeViewModel.UpdateData(rectanglePointer);
        }

    }
}
