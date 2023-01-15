﻿#region Header

#endregion
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
        private readonly List<int> visitedNodes = new();
        private List<int> leafNodes = new();
        Queue<int> myStack2 = new();
        private List<People> peoplesList= new();
        private List<Place> nodelist = new();
        //Stack<int> myStack = new Stack<int>();
        public Graph(int nodeCount)
        {
            nodes = nodeCount;

            for(int i=0; i<nodeCount; i++)
            {
                Place node = new Place();
                node.ID = i;

                //ez nem kell most
                node.AdjencyNodes = new List<int>();

                nodelist.Add(node);
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
                nodelist[edge1].AdjencyNodes.Add(edge2);
                nodelist[edge2].AdjencyNodes.Add(edge1);
            }  
        }
        public void BFS2(int node = 0, int infectedPercent = 2)
        {
            //For be able to generate random graph, probably I should start with 0
            // I going to assign 0 -> new friend/s then increment 1 -> new friends
            // If I follow this logic then it may be possible to generate correctly.
            if (nodelist[node].AdjencyNodes.Count > 0)
            {
                if (!visitedNodes.Contains(node))
                {
                    foreach (var nod in nodelist[node].AdjencyNodes)
                    {
                        if (visitedNodes.Contains(nod))
                        {
                            if (nodelist[node].AdjencyNodes.Count <= 1)
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
                    for(int i=0; i<10; i++)
                    {
                        People people = new People(peoplesList.Count);
                        peoplesList.Add(people);
                    }
                    
                    //Console.WriteLine($"Ez it teszt{node}");
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
                if (nodelist[i].AdjencyNodes.Count>0)
                {
                    foreach (var node in nodelist[i].AdjencyNodes)
                    {
                        Console.Write(nodelist[i].ID + "->" + node + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
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
