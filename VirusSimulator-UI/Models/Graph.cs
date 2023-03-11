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
        public int AllPeaople { get; set; }
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
        public void IterateThroughtRectangles()
        {
            foreach(var rectangle in rectanglePointers)
            {
                IterateThroughtPersonsInfect(rectangle);
                //IterateThroughtPersonsMove(rectangle);
            }
        }

        private void IterateThroughtPersonsInfect(RectanglePointer rectanglePointer)
        {
            if (rectanglePointer.HasInfectedPerson())
            {
                for (int i = 0; i < rectanglePointer.persons.Count; i++)
                {
                    var person = rectanglePointer.persons[i];
                    if (!person.Infected && person.TimesInfected == 0)
                    {
                        TryInfect(person, Simulator.InfectionChance);
                    }
                    else if (!person.Infected && person.TimesInfected != 0)
                    {
                        TryInfect(person, Simulator.InfectionChance / person.TimesInfected);
                    }

                    if (person.Infected && Simulator.Iteration != 0 && (Simulator.Iteration % Simulator.MaxIterationCount == 0))
                    {
                        if (Simulator.PROPABILITYTOBEDEAD >= new Random().NextDouble())
                        {
                            rectanglePointer.DeadCount++;
                            rectanglePointer.persons.Remove(person);
                        }
                        else
                        {
                            person.Infected = false;
                        }
                    }
                }
            }
            
        }
        private void IterateThroughtPersonsMove(RectanglePointer rectanglePointer)
        {
            foreach (var person in rectanglePointer.persons)
            {

                //if (new Random().Next(100) < Simulator.InfectionChance)
                //{
                //    person.Infected = true;

                //}
                //if (person.Infected)
                //{
                //    if (person.InfectedDays > Simulator.MaxInfectedDaysSurvived)
                //    {
                //        //person going to hospital

                //        person.Dead = true;
                //    }
                //    if (person.Immunity > 8 && person.InfectedDays > Simulator.MaxInfectedDaysSurvived / 3 && person.InfectedDays < 8)
                //    {

                //        if (new Random().Next(100) > 30)
                //        {
                //            person.InfectedDays = 0;
                //            person.Infected = false;
                //        }
                //    }
                //    person.InfectedDays++;
                //}
            }
        }

        private void TryInfect(Person person, double infectionChance)
        {
            if (new Random().NextDouble() < infectionChance)
            {
                person.Infected = true;
                person.InfectedDays++;
                person.TimesInfected++;
            }
        }

        private void TryCureOrDie(Person person)
        {
            if (new Random().Next(100) < Simulator.InfectionChance)
            {
                person.Infected = true;
            }
        }

    }
}
