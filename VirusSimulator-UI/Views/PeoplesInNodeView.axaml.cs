using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VirusSimulator_UI.Views
{
    public partial class PeoplesInNodeView : UserControl
    {
        public PeoplesInNodeView()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
