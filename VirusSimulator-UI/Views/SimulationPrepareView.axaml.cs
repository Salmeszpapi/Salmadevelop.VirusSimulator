using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Threading;
using System.Collections.Generic;
using VirusSimulator_UI.Models;
using System.Windows.Input;
using Avalonia.Media.Imaging;
using System.IO;
using System.Linq;
using SkiaSharp;

namespace VirusSimulator_UI.Views
{
    public partial class SimulationPrepareView : UserControl
    {
        public Rectangle? rectangle1;
        List<RectanglePointer> MyPoints = new List<RectanglePointer>();
        private List<RectanglePointer> myRectanglesPoints = new List<RectanglePointer>();
        DispatcherTimer LiveTime = new DispatcherTimer();
        private bool simulationOn = false;
        private int peopleIdcounter;
        private ShowPeaplesInNodeView? myShowPeaplesInNodeWindow;
        public string TestBindingText { get; set; }
        public Bitmap ImageToView { get; set; }
        public SimulationPrepareView()
        {
            InitializeComponent();
            SimulationCanvas = this.FindControl<Canvas>("SimulationCanvas");

        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void OnMouseMove2(object sender, PointerEventArgs e)
        {
            if (rectangle1 is not null)
            {
                if (simulationOn && e.Source is Rectangle)
                {
                    var sameRectangle = myRectanglesPoints.Where(x => x.rectangle == e.Source).FirstOrDefault();
                    //TestDatacontextxaml testDatacontextxaml = new TestDatacontextxaml(sameRectangle);
                    //testDatacontextxaml.Show();
                    //myShowPeaplesInNodeWindow = ShowPeaplesInNodeWindow.getInstance();
                    sameRectangle.ReadPeopleStatus();
                    //myShowPeaplesInNodeWindow.SetPointer(sameRectangle);
                    if (myShowPeaplesInNodeWindow != null)
                    {
                        myShowPeaplesInNodeWindow.Show();
                    }
                }
                else if (e.Source is Rectangle)
                {
                    rectangle1 = (Rectangle)e.Source;
                    rectangle1.Fill = Brushes.BurlyWood;
                }
                else if (e.Source is Canvas)
                {
                    if (simulationOn && myShowPeaplesInNodeWindow != null)
                    {
                        myShowPeaplesInNodeWindow.Close();
                    }
                    rectangle1.Fill = Brushes.Gray;
                }
            }
        }
        private void OnMouseClick(object sender, PointerPressedEventArgs e)
        {
            var mousePosition = e.GetPosition(SimulationCanvas);
            if (e.GetPointerPoint(null).Properties.IsLeftButtonPressed)
            {
                if (e.Source is Rectangle)
                {

                    var sameRectangle = myRectanglesPoints.Where(x => x.rectangle == e.Source).FirstOrDefault();
                    if (e.Source is Rectangle)
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
            else
            {
                if (e.Source is Rectangle)
                {
                    var sameRectangle = myRectanglesPoints.Where(x => x.rectangle == e.Source).FirstOrDefault();
                    SimulationCanvas.Children.Remove(sameRectangle.rectangle);
                    SimulationCanvas.Children.Remove(sameRectangle.textBox);
                    foreach (var line in sameRectangle.lines) { SimulationCanvas.Children.Remove(line); }
                    myRectanglesPoints.Remove(sameRectangle);
                }
            }
        }

        private void Drawline(List<RectanglePointer> points)
        {
            if (!simulationOn && !(points[0].neighbours.Contains(points[1]) && points[1].neighbours.Contains(points[0])))
            {
                var line = new Line();
                line.StartPoint = points[0].pointer;
                line.EndPoint = points[1].pointer;
                line.Stroke = Brushes.Black;
                line.StrokeThickness = 1;
                points[0].lines.Add(line);
                points[0].neighbours.Add(points[1]);
                points[1].neighbours.Add(points[0]);
                points[1].lines.Add(line);
                SimulationCanvas.Children.Add(line);
            }
        }

        private void DrawRectangle(Point mousePosition)
        {
            if (DistanceCalculator(mousePosition) && true)
            {
                rectangle1 = new Rectangle() { Width = 20, Height = 20, Fill = Brushes.Gray, Stroke = Brushes.Black, Name = "asd" };
                Canvas.SetLeft(rectangle1, mousePosition.X);
                Canvas.SetTop(rectangle1, mousePosition.Y);
                var rectangleText = RectangleNamer();
                SimulationCanvas.Children.Add(rectangle1);
                var textblock = DrawText(mousePosition.X + 5, mousePosition.Y + 20, rectangleText.ToString(), Color.FromRgb(0, 0, 0));
                var newRectangle = new RectanglePointer(rectangleText, rectangle1, mousePosition, peopleIdcounter);
                peopleIdcounter = newRectangle.PeopleIdcounter;
                newRectangle.textBox = textblock;
                myRectanglesPoints.Insert(rectangleText, newRectangle);
                System.Console.WriteLine(SimulationCanvas.Children.Count);
            }
        }

        private bool DistanceCalculator(Point point)
        {
            double myX, myY;
            foreach (var points in myRectanglesPoints)
            {
                var a = point + point;
                //var distance = Point.Subtract(point, points.pointer);
                var distance = point - points.pointer;
                myX = distance.X;
                myY = distance.Y;
                if (distance.Y < 0)
                {
                    myY = distance.Y * -1;
                    if (distance.X < 0)
                    {
                        myX = distance.X * -1;
                    }
                }
                else if (distance.X < 0)
                {
                    myX = distance.X * -1;
                }

                if ((myX < 50.0 && myY < 50.0)  )
                {
                    return false;
                }
            }
            return true;
        }

        private int RectangleNamer()
        {
            int checkId = 0;
            foreach (var rectangle in myRectanglesPoints)
            {
                if (rectangle.Id != checkId)
                {
                    return checkId;
                }
                checkId++;
            }
            return myRectanglesPoints.Count;
        }

        private TextBlock DrawText(double x, double y, string text, Color color)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.FontSize = 14;
            textBlock.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            SimulationCanvas.Children.Add(textBlock);
            return textBlock;
        }
    }   
}
