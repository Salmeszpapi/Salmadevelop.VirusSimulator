using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace VirusWPF.Models
{
    public class Simulator
    {
        DateTime startingSimulatoinTime;
        public Simulator(int node)
        {
            startingSimulatoinTime = DateTime.Now;
        }
        public Simulator(List<RectanglePointer>rectanglePointer)
        {
            Trace.WriteLine("text");
            Thread thread = new Thread(() =>
            {
                startingSimulatoinTime = DateTime.Now;
                Graph graph = new Graph(rectanglePointer);
                graph.GoThroughtNodes(ThroughNodeActionEnum.FirstInfect);
                Console.WriteLine("stop");
                do
                {
                    graph.GoThroughtNodes(ThroughNodeActionEnum.Move);
                    Thread.Sleep(2000);
                    graph.GoThroughtNodes(ThroughNodeActionEnum.Infect);
                } while (true);

            });
            thread.IsBackground = true;
            thread.Start();
            Trace.WriteLine("Salmi");
        }
    }
}
