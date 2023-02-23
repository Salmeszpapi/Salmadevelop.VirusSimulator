using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            Thread simulationThread = new Thread(() => { simulation(rectanglePointer); });
            
        }
        private void simulation(List<RectanglePointer> rectanglePointer)
        {
            startingSimulatoinTime = DateTime.Now;
            Graph graph = new Graph(rectanglePointer);
            graph.GoThroughtNodes(ThroughNodeActionEnum.FirstInfect);
            Console.WriteLine("stop");
            do
            {
                graph.GoThroughtNodes(ThroughNodeActionEnum.Moove);
                Thread.Sleep(2000);
                graph.GoThroughtNodes(ThroughNodeActionEnum.Infect);
            } while (true);
        }
    }
}
