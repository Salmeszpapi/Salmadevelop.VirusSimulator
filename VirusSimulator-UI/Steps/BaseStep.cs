using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusSimulator_UI.Steps
{
    public abstract class BaseStep
    {
        public virtual event EventHandler ViewModelPropertyChanged;
        public BaseStep() { }
        public void OnViewModelPropertyChanged(EventArgs e)
        {
            ViewModelPropertyChanged?.Invoke(this, e);
        }
        public abstract UserControl GetScreenContent();

    }
}
