using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace VirusSimulator_UI.Views
{
    public partial class PopupWindowExitSimulationView : Window
    {
        public PopupWindowExitSimulationView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
