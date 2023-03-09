using Avalonia.Threading;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusSimulator_UI.Models;

namespace VirusSimulator_UI.ViewModels
{
    public class ShowPeaplesInNodeViewModel : ViewModelBase
    {
        private DispatcherTimer LiveTime;
        public ShowPeaplesInNodeViewModel(RectanglePointer rectanglePointer)
        {
            LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromMilliseconds(1);
            LiveTime.Tick += timer_Tick;
            Id =  rectanglePointer.Id;
            PeoplesCount= rectanglePointer.PeoplesCount;
            houseTypeEnum= rectanglePointer.HouseTypeEnum;
            DeadCount = rectanglePointer.DeadCount;
            InfectedCount = rectanglePointer.InfectedCount;
            HealthyCount= rectanglePointer.HealthyCount;

        }
        [Reactive]
        public int Id { get; set; }
        [Reactive]
        public int PeoplesCount { get; set; }
        [Reactive]
        public HouseTypeEnum houseTypeEnum { get; set; }
        [Reactive]
        public int DeadCount { get; set; }
        [Reactive]
        public int InfectedCount { get; set; }
        [Reactive]
        public int HealthyCount { get; set; }
        void timer_Tick(object sender, EventArgs e)
        {

        }
    }
}
