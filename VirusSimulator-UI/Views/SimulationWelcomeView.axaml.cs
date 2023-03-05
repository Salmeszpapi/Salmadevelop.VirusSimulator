using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace VirusSimulator_UI.Views
{
    public partial class SimulationWelcomeView : UserControl
{
    public SimulationWelcomeView()
    {
        InitializeComponent();
    }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
