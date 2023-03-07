using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
//using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using VirusWPF.Models;
using VirusWPF.Windows;

namespace VirusWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Rectangle rectangle1;
        List<RectanglePointer> MyPoints = new List<RectanglePointer>();
        private List<RectanglePointer> myRectanglesPoints = new List<RectanglePointer>();
        DispatcherTimer LiveTime = new DispatcherTimer();
        private bool simulationOn = false;
        private int peopleIdcounter;
        private ShowPeaplesInNodeWindow myShowPeaplesInNodeWindow;

        public MainWindow()
        {
            InitializeComponent();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
            myCanvas.Margin = new Thickness(10, 10, 50, 50);
            string startupPath = Environment.CurrentDirectory;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("C:\\Diploma\\ApplicationCore\\VirusWPF\\Images\\Slovakia.png", UriKind.RelativeOrAbsolute));
            myCanvas.Background = ib;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");

        }

        #region Mouse events
        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mousePosition = e.GetPosition(myCanvas);
            if (e.OriginalSource is Rectangle)
            {
                var sameRectangle = myRectanglesPoints.Where(x => x.rectangle == e.OriginalSource).FirstOrDefault();

                if (e.OriginalSource is Rectangle)
                {
                    MyPoints.Add(sameRectangle);
                    if (MyPoints.Count == 2)
                    {
                        Drawline(MyPoints);
                        MyPoints.Clear();
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

            if (e.OriginalSource is Rectangle)
            {
                var sameRectangle = myRectanglesPoints.Where(x => x.rectangle == e.OriginalSource).FirstOrDefault();
                myCanvas.Children.Remove(sameRectangle.rectangle);
                myCanvas.Children.Remove(sameRectangle.textBox);
                foreach (var line in sameRectangle.lines) { myCanvas.Children.Remove(line); }
                myRectanglesPoints.Remove(sameRectangle);
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
            if (rectangle1 is not null)
            {
                if (simulationOn && e.OriginalSource is Rectangle)
                {
                    var sameRectangle = myRectanglesPoints.Where(x => x.rectangle == e.OriginalSource).FirstOrDefault();
                    TestDatacontextxaml testDatacontextxaml = new TestDatacontextxaml(sameRectangle);
                    testDatacontextxaml.Show();
                    myShowPeaplesInNodeWindow = ShowPeaplesInNodeWindow.getInstance();
                    sameRectangle.ReadPeopleStatus();
                    myShowPeaplesInNodeWindow.SetPointer(sameRectangle);
                    if (myShowPeaplesInNodeWindow != null)
                    {
                        myShowPeaplesInNodeWindow.Show();
                    }
                }
                else if (e.OriginalSource is Rectangle)
                {
                    rectangle1 = (Rectangle)e.OriginalSource;
                    rectangle1.Fill = Brushes.BurlyWood;
                }
                else if (e.OriginalSource is Canvas)
                {
                    if (simulationOn && myShowPeaplesInNodeWindow != null)
                    {
                        myShowPeaplesInNodeWindow.Close();
                    }
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
            textBlock.FontSize = 14;
            textBlock.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            myCanvas.Children.Add(textBlock);
            return textBlock;
        }

        private void DrawRectangle(Point mousePosition)
        {
            if (DistanceCalculator(mousePosition) && !simulationOn)
            {
                rectangle1 = new Rectangle() { Width = 15, Height = 15, Fill = Brushes.Gray, Stroke = Brushes.Black, Name = "asd" };
                Canvas.SetLeft(rectangle1, mousePosition.X);
                Canvas.SetTop(rectangle1, mousePosition.Y);
                var rectangleText = rectangleNamer();
                myCanvas.Children.Add(rectangle1);
                var textblock = DrawText(mousePosition.X + 5, mousePosition.Y + 15, rectangleText.ToString(), Color.FromRgb(0, 0, 0));
                var newRectangle = new RectanglePointer(rectangleText, rectangle1, mousePosition, peopleIdcounter);
                peopleIdcounter = newRectangle.PeopleIdcounter;
                newRectangle.textBox = textblock;
                myRectanglesPoints.Insert(rectangleText,newRectangle);
            }
        }

        private int rectangleNamer()
        {
            int checkId = 0;
            foreach(var rectangle in myRectanglesPoints)
            {
                if(rectangle.Id != checkId)
                {
                    return checkId;
                }
                checkId++;
            }
            return myRectanglesPoints.Count;
        }

        private void Drawline(List<RectanglePointer> points)
        {
            if (!simulationOn && !(points[0].neighbours.Contains(points[1]) && points[1].neighbours.Contains(points[0])))
            {
                var line = new Line();
                line.X1 = points[0].pointer.X;
                line.Y1 = points[0].pointer.Y;
                line.X2 = points[1].pointer.X;
                line.Y2 = points[1].pointer.Y;
                line.Stroke = Brushes.Black;
                line.StrokeThickness = 1;
                points[0].lines.Add(line);
                points[0].neighbours.Add(points[1]);
                points[1].neighbours.Add(points[0]);
                points[1].lines.Add(line);
                myCanvas.Children.Add(line);
            }
        }

        private void Drawline(RectanglePointer rectangle1, RectanglePointer rectangle2)
        {
            if (rectangle1!=rectangle2 && !simulationOn && !(rectangle1.neighbours.Contains(rectangle2) && rectangle2.neighbours.Contains(rectangle1)))
            {
                var line = new Line();
                line.X1 = rectangle1.pointer.X;
                line.Y1 = rectangle1.pointer.Y;
                line.X2 = rectangle2.pointer.X;
                line.Y2 = rectangle2.pointer.Y;
                line.Stroke = Brushes.Black;
                line.StrokeThickness = 1.5;
                rectangle1.lines.Add(line);
                rectangle2.lines.Add(line);
                rectangle1.neighbours.Add(rectangle2);
                rectangle2.neighbours.Add(rectangle1);
                myCanvas.Children.Add(line);
            }
        }

        private bool DistanceCalculator(Point point)
        {
            foreach(var points in myRectanglesPoints)
            {
                var distance = Point.Subtract(point, points.pointer);
                if (distance.X < 0) distance.X *= -1;
                if (distance.Y < 0) distance.Y *= -1;
                if (distance.X < 50 && distance.Y < 50)
                {
                    return false;
                }
            }
            return true;
        }

        private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //drag canvas an moove 
            if (e.MiddleButton == MouseButtonState.Pressed)
            {

            }
        }

        private void Start_Simulation(object sender, RoutedEventArgs e)
        {
            if(myRectanglesPoints.Count > 1)
            {
                simulationOn = true;
                Simulator simulator = new Simulator(myRectanglesPoints);
            }
            else
            {
                //error popup you need 2 or more Places
            }
        }
        #endregion

        private void Restart_NewSimulation(object sender, RoutedEventArgs e)
        {
            clearCanvas();
        }

        private void Save_Simulation(object sender, RoutedEventArgs e)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true

            };
            string jsonString = JsonSerializer.Serialize(myRectanglesPoints[0]);
        }

        private void Open_Simulation(object sender, RoutedEventArgs e)
        {

        }
        private void Random_NewSimulation(object sender, RoutedEventArgs e)
        {
            RandomGraphWindow graphWindow = new RandomGraphWindow(this);
            graphWindow.Show();
        }
        public void createNewRandomGraph(int text)
        {
            clearCanvas();
            for (int i = 0; i < text;i++)
            {
                Point newPoint = new Point(new Random().Next(0,1180), new Random().Next(0,800));
                DrawRectangle(newPoint);
            }

            foreach(var rectangle in myRectanglesPoints)
            {
                for(int i=0;i<new Random().Next(0,text/2);i++) 
                {
                    Drawline(rectangle, myRectanglesPoints[new Random().Next(0,myRectanglesPoints.Count)]);
                }
            }
            var result = CountTheHabitablehouses();
        }

        private int CountTheHabitablehouses()
        {
            int count = 0;
            foreach (var rectangle in myRectanglesPoints)
            {
                if(rectangle.HouseTypeEnum == HouseTypeEnum.House)
                {
                    count++;
                }
            }
            return count;
        }
        private void clearCanvas()
        {
            simulationOn = false;
            myCanvas.Children.Clear();
            rectangle1 = null;
            MyPoints.Clear();
            myRectanglesPoints.Clear();
        }
    }
}