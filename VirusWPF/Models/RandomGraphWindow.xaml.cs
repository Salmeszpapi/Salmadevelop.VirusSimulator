using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VirusWPF.Models
{
    /// <summary>
    /// Interaction logic for RandomGraphWindow.xaml
    /// </summary>
    public partial class RandomGraphWindow : Window
    {
        public string NodeCount { get; set; }
        public RandomGraphWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NodeCount = this.NodeSize.Text.ToString();
            this.Close();
        }
    }
}
