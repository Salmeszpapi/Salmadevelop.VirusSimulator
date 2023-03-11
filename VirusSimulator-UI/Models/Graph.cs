using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VirusSimulator_UI.Models
{
    internal class Graph
    {
        public int Nodes { get; set; }
        public List<Node> nodesObjects = new List<Node>();
        List<int> visitedNodes = new List<int>();
        Queue<int> myStack = new();
        private List<RectanglePointer> rectanglePointers= new List<RectanglePointer>();
        public Graph(List<RectanglePointer> rectanglePointers)
        {
            Nodes= rectanglePointers.Count;
            createNodes(rectanglePointers);
            this.rectanglePointers = rectanglePointers;
        }

        private void createNodes(List<RectanglePointer> rectanglePointer)
        {
            foreach (var rectanglePoint in rectanglePointer)
            {
                Node node = new Node(rectanglePoint);
                nodesObjects.Add(node);
            }
        }

        public void GoThroughtNodes(ThroughNodeActionEnum throughNodeActionEnum, int node = 0)
        {
            if (nodesObjects[node].neighbours.Count > 0)
            {
                if (!visitedNodes.Contains(node))
                {
                    foreach (var nod in nodesObjects[node].neighbourNodes)
                    {
                        if (visitedNodes.Contains(nod.Id))
                        {
                            if (nodesObjects[node].neighbours.Count <= 1)
                            {
                                //here is our leafe
                                Console.WriteLine("level= " + node);
                                //here node has no more childrens 
                                //these objects-peaple will infects as first randomly
                            }
                        }
                        else
                        {
                            //End of checking 
                            if (!myStack.Contains(nod.Id))
                            {
                                myStack.Enqueue(nod.Id);
                            }
                            Console.WriteLine(node + "->" + nod);
                        }
                    }
                    //
                    visitedNodes.Add(node);
                }
            }
            else
            {
                Console.WriteLine($"The {node} node has no firends ");
            }
            if (myStack.Count > 0)
            {
                GoThroughtNodes(ThroughNodeActionEnum.None, myStack.Dequeue());
            }

        }
        public void IterateThroughtRectangles(ThroughNodeActionEnum throughNodeActionEnum)
        {
            foreach(var rectangle in rectanglePointers)
            {
                switch (throughNodeActionEnum)
                {
                    case ThroughNodeActionEnum.FirstInfect:
                        rectangle.persons[0].Infected = true;
                        break;
                    case ThroughNodeActionEnum.Infect:
                        IterateThroughtPersonsInfect(rectangle, throughNodeActionEnum);
                        break;
                    case ThroughNodeActionEnum.Move:
                        IterateThroughtPersonsMove(rectangle, throughNodeActionEnum);
                        break;
                    case ThroughNodeActionEnum.Heal:
                        IterateThroughtPersonsHeal(rectangle, throughNodeActionEnum);
                        break;
                }
                
            }
        }

        private void IterateThroughtPersonsInfect(RectanglePointer rectanglePointer,ThroughNodeActionEnum throughNodeActionEnum)
        {
            foreach (var person in rectanglePointer.persons)
            {
                if(new Random().Next(100) < 2)
                {
                    person.Infected = true;
                }
            }
        }
        private void IterateThroughtPersonsMove(RectanglePointer rectanglePointer, ThroughNodeActionEnum throughNodeActionEnum)
        {
            foreach (var person in rectanglePointer.persons)
            {

            }
        }
        private void IterateThroughtPersonsHeal(RectanglePointer rectanglePointer, ThroughNodeActionEnum throughNodeActionEnum)
        {
            foreach (var person in rectanglePointer.persons)
            {
                if (new Random().Next(100) < 30)
                {
                    person.Infected = false;
                }
            }
        }

    }
}
