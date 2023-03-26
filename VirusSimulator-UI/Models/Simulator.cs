using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace VirusSimulator_UI.Models
{
    public static class Simulator
    {
        public static string VirusName = "Default";
        public static double PROPABILITYTOBEDEAD = 0.1;
        public static double PROPABILITYTOCURE = 0.3;
        public static bool RunningSimulation { get; set; } = false;
        public static SimulatorStateEnum SimulatorState { get; set; }
        public static int MaxIterationCount { get; set; } = 13;
        public static double InfectionChance { get; set; } = 0.02;
        public static int Iteration { get; set; }

        public static int AllPeople { get; set; }
        public static int AllHealthyPeoples { get; set; }
        public static int AllInfectedPeoples { get; set; }
        public static int AllDeadPeoples { get; set; }

        public static void StopSimulation()
        {
            RunningSimulation = false;
        }

        public static void StartSimulation(List<RectanglePointer> rectanglePointer)
        {
            Trace.WriteLine("text");
            Thread thread = new Thread(()=>
            {
                Graph graph = new Graph(rectanglePointer);
                //graph.GoThroughtNodes(ThroughNodeActionEnum.FirstInfect);
                Console.WriteLine("stop");
                do
                {
                    graph.IterateThroughtRectangles();
                    Thread.Sleep(100);
                    Simulator.Iteration++;

                } while (SimulatorState == SimulatorStateEnum.Run && AllPeople > 0 && AllInfectedPeoples !=0);
                Console.WriteLine("Asd");
            });
            //Simulation finished show popup window
            thread.IsBackground = true;
            thread.Start();
            Trace.WriteLine("Salmi");
        }
        public static void PassNewData(int allPeople,int allHealthypeaples,int allInfectedPeoples,int allDeadPeoples)
        {
            AllPeople = allPeople;
            AllHealthyPeoples= allHealthypeaples;
            AllInfectedPeoples= allInfectedPeoples;
            AllDeadPeoples = allDeadPeoples;
        }
        public static List<int> GetPeopleData()
        {
            return new List<int> { AllPeople,AllHealthyPeoples,AllInfectedPeoples,AllDeadPeoples };
        }
    }
}
