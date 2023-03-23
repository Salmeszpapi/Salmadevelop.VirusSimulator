using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ScottPlot.Avalonia;
using System.Drawing;

namespace VirusSimulator_UI.Views
{
    public partial class ChartsView : UserControl
    {
        public ChartsView()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            test();
        }
        public void test()
        {

        }
    }
}
