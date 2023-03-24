using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using ScottPlot;
using ScottPlot.Avalonia;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using VirusSimulator_UI.Models;

namespace VirusSimulator_UI.Views
{
    public partial class ChartsView : UserControl
    {
        readonly Stopwatch Stopwatch = Stopwatch.StartNew();
        readonly ScottPlot.Plottable.SignalPlot SignalPlot;
        readonly ScottPlot.Plottable.SignalPlot SignalPlot2;
        readonly ScottPlot.Plottable.SignalPlot SignalPlot3;
        readonly ScottPlot.Plottable.SignalPlot SignalPlot4;
        readonly double[] Values = new double[100_000];
        readonly double[] Values2 = new double[100_000];
        readonly double[] Values3 = new double[100_000];
        readonly double[] Values4 = new double[100_000];
        //readonly List<double> Values = new List<double>();
        int NextPointIndex = Simulator.Iteration;
        DispatcherTimer LiveTime3;
        public ChartsView()
        {
            InitializeComponent();
            AvaPlot1 = this.FindControl<AvaPlot> ("AvaPlot1");
            SignalPlot = AvaPlot1.Plot.AddSignal(Values);
            SignalPlot2 = AvaPlot1.Plot.AddSignal(Values2);
            SignalPlot3 = AvaPlot1.Plot.AddSignal(Values3);
            SignalPlot4 = AvaPlot1.Plot.AddSignal(Values4);
            SignalPlot.Color = Color.Red;
            SignalPlot2.Color = Color.Green;
            SignalPlot3.Color = Color.Black;
            SignalPlot4.Color = Color.Blue;
            AvaPlot1.Plot.SetAxisLimits(0, 100, 0, Simulator.AllPeople);
            AvaPlot1.Plot.XLabel("Time");
            AvaPlot1.Plot.YLabel("Persons");
            //AvaPlot1.Plot.AddScatter(DataGen.Consecutive(51), DataGen.Consecutive(51), label: "sin");
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            LiveTime3 = new DispatcherTimer();
            LiveTime3.Interval = TimeSpan.FromMilliseconds(10);
            LiveTime3.Tick += newTest123;
            LiveTime3.Start();
        }
        private void Kiki2(object sender, EventArgs e)
        {
            if (Values[-1] != Simulator.AllInfectedPeoples)
            {
                
            }
        }
        private void newTest123(object sender, EventArgs e)
        {
            if(Simulator.RunningSimulation)
            {
                Values[NextPointIndex] = (Convert.ToDouble(Simulator.AllInfectedPeoples));
                Values2[NextPointIndex] = (Convert.ToDouble(Simulator.AllHealthyPeoples));
                Values3[NextPointIndex] = (Convert.ToDouble(Simulator.AllDeadPeoples));
                Values4[NextPointIndex] = Convert.ToDouble(Simulator.AllPeople - Simulator.AllDeadPeoples);
                SignalPlot.MaxRenderIndex = NextPointIndex;
                SignalPlot2.MaxRenderIndex = NextPointIndex;
                SignalPlot3.MaxRenderIndex = NextPointIndex;
                SignalPlot4.MaxRenderIndex = NextPointIndex;

                NextPointIndex += 1;

                double currentRightEdge = AvaPlot1.Plot.GetAxisLimits().XMax;
                if (NextPointIndex > currentRightEdge)
                    AvaPlot1.Plot.SetAxisLimits(xMax: currentRightEdge + 100);
                AvaPlot1.Render();
            }
        }
    }
}
