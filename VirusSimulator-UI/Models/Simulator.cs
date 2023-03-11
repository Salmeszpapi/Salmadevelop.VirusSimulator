using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace VirusSimulator_UI.Models
{
    public static class Simulator
    {
        public static bool RunningSimulation { get; set; }
        public static SimulatorStateEnum SimulatorState { get; set; }
        public static int MaxIterationCount { get; set; } = 10;
        public static double InfectionChance { get; set; } = 0.02;
        public static int Iteration { get; set; }
        public const double PROPABILITYTOBEDEAD = 0.3;
        public static void StartSimulation()
        {

        }

        public static void StopSimulation()
        {

        }

        public static void StartSimulation(List<RectanglePointer> rectanglePointer)
        {
            Trace.WriteLine("text");
            Thread thread = new Thread(() =>
            {
                Graph graph = new Graph(rectanglePointer);
                //graph.GoThroughtNodes(ThroughNodeActionEnum.FirstInfect);
                Console.WriteLine("stop");
                do
                {
                    graph.IterateThroughtRectangles();
                    Thread.Sleep(1000);
                } while (true);
            });
            thread.IsBackground = true;
            thread.Start();
            Trace.WriteLine("Salmi");
        }

    }
}
