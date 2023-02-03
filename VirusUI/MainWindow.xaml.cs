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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VirusUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Point> MyPoints = new List<Point>();
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Mouse events
        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePosition = e.GetPosition(myCanvas);
            if (e.OriginalSource is Rectangle)
            {
                MyPoints.Add(mousePosition);
                if (MyPoints.Count == 2)
                {
                    Drawline(MyPoints);
                    MyPoints.Clear();
                }
            }
            else
            {
                MyPoints.Clear();
                DrawRectangle(mousePosition);
            }
        }

        private void myCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var element = (UIElement)sender;
            var position = e.GetPosition(element);
            var transform = (MatrixTransform)element.RenderTransform;
            var matrix = transform.Matrix;
            var scale = e.Delta >= 0 ? 1.1 : (1.0 / 1.1); // choose appropriate scaling factor

            matrix.ScaleAtPrepend(scale, scale, position.X, position.Y);
            transform.Matrix = matrix;
        }

        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion
    }
}
