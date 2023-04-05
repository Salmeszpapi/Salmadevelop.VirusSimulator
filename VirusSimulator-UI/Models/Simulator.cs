using Avalonia.Controls.Shapes;
using DynamicData;
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
using VirusSimulator_UI.Steps;

namespace VirusSimulator_UI.Models
{
    public static class Simulator
    {
        public static string VirusName { get; set; } = "Default";
        public static double PROPABILITYTOBEDEAD = 0.25;
        public static double PROPABILITYTOCURE = 0.3;
        public static bool RunningSimulation { get; set; } = false;
        public static SimulatorStateEnum SimulatorState { get; set; }
        public static int MaxIterationCount { get; set; } = 13;
        public static double InfectionChance { get; set; } = 0.06;
        public static int Iteration { get; set; }

        public static int? AllPeople { get; set; }
        public static int? AllHealthyPeoples { get; set; }
        public static int? AllInfectedPeoples { get; set; }
        public static int? AllDeadPeoples { get; set; }

        public static void StopSimulation()
        {
            RunningSimulation = false;
        }

        public static async void StartSimulation(List<RectanglePointer> rectanglePointer)
        {
            var mySimulation = new SimulationRun() {
                DateOfRun = DateTime.Now,VirusName = VirusName, 
                RectanglesWithPeople = await GetJsonFromRectangles()
            };
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
            ResetPeaples();
        }

        private static async Task<string> GetJsonFromRectangles()
        {
            var options = new JsonSerializerOptions
            {
                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals
            };
            SimulationPrepareStep simulationPrepareStep = (SimulationPrepareStep)WorkFlowManager.GetStep("SimulationPrepareStep");
            var myRectangles = simulationPrepareStep.GetView().myRectanglesPoints;
            List<RectanglePointer> rectangles = new List<RectanglePointer>();
            //foreach (var item in myRectangles)
            //{
            //    rectangles.Add(item);
            //    item.rectangle = null;

            //}
            for (int i = 0; i < myRectangles.Count; i++)
            {
                rectangles.Add(myRectangles[i]);
                myRectangles[i] = null;
            }

            string jsonString = JsonSerializer.Serialize(myRectangles, options);

            for (int i = 0; i < rectangles.Count; i++)
            {
                myRectangles[i] = rectangles[i];
            }
            return jsonString;
        }

        private static void ResetPeaples()
        {
            AllPeople = null;
            AllHealthyPeoples = null;
            AllDeadPeoples = null;
            AllInfectedPeoples = null;
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
                AllDeadPeoples= AllDeadPeoples.Value,
                AllHealthyPeoples= AllHealthyPeoples.Value,
                AllPeople= AllPeople.Value,
                AllInfectedPeoples= AllInfectedPeoples.Value,
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
            return new List<int> {
                AllPeople.Value,AllHealthyPeoples.Value,AllInfectedPeoples.Value,AllDeadPeoples.Value
            };
        }
    }
}
