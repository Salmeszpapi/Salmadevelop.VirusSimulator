using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public async Task IterateThroughtRectangles()
        {
            //var AllPeople = 0;
            //var AllHealthypeaples = 0;
            //var AllInfectedPeoples = 0;
            //var AllDeadPeoples = 0;
            //foreach(var rectangle in rectanglePointers)
            //{
            //    AllPeople += rectangle.PeoplesCount;
            //    AllHealthypeaples += rectangle.HealthyCount;
            //    AllInfectedPeoples += rectangle.InfectedCount;
            //    AllDeadPeoples += rectangle.DeadCount;
            //}
            //Simulator.PassNewData(AllPeople, AllHealthypeaples, AllInfectedPeoples, AllDeadPeoples);
            //foreach (var rectangle in rectanglePointers)
            //{
            //    IterateThroughtPersonsInfect(rectangle);
            //    IterateThroughtPersonsMove(rectangle);
            //}
        }

        private void IterateThroughtPersonsInfect(RectanglePointer rectanglePointer)
        {
            var mycounter = 0;
            if (rectanglePointer.HasInfectedPerson())
            {
                for (int i = 0; i < rectanglePointer.persons.Count; i++)
                {
                    var person = rectanglePointer.persons[i];
                    if (person is not null && !person.Dead)
                    {
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
                            var random = new Random().NextDouble();
                            if (Simulator.PROPABILITYTOBEDEAD >= new Random().NextDouble())
                            {
                                rectanglePointer.DeadCount++;
                                //rectanglePointer.persons.Remove(person);
                                person.Dead = true;
                            }
                            else if (Simulator.PROPABILITYTOCURE >= random)
                            {
                                mycounter++;
                                rectanglePointer.InfectedCount--;
                                person.Infected = false;
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
        }
        private void IterateThroughtPersonsMove(RectanglePointer rectanglePointer)
        {
            List<Person> myPersonList = new List<Person>();

            for (int i = 0; i < rectanglePointer.persons.Count; i++)
            {
                var persons = rectanglePointer.persons[i];
                if (rectanglePointer.neighbours.Count > 0 && !persons.Dead)
                {
                    var chanceToMove = 1 / Convert.ToDouble(rectanglePointer.neighbours.Count);

                    if (new Random().NextDouble() <= chanceToMove)
                    {
                        
                        var myRandomNumber = new Random().Next(rectanglePointer.neighbours.Count);
                        rectanglePointer.neighbours[myRandomNumber].persons.Add(persons);
                        myPersonList.Add(persons);
                    }
                }
            }
            foreach (var person in myPersonList)
            {
                rectanglePointer.persons.Remove(person);
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
    }
}
