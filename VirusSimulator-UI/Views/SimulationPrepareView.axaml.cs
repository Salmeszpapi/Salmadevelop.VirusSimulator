using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using System.Windows.Input;

namespace VirusSimulator_UI.Views
{
    public partial class SimulationPrepareView : UserControl
    {
        public SimulationPrepareView()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void OnMouseMove(object sender, PointerEventArgs e)
        {

        }
    }   
}
