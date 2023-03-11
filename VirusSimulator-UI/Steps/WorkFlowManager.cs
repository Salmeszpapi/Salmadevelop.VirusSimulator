using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VirusSimulator_UI.Steps
{
    public static class WorkFlowManager
    {
        private static Dictionary<string, BaseStep> listofSteps = new Dictionary<string, BaseStep>();
        public static void SaveStep(BaseStep someStep)
        {
            if(listofSteps.ContainsKey(someStep.GetType().Name))
            {
                listofSteps[someStep.GetType().Name] = someStep;
            }
            else
            {
                var a = someStep.GetType().Name;
                listofSteps.Add(someStep.GetType().Name, someStep);
            }
        }
        public static BaseStep GetStep(string name) 
        {
            if (listofSteps.ContainsKey(name))
                return listofSteps[name];
            else
                throw new Exception(String.Format("Key {0} was not found", name));       
        }
        //public static bool IsStepInTheWorkflowmanager(string name)
        //{
        //    if (listofSteps.ContainsKey(name));
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        public static void DeleteStep(string name)
        {
            var step = listofSteps[name];
            var view = step.GetScreenContent();
            view = null;
            listofSteps.Remove(name);
        }
    }
}
