using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace VirusSimulator_UI.Views
{
    public partial class SimulationView : UserControl
{
    public SimulationView()
    {
        InitializeComponent();
    }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
