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
                graph.IterateThroughtRectangles(ThroughNodeActionEnum.FirstInfect);
                Console.WriteLine("stop");
                do
                {
                    graph.IterateThroughtRectangles(ThroughNodeActionEnum.Move);
                    Thread.Sleep(1000);
                    graph.IterateThroughtRectangles(ThroughNodeActionEnum.Infect);
                } while (true);
            });
            thread.IsBackground = true;
            thread.Start();
            Trace.WriteLine("Salmi");
        }
        public static bool RunningSimulation { get; set; }
    }
}
