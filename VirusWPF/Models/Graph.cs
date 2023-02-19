using Simulation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VirusWPF.Models
{
    internal class Graph
    {
        public int Nodes { get; set; }
        public List<Node> nodesObjects = new List<Node>();
        public Graph(List<RectanglePointer> rectanglePointer)
        {
            Nodes= rectanglePointer.Count;
            createNodes(rectanglePointer);
        }

        private void createNodes(List<RectanglePointer> rectanglePointer)
        {
            foreach (var rectanglePoint in rectanglePointer)
            {
                Node node = new Node(rectanglePoint);
                nodesObjects.Add(node);
            }
        }

        public void GoThroughtNodes(ThroughNodeActionEnum throughNodeActionEnum)
        {
            //For be able to generate random graph, probably I should start with 0
            // I going to assign 0 -> new friend/s then increment 1 -> new friends
            // If I follow this logic then it may be possible to generate correctly.
            List<Node> visitedNodes = new List<Node>();

            foreach(var node in nodesObjects)
            {
                if (node.neighbourNodes.Count > 0)
                {
                    visitedNodes.Add(node);
                    Console.WriteLine(node.neighbourNodes);
                }
            }
            foreach(var visited in visitedNodes)
            {

            }
            
        }

    }
}
