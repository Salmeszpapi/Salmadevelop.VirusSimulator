using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VirusSimulator_UI.Views
{
    public partial class OpenSimulatorView : Window
    {
        public OpenSimulatorView()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
