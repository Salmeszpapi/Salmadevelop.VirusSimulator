using Simulation.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulation.Graph
{
    public class Graph
    {
        private int nodes;
        private List<Int32>[] adjency;
        private readonly List<int> visitedNodes = new();
        private List<int> leafNodes = new();
        Queue<int> myStack2 = new();
        private List<People> peoplesList= new();
        //Stack<int> myStack = new Stack<int>();
        public Graph(int nodeCount)
        {
            
            nodes = nodeCount;
            adjency = new List<int>[nodeCount];
            for(int i=0; i<nodeCount; i++)
            {
                People people = new People();
                
                adjency[i] = new List<int>();
                people.FriendsList = new List<int>();
                people.FriendsList.Add(AddEdge(i,5));
                peoplesList.Add(people);
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
                adjency[edge2].Add(edge1);
            }  
        }
        public void BFS(int node=0,int infectedPercent=2)
        {
            if (adjency[node].Count > 0)
            {
                if (!visitedNodes.Contains(node))
                {
                    foreach (var nod in adjency[node])
                    {
                        if (visitedNodes.Contains(nod))
                        {
                            if(adjency[node].Count == 1)
                            {
                                //here is our leafe
                                Console.WriteLine("level= "+ node);
                                //here node has no more childrens 
                                //these objects-peaple will infects as first randomly
                            }
                        }
                        else
                        {
                            //here we can check the parent of the node of node is infected then
                            //we can pass the virus to his parent 
                            if (!myStack2.Contains(nod))
                            {
                                myStack2.Enqueue(nod);
                            }
                            leafNodes.Add(nod);
                            Console.WriteLine(node + "->" + nod);
                        }
                    }
                    visitedNodes.Add(node);
                }
            }
            else
            {
                Console.WriteLine(node + "-> None");
            }
            if (myStack2.Count > 0)
            {
                BFS(myStack2.Dequeue());
            }
        }
        //public void DepthSearching2(int node=0)
        //{
        //    visitedNodes.Add(node);
        //    if (adjency[node].Count > 0)
        //    {
        //        foreach (var nod in adjency[node])
        //        {
        //            if (visitedNodes.Contains(nod))
        //            {
        //                check all linked elements if all visited go back 
        //                foreach(var nod2 in adjency[node])
        //                {
        //                    if(adjency[nod2].Count > 0)
        //                    {
        //                        if (visitedNodes.Contains(nod2))
        //                        {
        //                        }
        //                        else
        //                        {
        //                            myStack.Push(nod2);

        //                            DepthSearching2(nod2);
        //                        }
        //                    }
        //                }
        //                if (myStack.Count > 0)
        //                {
        //                    DepthSearching2(myStack.Pop());
        //                }
        //            }
        //            else 
        //            {
        //            myStack.Push(node);
        //            DepthSearching2(nod);
        //                break;
        //            }
        //            Console.WriteLine(nod);
        //        }
        //        if(myStack.Count > 0) DepthSearching2(myStack.Pop());
        //    }
        //    else
        //    {

        //    }
        //}
        //int counter = 0;

    }
}
