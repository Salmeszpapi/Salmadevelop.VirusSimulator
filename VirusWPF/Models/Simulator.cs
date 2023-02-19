using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            startingSimulatoinTime = DateTime.Now;
            Graph graph = new Graph(rectanglePointer);
            graph.GoThroughtNodes(ThroughNodeActionEnum.FirstInfect);
            do
            {

            }while(true);
        }
    }
}
