using System;
using System.Collections.Generic;
using System.Linq;
//using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using VirusWPF.Models;

namespace VirusWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Rectangle rectangle1;
        public int counter = 0;
        List<Point> MyPoints = new List<Point>();
        private List<RectanglePointer> myRectanglesPoints = new List<RectanglePointer>();
        Brush previousRectangleColor;
        public MainWindow()
        {
            InitializeComponent();
            //myCanvas.Margin = new Thickness(10, 10, 50, 50);

        }
        #region Mouse events
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
                DrawRectangle(mousePosition);
            }
        }
        
        private void myCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mousePosition = e.GetPosition(myCanvas);
            if(e.OriginalSource is Rectangle)
            {
                var sameRectangle = myRectanglesPoints.Where(x => x.rectangle == rectangle1).FirstOrDefault();
                DrawRectanglePropertys(new Point() { X = sameRectangle.pointer.X - 80.5, Y = sameRectangle.pointer.Y},"Remove");
                DrawRectanglePropertys(new Point() { X = sameRectangle.pointer.X + 50.5, Y = sameRectangle.pointer.Y },"Connect");
            }
        }

        private void DrawRectanglePropertys(Point mousePosition,string text)
        {
            rectangle1 = new Rectangle() { Width = 80, Height = 50, Fill = Brushes.Gray, Stroke = Brushes.Black, Name = "asd" };
            Canvas.SetLeft(rectangle1, mousePosition.X);
            Canvas.SetTop(rectangle1, mousePosition.Y);
            var rnd = Guid.NewGuid().ToString().Substring(0, 5);
            myRectanglesPoints.Add(new RectanglePointer(rnd, rectangle1, mousePosition));
            myCanvas.Children.Add(rectangle1);
            DrawText(mousePosition.X + 7, mousePosition.Y + 17, text, Color.FromRgb(0, 0, 0));
        }

        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var element = (UIElement)sender;
            var position = e.GetPosition(element);
            var transform = (MatrixTransform)element.RenderTransform;
            var matrix = transform.Matrix;
            var scale = e.Delta >= 0 ? 1.1 : (1.0 / 1.1); // choose appropriate scaling factor

            matrix.ScaleAtPrepend(scale, scale, position.X, position.Y);
            transform.Matrix = matrix;
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            MyText.Text = e.GetPosition(myCanvas).ToString();
            if (e.OriginalSource is Rectangle )
            {
                rectangle1 = (Rectangle)e.OriginalSource;
                rectangle1.Fill = Brushes.Teal;

                previousRectangleColor = Brushes.Gray;
            }
            else
            {
                if (previousRectangleColor != null) rectangle1.Fill = previousRectangleColor;
            }
        }
        #endregion
        #region private helpers
        private void DrawText(double x, double y, string text, Color color)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.FontSize= 14;
            textBlock.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            myCanvas.Children.Add(textBlock);
        }

        private void DrawRectangle(Point mousePosition)
        {
            rectangle1 = new Rectangle() { Width = 50, Height = 50, Fill = Brushes.Gray, Stroke = Brushes.Black, Name = "asd" };
            Canvas.SetLeft(rectangle1, mousePosition.X);
            Canvas.SetTop(rectangle1, mousePosition.Y);
            var rnd = Guid.NewGuid().ToString().Substring(0, 5);
            myRectanglesPoints.Add(new RectanglePointer(rnd, rectangle1,mousePosition));
            myCanvas.Children.Add(rectangle1);
            DrawText(mousePosition.X+5,mousePosition.Y+50, rnd.ToString(), Color.FromRgb(0,0,0));
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

        private Point GetPosition(double x, double y)
        {
            return new Point(x, y);
        }
        #endregion
    }
}
