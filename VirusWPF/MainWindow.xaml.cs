using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VirusWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Rectangle rectangle1;
        public int counter = 0;
        List<Point> MyPoints = new List<Point>();
        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                DrawSquare(mousePosition);
            }
        }
        private void DrawSquare(Point mousePosition)
        {
            rectangle1 = new Rectangle() { Width = 50, Height = 50, Fill = Brushes.Gray, Stroke = Brushes.Black, Name = "asd" };
            Canvas.SetLeft(rectangle1, mousePosition.X);
            Canvas.SetTop(rectangle1, mousePosition.Y);
            myCanvas.Children.Add(rectangle1);
        }
        private void Drawline(List<Point> points)
        {

            var line = new Line();
            line.X1 = points[0].X;
            line.Y1 = points[0].Y;
            line.X2 = points[1].X;
            line.Y2 = points[1].Y;
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 3;
            myCanvas.Children.Add(line);
        }
        private void RedrawObject(Rectangle rectangle)
        {
            rectangle1.StrokeThickness = 5;
            rectangle1.Stroke = Brushes.Brown;
        }
    }
}
