using Avalonia.Controls.Shapes;
using ReactiveUI.Fody.Helpers;
using Sim_Web.Db;
using Sim_Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace VirusSimulator_UI.Models
{
    public static class Simulator
    {
        public static string VirusName = "Default";
        public static double PROPABILITYTOBEDEAD = 0.25;
        public static double PROPABILITYTOCURE = 0.3;
        public static bool RunningSimulation { get; set; } = false;
        public static SimulatorStateEnum SimulatorState { get; set; }
        public static int MaxIterationCount { get; set; } = 13;
        public static double InfectionChance { get; set; } = 0.06;
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
            var mySimulation = new SimulationRun() {DateOfRun = DateTime.Now,VirusName = VirusName };
            var _dataContext1 = new DataContext();

            _dataContext1.Attach(mySimulation);
            _dataContext1.SaveChanges();
            int myId = _dataContext1.simulationRuns.Max(p => p.Id);
            Trace.WriteLine("text");
            Thread thread = new Thread(()=>
            {
                Graph graph = new Graph(rectanglePointer);
                //graph.GoThroughtNodes(ThroughNodeActionEnum.FirstInfect);
                Console.WriteLine("stop");
                do
                {
                    graph.IterateThroughtRectangles();
                    Thread.Sleep(1000);
                    Simulator.Iteration++;
                    SaveCurrentPeopleDatasToDb(myId, _dataContext1);
                } while (SimulatorState == SimulatorStateEnum.Run && AllPeople > 0 && AllInfectedPeoples !=0);
                Console.WriteLine("Asd");
                RunningSimulation = false;
                SimulatorState = SimulatorStateEnum.Stop;
            });
            //Simulation finished show popup window
            thread.IsBackground = true;
            thread.Start();
            Trace.WriteLine("Salmi");
        }

        private static void SaveSimulation(List<RectanglePointer> rectanglePointers)
        {
            //List<Rectangle> myRectangles = new List<Rectangle>();
            //foreach (var item in rectanglePointers)
            //{
            //    myRectangles.Add(item.rectangle); 
            //    item.rectangle = null;
                
                
            //}
            //string jsonString = JsonSerializer.Serialize(rectanglePointers);
            //List<BaseRectangle> deptObj = JsonSerializer.Deserialize<List<BaseRectangle>>(jsonString);

            //for (int i = 0; i < myRectangles.Count; i++)
            //{
            //    rectanglePointers[i].rectangle = myRectangles[0];
            //}
        }

        private static void SaveCurrentPeopleDatasToDb(int simulatorId, DataContext dataContext)
        {

            dataContext.simulationDatas.Add(new SimulationData()
            {
                AllDeadPeoples= AllDeadPeoples,
                AllHealthyPeoples= AllHealthyPeoples,
                AllPeople= AllPeople,
                AllInfectedPeoples= AllInfectedPeoples,
                SimulationId = simulatorId
            });
            dataContext.SaveChanges();
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
