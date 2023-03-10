using Avalonia.Threading;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusSimulator_UI.Models;

namespace VirusSimulator_UI.ViewModels
{
    public class ShowPeaplesInNodeViewModel : ViewModelBase
    {

        private RectanglePointer myrectanglePointer;
        public ShowPeaplesInNodeViewModel(RectanglePointer rectanglePointer)
        {
            myrectanglePointer = rectanglePointer;
            Id =  rectanglePointer.Id;
            PeoplesCount= rectanglePointer.PeoplesCount;
            HouseTypeEnum = rectanglePointer.HouseTypeEnum;
            DeadCount = rectanglePointer.DeadCount;
            InfectedCount = rectanglePointer.InfectedCount;
            HealthyCount= rectanglePointer.HealthyCount;
        }
        [Reactive]
        public int Id { get; set; }
        [Reactive]
        public int PeoplesCount { get; set; }
        [Reactive]
        public HouseTypeEnum HouseTypeEnum { get; set; }
        [Reactive]
        public int DeadCount { get; set; }
        [Reactive]
        public int InfectedCount { get; set; }
        [Reactive]
        public int HealthyCount { get; set; }
        //void timer_Tick(object sender, EventArgs e)
        //{
        //    Id = myrectanglePointer.Id;
        //    PeoplesCount = myrectanglePointer.PeoplesCount;
        //    houseTypeEnum = myrectanglePointer.HouseTypeEnum;
        //    DeadCount = myrectanglePointer.DeadCount;
        //    InfectedCount = myrectanglePointer.InfectedCount;
        //    HealthyCount = myrectanglePointer.HealthyCount;
        //}
        public void UpdateData(RectanglePointer rectanglePointer)
        {
            Id = rectanglePointer.Id;
            PeoplesCount = rectanglePointer.PeoplesCount;
            HouseTypeEnum = rectanglePointer.HouseTypeEnum;
            DeadCount = rectanglePointer.DeadCount;
            InfectedCount = rectanglePointer.InfectedCount;
            HealthyCount = myrectanglePointer.HealthyCount;
        }
    }
}
