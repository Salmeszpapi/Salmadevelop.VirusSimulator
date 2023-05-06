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
        readonly ScottPlot.Plottable.SignalPlot SignalPlot5;
        readonly ScottPlot.Plottable.SignalPlot SignalPlot6;
        readonly double[] Values = new double[100_000];
        readonly double[] Values2 = new double[100_000];
        readonly double[] Values3 = new double[100_000];
        readonly double[] Values4 = new double[100_000];
        readonly double[] Values5 = new double[100_000];
        readonly double[] Values6 = new double[100_000];
        //readonly List<double> Values = new List<double>();
        int NextPointIndex = Simulator.Iteration+1;
        DispatcherTimer LiveTime3;
        public ChartsView()
        {
            InitializeComponent();

            AvaPlot1 = this.FindControl<AvaPlot> ("AvaPlot1");
            AvaPlot1.Reset();

            SignalPlot = AvaPlot1.Plot.AddSignal(Values);
            SignalPlot2 = AvaPlot1.Plot.AddSignal(Values2);
            SignalPlot3 = AvaPlot1.Plot.AddSignal(Values3);
            SignalPlot4 = AvaPlot1.Plot.AddSignal(Values4);
            SignalPlot5 = AvaPlot1.Plot.AddSignal(Values5);
            SignalPlot6 = AvaPlot1.Plot.AddSignal(Values6);
            SignalPlot.Color = Color.Red;
            SignalPlot2.Color = Color.Green;
            SignalPlot3.Color = Color.Black;
            SignalPlot4.Color = Color.Blue;
            SignalPlot5.Color = Color.Brown;
            SignalPlot6.Color = Color.Pink;
            AvaPlot1.Plot.SetAxisLimits(0, 100, 0, Simulator.AllPeople);
            AvaPlot1.Plot.XLabel("Time");
            AvaPlot1.Plot.YLabel("Persons");
            SignalPlot.Label = "Infected";
            SignalPlot2.Label = "Healthy";
            SignalPlot3.Label = "Dead";
            SignalPlot4.Label = "All";
            SignalPlot5.Label = "Old infected";
            SignalPlot6.Label = "Young infected";
            Values[0] = (Convert.ToDouble(Simulator.AllInfectedPeoples));
            Values2[0] = (Convert.ToDouble(Simulator.AllHealthyPeoples));
            Values3[0] = (Convert.ToDouble(Simulator.AllDeadPeoples));
            Values4[0] = Convert.ToDouble(Simulator.AllPeople - Simulator.AllDeadPeoples);
            Values5[0] = (Convert.ToDouble(Simulator.AllOldPersonsInfected));
            Values6[0] = Convert.ToDouble(Simulator.AllYoungInfected);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            LiveTime3 = new DispatcherTimer();
            LiveTime3.Interval = TimeSpan.FromSeconds(1);
            LiveTime3.Tick += NewTest123;
            LiveTime3.Start();
            AvaPlot1 = this.FindControl<AvaPlot>("AvaPlot1");
            AvaPlot1.Render();
        }

        private void NewTest123(object sender, EventArgs e)
        {
            if(Simulator.RunningSimulation)
            {
                Values[NextPointIndex] = (Convert.ToDouble(Simulator.AllInfectedPeoples));
                Values2[NextPointIndex] = (Convert.ToDouble(Simulator.AllHealthyPeoples));
                Values3[NextPointIndex] = (Convert.ToDouble(Simulator.AllDeadPeoples));
                Values4[NextPointIndex] = Convert.ToDouble(Simulator.AllPeople - Simulator.AllDeadPeoples);
                Values5[NextPointIndex] = (Convert.ToDouble(Simulator.AllOldPersonsInfected));
                Values6[NextPointIndex] = Convert.ToDouble(Simulator.AllYoungInfected);
                SignalPlot.MaxRenderIndex = NextPointIndex;
                SignalPlot2.MaxRenderIndex = NextPointIndex;
                SignalPlot3.MaxRenderIndex = NextPointIndex;
                SignalPlot4.MaxRenderIndex = NextPointIndex;
                SignalPlot5.MaxRenderIndex = NextPointIndex;
                SignalPlot6.MaxRenderIndex = NextPointIndex;

                AvaPlot1.Plot.Legend(location: ScottPlot.Alignment.UpperRight);

                NextPointIndex += 1;

                double currentRightEdge = AvaPlot1.Plot.GetAxisLimits().XMax;
                if (NextPointIndex > currentRightEdge)
                    AvaPlot1.Plot.SetAxisLimits(xMax: currentRightEdge + 30);
                AvaPlot1.Render();
            }
        }
    }
}
