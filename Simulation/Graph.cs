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
                people.ID = i;
                adjency[i] = new List<int>();
                people.FriendsList = new List<int>();
                people.Friends = new Random().Next(7); 
                peoplesList.Add(people);
                //for(int j=0; people.Friends > j ; j++)
                //{
                //    int randomSzam = new Random().Next(i);
                //    AddEdge(i, randomSzam);
                //    AddEdge(randomSzam, i);
                //}
            }
            AddEdge(0, 2);
            AddEdge(0, 3);
            AddEdge(0, 4);
            AddEdge(1, 3);
            AddEdge(2, 4);
            AddEdge(2, 5);
            AddEdge(3, 7);
            AddEdge(7, 20);
            AddEdge(7, 21);
            AddEdge(21, 22);
            AddEdge(4, 8);

            //RemovePeopleWithNoFriends();
        }
        public void AddEdge(int edge1,int edge2)
        {
            if(edge1 >= nodes || edge2 >= nodes)
            {
                SystemException.ReferenceEquals(this, edge2);
            }
            else
            {
                peoplesList[edge1].FriendsList.Add(edge2);
                peoplesList[edge2].FriendsList.Add(edge1);

            }  
        }
        public void AddEdge2(int edge1, int edge2)
        {
            if (edge1 >= nodes || edge2 >= nodes)
            {
                SystemException.ReferenceEquals(this, edge2);
            }
            else
            {
                peoplesList[edge1].FriendsList.Add(edge2);
                peoplesList[edge2].FriendsList.Add(edge1);
                //adjency[edge2].Add(edge1);
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
        public void BFS2(int node = 0, int infectedPercent = 2)
        {
            //For be able to generate random graph, probably I should start with 0
            // I going to assign 0 -> new friend/s then increment 1 -> new friends
            // If I follow this logic then it may be possible to generate correctly.
            if (peoplesList[node].FriendsList.Count > 0)
            {
                if (!visitedNodes.Contains(node))
                {
                    foreach (var nod in peoplesList[node].FriendsList)
                    {
                        if (visitedNodes.Contains(nod))
                        {
                            if (peoplesList[node].FriendsList.Count <= 1)
                            {
                                //here is our leafe
                                Console.WriteLine("level= " + node);
                                //here node has no more childrens 
                                //these objects-peaple will infects as first randomly
                            }
                        }
                        else
                        {
                            //here we can check the parent of the node of node is infected then
                            //we can pass the virus to his parent 


                            //End of checking 
                            if (!myStack2.Contains(nod))
                            {
                                myStack2.Enqueue(nod);
                            }
                            leafNodes.Add(nod);
                            Console.WriteLine(node + "->" + nod);
                        }
                    }
                    //here we will visit only once the Nodes / People
                    int randomlyInfectedAtFirstTime = new Random().Next(100);
                    peoplesList[node].Infecter = randomlyInfectedAtFirstTime > 18; //18 is the border if the person catch the virus
                    peoplesList[node].Infecter= true;
                    Console.WriteLine($"Ez it teszt{node}");
                    visitedNodes.Add(node);
                }
            }else
            {
                Console.WriteLine($"The {node} node has no firends ");
            }
            if (myStack2.Count > 0)
            {
                BFS2(myStack2.Dequeue());
            }
        }
        public void BFS3()
        {
            for(int i = 0; i < nodes; i++)
            {
                if (peoplesList[i].FriendsList.Count>0)
                {
                    foreach (var node in peoplesList[i].FriendsList)
                    {
                        Console.Write(peoplesList[i].ID + "->" + node + " ");
                    }
                    Console.WriteLine();
                }
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
        private void RemovePeopleWithNoFriends()
        {
            foreach(var node in peoplesList)
            {
                if(node.FriendsList.Count == 0)
                {
                    peoplesList.Remove(node);
                }
            }
        }
    }
}
