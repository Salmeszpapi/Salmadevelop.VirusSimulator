using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Graph
{
    public class Graph
    {
        
        private int nodes;
        private List<Int32>[] adjency;
        private List<int> visitedNodes = new List<int>();
        private int save = 0;
        private int saveIteration = 0;
        public Graph(int nodeCount)
        {
            nodes = nodeCount;
            adjency = new List<int>[nodeCount];
            for(int i=0; i<nodeCount; i++)
            {
                adjency[i] = new List<int>();
            }
        }
        public void AddEdge(int edge1,int edge2)
        {
            if(edge1 >= nodes || edge2 >= nodes)
            {
                SystemException.ReferenceEquals(this, edge2);
            }
            else
            {
                adjency[edge1].Add(edge2);
            }  
        }
        public void DepthSearching(int node)
        {
            for (int i = 0; i < adjency[node].Count; i++)
            {
                visitedNodes.Add(node);
                if (adjency[node].Count > 0)
                {
                    foreach (var nod in adjency[node])
                    {
                        if (visitedNodes.Contains(nod))
                        {

                        }
                        else
                        {
                            visitedNodes.Add(nod);
                            save = nod;
                            Console.WriteLine(nod);
                            DepthSearching(nod);
                        }
                    }
                    //here we got to the last leaf element
                }
                else
                {

                    //its the last element-> check it with visiet and go back 
                }
            }          
        }
    }
}
