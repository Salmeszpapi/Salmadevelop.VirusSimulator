using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Microsoft.AspNetCore.Mvc.Formatters;
using Sim_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using VirusSimulator_UI.Models;
using VirusSimulator_UI.ViewModels;
using VirusSimulator_UI.Views;

namespace VirusSimulator_UI.Steps
{
    public class SimulationPrepareStep : BaseStep
    {
        private SimulationPrepareView simulationPrapareView;
        private SimulationPrepareViewModel simulationPrepareViewModel;
        public SimulationPrepareStep(NewWindowType newWindowType,string nodeCount,string minConnection,string maxConnection)
        {
            simulationPrepareViewModel = new SimulationPrepareViewModel();
            simulationPrapareView = new SimulationPrepareView(newWindowType, nodeCount, minConnection, maxConnection) { DataContext = simulationPrepareViewModel };
            WorkFlowManager.SaveStep(this);
        }
        public SimulationPrepareStep()
        {
            simulationPrepareViewModel = new SimulationPrepareViewModel();
            simulationPrapareView = new SimulationPrepareView() { DataContext = simulationPrepareViewModel };
            WorkFlowManager.SaveStep(this);
        }

        public SimulationPrepareStep(SimulationRun mySimulationRun)
        {
            var options = new JsonSerializerOptions
            {
                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals
            };
            List<RectanglePointer> deptObj = JsonSerializer.Deserialize<List<RectanglePointer>>(mySimulationRun.RectanglesWithPeople, options);
            List<string> deptObj2 = JsonSerializer.Deserialize<List<string>>(mySimulationRun.RectanglePointers, options);
            List<string> myListOfRectangleNeigboursID = JsonSerializer.Deserialize<List<string>>(mySimulationRun.Neighbours, options);
            for (int i = 0; i < deptObj.Count; i++)
            {
                var pointers = deptObj2[i].Split(",");
                var myPointer = new Point(Convert.ToDouble(pointers[0]), Convert.ToDouble(pointers[1]));
                deptObj[i].pointer = myPointer;
                var mySplittedIdRectangles = myListOfRectangleNeigboursID[i].Split(",");
                foreach (var item in mySplittedIdRectangles)
                {
                    if(!string.IsNullOrEmpty(item))
                    {
                        deptObj[i].neighbours.Add(deptObj.Where(x => x.Id == Convert.ToInt32(item)).FirstOrDefault());
                    }
                }

            }
            simulationPrepareViewModel = new SimulationPrepareViewModel();
            simulationPrapareView = new SimulationPrepareView(deptObj) { DataContext = simulationPrepareViewModel };
            WorkFlowManager.SaveStep(this);
        }

        public override UserControl GetScreenContent()
        {
            return simulationPrapareView;
        }
        public SimulationPrepareView GetView() 
        {
            return simulationPrapareView;
        }
        public void TearDown()
        {
            simulationPrapareView = null;
            simulationPrepareViewModel = null;
        }

    }
}
