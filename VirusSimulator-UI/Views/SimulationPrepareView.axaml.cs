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
        private Canvas myNewCanvas { get; set; }
        public SimulationPrepareView()
        {
            InitializeComponent();
            SimulationCanvas = this.FindControl<Canvas>("SimulationCanvas");
            //Bitmap myBitmap = new Bitmap(@"Assets/avalonia-logo.ico");
            //SimulationCanvas.Background = new ImageBrush(myBitmap);
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void OnMouseMove2(object sender, PointerEventArgs e)
        {

        }
        private void OnMouseClick(object sender, PointerPressedEventArgs e)
        {
            var mousePosition = e.GetPosition(SimulationCanvas);
            if (e.Source is Rectangle)
            {
                //var sameRectangle = myRectanglesPoints.Where(x => x.rectangle == e.OriginalSource).FirstOrDefault();

                //if (e.OriginalSource is Rectangle)
                //{
                //    MyPoints.Add(sameRectangle);
                //    if (MyPoints.Count == 2)
                //    {
                //        Drawline(MyPoints);
                //        MyPoints.Clear();
                //    }
                //}
            }
            else
            {
                //MyPoints.Clear();
                ////if(myRectanglesPoints.Where(x => x.pointer.X))
                DrawRectangle(mousePosition);
            }
        }

        private void DrawRectangle(Point mousePosition)
        {
            if (DistanceCalculator(mousePosition) && true)
            {
                rectangle1 = new Rectangle() { Width = 15, Height = 15, Fill = Brushes.Gray, Stroke = Brushes.Black, Name = "asd" };
                Canvas.SetLeft(rectangle1, mousePosition.X);
                Canvas.SetTop(rectangle1, mousePosition.Y);
                var rectangleText = RectangleNamer();
                SimulationCanvas.Children.Add(rectangle1);
                var textblock = DrawText(mousePosition.X + 5, mousePosition.Y + 15, rectangleText.ToString(), Color.FromRgb(0, 0, 0));
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

                if (myX < 50.0 && myY < 50.0)
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
