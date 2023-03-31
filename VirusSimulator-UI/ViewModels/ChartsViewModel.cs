using Avalonia.Controls;
using ReactiveUI.Fody.Helpers;
using ScottPlot.Avalonia;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirusSimulator_UI.Models;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI.ViewModels
{
    public class ChartsViewModel : ViewModelBase
    {
        [Reactive]
        public double[] dataX { get; set; }
        [Reactive]
        public double[] dataY { get; set; }
        [Reactive]
        public AvaPlot avaPlot1 { get; set; }
        public ChartsViewModel()
        {
            
        }
        public async Task DoStuff(ChartsView chartsView)
        {

        }

        private void TestChart()
        {
            
        }
    }
}
