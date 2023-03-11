using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
        }
    }
}
