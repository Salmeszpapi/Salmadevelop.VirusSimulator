using Avalonia.Controls;
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
        private int localiteration =0;
        public ChartsViewModel()
        {
            
        }
        public void Test2(ChartsView chartsView)
        {

            var a = DateTime.Now;
            AvaPlot avaPlot1 = chartsView.Find<AvaPlot>("AvaPlot1");
            double[] dataX = new double[20];
            double[] dataY = new double[20];

            dataX[0] = 20;
            dataY[0] = 20;
            dataX[1] = 10;
            dataY[1] = 5;

            avaPlot1.Plot.AddScatter(dataX, dataY);
            avaPlot1.Refresh();
            Thread thread2 = new Thread(() =>
            {

                do
                {
                    if (Simulator.Iteration == localiteration)
                    {
                        dataX[localiteration] = localiteration;
                        dataY[localiteration] = Simulator.AllPeople;

                        avaPlot1.Plot.AddScatter(dataX, dataY);
                        avaPlot1.Refresh();
                        localiteration++;
                    }
                    
                } while (true);
                thread2.IsBackground = true;
                thread2.Start();
                Trace.WriteLine("Salmi");
            });

        }
    }
}
