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
        public const double PROPABILITYTOBEDEAD = 0.3;
        public const double PROPABILITYTOCURE = 0.2;
        public static bool RunningSimulation { get; set; }
        public static SimulatorStateEnum SimulatorState { get; set; }
        public static int MaxIterationCount { get; set; } = 13;
        public static double InfectionChance { get; set; } = 0.04;
        public static int Iteration { get; set; }

        public static int AllPeople { get; set; }
        public static int AllHealthyPeoples { get; set; }
        public static int AllInfectedPeoples { get; set; }
        public static int AllDeadPeoples { get; set; }

        public static void StopSimulation()
        {
            RunningSimulation = false;
        }

        public static async Task StartSimulation(List<RectanglePointer> rectanglePointer)
        {
            Trace.WriteLine("text");
            Thread thread = new Thread(async () =>
            {
                Graph graph = new Graph(rectanglePointer);
                //graph.GoThroughtNodes(ThroughNodeActionEnum.FirstInfect);
                Console.WriteLine("stop");
                do
                {
                    while (!RunningSimulation)
                    {
                        
                    }
                    await graph.IterateThroughtRectangles();
                    Thread.Sleep(1000);
                    Simulator.Iteration++;
                } while (true);
            });
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
