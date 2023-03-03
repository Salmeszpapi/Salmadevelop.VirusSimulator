using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace VirusSimulator_UI.ViewModels
{
	public class SimulationViewModel : ReactiveObject
	{

        public SimulationViewModel()
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

    }
    
}