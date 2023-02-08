using System;
using System.Collections.Generic;
using System.Linq;
//using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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
        Rectangle rectangleproperty;
        public int counter = 0;
        List<RectanglePointer> MyPoints = new List<RectanglePointer>();
        private List<RectanglePointer> myRectanglesPoints = new List<RectanglePointer>();
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
                var sameRectangle = myRectanglesPoints.Where(x => x.rectangle == e.OriginalSource).FirstOrDefault();
                if(sameRectangle is not null && sameRectangle.RectangleType == RectangleTypeEnum.Connect)
                {
                    MyPoints.Add(myRectanglesPoints.Where(x => x.rectangle == rectangle1).FirstOrDefault());
                }
                else if(sameRectangle is not null && sameRectangle.RectangleType == RectangleTypeEnum.Remove)
                {
                    myRectanglesPoints.Clear();
                }
                else if (e.OriginalSource is Rectangle)
                {
                    MyPoints.Add(sameRectangle);
                    if (MyPoints.Count == 2)
                    {
                        Drawline(MyPoints);
                        MyPoints.Clear();
                        RemovePropertyes();
                    }
                }
            }
            else
            {
                MyPoints.Clear();
                //if(myRectanglesPoints.Where(x => x.pointer.X))
                DrawRectangle(mousePosition);
            }
        }
        
        private void myCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MyPoints.Clear();
            var mousePosition = e.GetPosition(myCanvas);
            if(e.OriginalSource is not Canvas)
            {
                var sameRectangle = myRectanglesPoints.Where(x => x.rectangle == rectangle1).FirstOrDefault();
                DrawRectanglePropertys(new Point() { X = sameRectangle.pointer.X - 85.5, Y = sameRectangle.pointer.Y },RectangleTypeEnum.Remove);
                DrawRectanglePropertys(new Point() { X = sameRectangle.pointer.X + 55.5, Y = sameRectangle.pointer.Y }, RectangleTypeEnum.Connect);
            }
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
            if(rectangle1 is not null)
            {
                if (e.OriginalSource is Rectangle)
                {
                    rectangle1 = (Rectangle)e.OriginalSource;
                    rectangle1.Fill = Brushes.BurlyWood;
                }
                else if (e.OriginalSource is Canvas)
                {
                    rectangle1.Fill = Brushes.Gray;
                }
            }
        }
        #endregion
        #region private helpers
        private TextBlock DrawText(double x, double y, string text, Color color)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.FontSize= 14;
            textBlock.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            myCanvas.Children.Add(textBlock);
            return textBlock;
        }

        private void DrawRectangle(Point mousePosition)
        {
            if (DistanceCalculator(mousePosition))
            {
                rectangle1 = new Rectangle() { Width = 50, Height = 50, Fill = Brushes.Gray, Stroke = Brushes.Black, Name = "asd" };
                Canvas.SetLeft(rectangle1, mousePosition.X);
                Canvas.SetTop(rectangle1, mousePosition.Y);
                var rnd = Guid.NewGuid().ToString().Substring(0, 5);
                myCanvas.Children.Add(rectangle1);
                var textblock = DrawText(mousePosition.X + 5, mousePosition.Y + 50, rnd.ToString(), Color.FromRgb(0, 0, 0));
                var newRectangle = new RectanglePointer(rnd, rectangle1, mousePosition);
                newRectangle.textBoxes.Add(textblock);
                myRectanglesPoints.Add(newRectangle);
                
                //myCanvas.Children.Add(textblock);
            }
            
        }

        private void DrawRectanglePropertys(Point mousePosition, RectangleTypeEnum rectangleType)
        {
            rectangleproperty = new Rectangle() { Width = 80, Height = 50, Fill = Brushes.Gray, Stroke = Brushes.Black, Name = "asd" };
            Canvas.SetLeft(rectangleproperty, mousePosition.X);
            Canvas.SetTop(rectangleproperty, mousePosition.Y);
            var rnd = Guid.NewGuid().ToString().Substring(0, 5);
            myRectanglesPoints.Add(new RectanglePointer(rnd, rectangleproperty, mousePosition) { RectangleType = rectangleType });
            myCanvas.Children.Add(rectangleproperty);
            DrawText(mousePosition.X + 7, mousePosition.Y + 17, rectangleType.ToString(), Color.FromRgb(0, 0, 0));
        }

        private void Drawline(List<RectanglePointer> points)
        {
            var line = new Line();
            line.X1 = points[0].pointer.X;
            line.Y1 = points[0].pointer.Y;
            line.X2 = points[1].pointer.X;
            line.Y2 = points[1].pointer.Y;
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 3;
            myCanvas.Children.Add(line);
        }

        private bool DistanceCalculator(Point point)
        {
            foreach(var points in myRectanglesPoints)
            {
                var distance = Point.Subtract(point, points.pointer);
                if (distance.X < 0) distance.X *= -1;
                if (distance.Y < 0) distance.Y *= -1;
                if (distance.X < 100 && distance.Y < 100)
                {
                    return false;
                }
            }
            return true;
        }
        private void RemovePropertyes()
        {
            var removePropertyes = myRectanglesPoints
            .Where(x => x.RectangleType == RectangleTypeEnum.Connect || x.RectangleType == RectangleTypeEnum.Remove).ToList();
            foreach (var items in removePropertyes)
            {
                myCanvas.Children.Remove(items.rectangle);
                foreach(var textblock in items.textBoxes)
                {
                    myCanvas.Children.Remove(textblock);
                }
                myRectanglesPoints.Remove(items);
            }
        }
        #endregion
    }
}
