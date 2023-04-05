using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusSimulator_UI.Models;

namespace VirusSimulator_UI.ViewModels
{
    public class PeoplesInNodeViewModel
    {
        public PeoplesInNodeViewModel(RectanglePointer rectanglePointer)
        {
            PeoplesCount = rectanglePointer.PeoplesCount;
            DeadCount = rectanglePointer.DeadCount;
            InfectedCount= rectanglePointer.InfectedCount;
            HouseTypeEnum= rectanglePointer.HouseTypeEnum;
            HealthyCount= rectanglePointer.HealthyCount;
            Id = rectanglePointer.Id;
        }
        [Reactive]
        public int Id { get; set; }
        [Reactive]
        public int PeoplesCount { get; set; }
        [Reactive]
        public int DeadCount { get; set; }
        [Reactive]
        public int InfectedCount { get; set; }
        [Reactive]
        public HouseTypeEnum HouseTypeEnum { get; set; }
        [Reactive]
        public int HealthyCount { get; set; }
        public void UpdateData(RectanglePointer rectanglePointer)
        {
            PeoplesCount = rectanglePointer.PeoplesCount;
            DeadCount = rectanglePointer.DeadCount;
            InfectedCount = rectanglePointer.InfectedCount;
            HealthyCount = rectanglePointer.HealthyCount;
            HouseTypeEnum= rectanglePointer.HouseTypeEnum;
            Id = rectanglePointer.Id;
        }
    }
}
