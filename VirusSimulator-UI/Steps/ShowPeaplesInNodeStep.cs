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
    public class ShowPeaplesInNodeStep : BaseStep
    {
        private ShowPeaplesInNodeViewModel myShowPeaplesInNodeViewModel;
        private ShowPeaplesInNodeView myShowPeaplesInNodeView;

        public ShowPeaplesInNodeStep(RectanglePointer rectanglePointer)
        {
            myShowPeaplesInNodeViewModel = new ShowPeaplesInNodeViewModel(rectanglePointer);
            myShowPeaplesInNodeView = new ShowPeaplesInNodeView() { DataContext = myShowPeaplesInNodeViewModel };
            WorkFlowManager.SaveStep(this);
        }

        public override UserControl GetScreenContent()
        {
            throw new NotImplementedException();
        }
        public Window GetView()
        {
            return myShowPeaplesInNodeView;
        }
    }
}
