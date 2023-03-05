using System;
using System.Collections.Generic;
using System.Reactive;
using Avalonia.Media.Imaging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace VirusSimulator_UI.ViewModels
{
	public class SimulationWelcomeViewModel : ViewModelBase
    {

        public SimulationWelcomeViewModel() 
        {
            
            CreateImage = new Bitmap(@"Assets/create.png");
            OpenImage = new Bitmap(@"Assets/open.png");
            RandomImage = new Bitmap(@"Assets/random.png");

        }
        [Reactive]
        public IBitmap CreateImage { get; set; }
        [Reactive]
        public IBitmap OpenImage { get; set; }
        [Reactive]
        public IBitmap RandomImage { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> CreateButtonClicked { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> OpenButtonClicked { get; set; }
        [Reactive]
        public ReactiveCommand<Unit, Unit> RandomButtonClicked { get; set; }

        public void CreateGraph()
        {
            
        }
    }
    
}