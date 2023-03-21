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
using System;
using VirusSimulator_UI.Steps;
using System.Threading.Tasks;

namespace VirusSimulator_UI.Views
{
    public partial class SimulationPrepareView : UserControl
    {
        public Rectangle? rectangle1;
        List<RectanglePointer> MyPoints = new List<RectanglePointer>();
        public List<RectanglePointer> myRectanglesPoints = new List<RectanglePointer>();
        DispatcherTimer LiveTime;
        private int peopleIdcounter;
        private ShowPeaplesInNodeStep myPopupStep;
        private RectanglePointer previousRectangle;
        public SimulationPrepareView()
        {
            InitializeComponent();
            SimulationCanvas = this.FindControl<Canvas>("SimulationCanvas");
        }
        public SimulationPrepareView(NewWindowType newWindowType, string nodeCount, string minConnection, string maxConnection)
        {
            InitializeComponent();

            SimulationCanvas = this.FindControl<Canvas>("SimulationCanvas");
            
            if ((nodeCount != null && minConnection != null && maxConnection != null))
            {
                createNewRandomGraph(Convert.ToInt32(nodeCount), Convert.ToInt32(minConnection), Convert.ToInt32(maxConnection));
            }
            else
            {
                createNewRandomGraph(50);
            }
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            if (LiveTime == null)
            {
                LiveTime = new DispatcherTimer();
                LiveTime.Interval = TimeSpan.FromMilliseconds(1);
                LiveTime.Tick += timer_Tick;
                LiveTime.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Simulator.RunningSimulation)
            {
                RefressRectangleContent();
                //Simulator.Iteration++;
            }
        }
        private void RefressRectangleContent()
        {
            if (myPopupStep is not null && myPopupStep.GetView().IsVisible)
            {
                previousRectangle.ReadPeopleStatus();
                myPopupStep.UpdateData(previousRectangle);
            }
            ReColorizeRectangle();
        }

        private void ReColorizeRectangle()
        {
            foreach (var item in myRectanglesPoints)
            {
                item.ReadPeopleStatus();
                if(item.PeoplesCount != 0)
                {
                    var percentInfected = (100 * item.InfectedCount) / item.PeoplesCount;
                    var percentDead = (100 * item.DeadCount) / item.PeoplesCount;
                    //if (percentInfected == 0 || percentDead == 0) item.rectangle.Fill = Brushes.Green;
                    //else if (percentDead < 20 || percentInfected < 20) item.rectangle.Fill = Brushes.YellowGreen;
                    //else if (percentDead < 40 || percentInfected < 40) item.rectangle.Fill = Brushes.Yellow;
                    //else if (percentDead < 60 || percentInfected < 60) item.rectangle.Fill = Brushes.Khaki;
                    //else if (percentDead < 80 || percentInfected < 80) item.rectangle.Fill = Brushes.Orange;
                    //else if (percentDead == 100 || percentInfected <= 100) item.rectangle.Fill = Brushes.Red;

                    switch (percentInfected)
                    {
                        case < 20 :
                            switch (percentDead)
                            {
                                case < 40:
                                    item.rectangle.Fill = Brushes.Green;
                                    break;
                                case 100:
                                    item.rectangle.Fill = Brushes.Black;
                                    break;
                                case > 95:
                                    item.rectangle.Fill = Brushes.DarkRed;
                                    break;
                                case > 60:
                                    item.rectangle.Fill = Brushes.IndianRed;
                                    break;
                            }
                            break;
                        case < 40 :
                            switch (percentDead)
                            {
                                case < 40:
                                    item.rectangle.Fill = Brushes.YellowGreen;
                                    break;
                                case 100:
                                    item.rectangle.Fill = Brushes.Black;
                                    break;

                                case > 90:
                                    item.rectangle.Fill = Brushes.DarkRed;
                                    break;
                                case > 60:
                                    item.rectangle.Fill = Brushes.IndianRed;
                                    break;

                            }
                            break;
                        case < 60:
                            switch (percentDead)
                            {
                                case < 40:
                                    item.rectangle.Fill = Brushes.Khaki;
                                    break;
                                case 100:
                                    item.rectangle.Fill = Brushes.Black;
                                    break;
                                case > 90:
                                    item.rectangle.Fill = Brushes.DarkRed;
                                    break;
                                case > 60:
                                    item.rectangle.Fill = Brushes.DarkKhaki;
                                    break;


                            }
                            break;
                        case < 80:
                            switch (percentDead)
                            {
                                case < 30:
                                    item.rectangle.Fill = Brushes.Orange;
                                    break;
                                case 100:
                                    item.rectangle.Fill = Brushes.Black;
                                    break;
                                case < 85:
                                    item.rectangle.Fill = Brushes.DarkOrange;
                                    break;
                                case > 60:
                                    item.rectangle.Fill = Brushes.OrangeRed;
                                    break;
                            }
                            item.rectangle.Fill = Brushes.Orange;
                            break;
                        case <= 100:
                            switch (percentDead)
                            {
                                case < 30:
                                    item.rectangle.Fill = Brushes.MediumVioletRed;
                                    break;
                                case < 40:
                                    item.rectangle.Fill = Brushes.IndianRed;
                                    break;
                                case 100:
                                    item.rectangle.Fill = Brushes.Black;
                                    break;
                                case > 60:
                                    item.rectangle.Fill = Brushes.Red;
                                    break;
                                case < 80:
                                    item.rectangle.Fill = Brushes.DarkRed;
                                    break;

                            }
                            item.rectangle.Fill = Brushes.Red;
                            break;
                    }
                }
            }
        }

        private void OnMouseMove2(object sender, PointerEventArgs e)
        {

            if (rectangle1 is not null)
            {
                if (e.Source is Rectangle)
                {
                    var sameRectangle = myRectanglesPoints.Where(x => x.rectangle == e.Source).FirstOrDefault();
                    sameRectangle.ReadPeopleStatus();
                    if(myPopupStep is null)
                    {
                        myPopupStep = new ShowPeaplesInNodeStep(sameRectangle);
                    }
                    if (previousRectangle == sameRectangle)
                    {
                        if (myPopupStep is not null && !myPopupStep.GetView().IsVisible)
                        {
                            myPopupStep = new ShowPeaplesInNodeStep(sameRectangle);
                            myPopupStep.GetView().Show();
                        }
                    }
                    else
                    {
                        myPopupStep.GetView().Close();
                    }
                    previousRectangle = sameRectangle;
                }
            }
        }

        private void OnMouseClick(object sender, PointerPressedEventArgs e)
        {
            if (!Simulator.RunningSimulation)
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
                                Drawline(MyPoints[0], MyPoints[1]);
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
                    if (e.Source is Rectangle && !Simulator.RunningSimulation)
                    {
                        var sameRectangle = myRectanglesPoints.Where(x => x.rectangle == e.Source).FirstOrDefault();
                        SimulationCanvas.Children.Remove(sameRectangle.rectangle);
                        SimulationCanvas.Children.Remove(sameRectangle.textBox);
                        foreach (var line in sameRectangle.lines) { SimulationCanvas.Children.Remove(line); }
                        myRectanglesPoints.Remove(sameRectangle);
                    }
                }
            }
            else if(e.Source is Rectangle && Simulator.RunningSimulation) 
            {
                var sameRectangle = myRectanglesPoints.Where(x => x.rectangle == e.Source).FirstOrDefault();
                Person targetPerson = sameRectangle.persons[new Random().Next(sameRectangle.persons.Count)];
                targetPerson.Infected= true;
                targetPerson.InfectedDays = 0;
            }

        }

        private void Drawline(RectanglePointer rectangle1, RectanglePointer rectangle2)
        {
            if (rectangle1 != rectangle2 && !Simulator.RunningSimulation && !(rectangle1.neighbours.Contains(rectangle2) && rectangle2.neighbours.Contains(rectangle1)))
            {
                var line = new Line();
                line.StartPoint = rectangle1.pointer;
                line.EndPoint = rectangle2.pointer;
                line.Stroke = Brushes.Black;
                line.StrokeThickness = 1;
                rectangle1.lines.Add(line);
                rectangle1.neighbours.Add(rectangle2);
                rectangle2.neighbours.Add(rectangle1);
                rectangle2.lines.Add(line);
                SimulationCanvas.Children.Add(line);
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

                if ((myX < 30.0 && myY < 30.0)  )
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
        public void createNewRandomGraph(int text,int minConnection=1, int MaxConnection = 3)
        {
            clearCanvas();
            for (int i = 0; i < text; i++)
            {
                Point newPoint = new Point(new Random().Next(0, 865-30), new Random().Next(0, 610-30));
                DrawRectangle(newPoint);
            }

            foreach (var rectangle in myRectanglesPoints)
            {
                for (int i = 0; i < new Random().Next(minConnection, MaxConnection-1); i++)
                {
                    Drawline(rectangle, myRectanglesPoints[new Random().Next(0, myRectanglesPoints.Count)]);
                }
            }
            //var result = CountTheHabitablehouses();
        }

        private void clearCanvas()
        {
            if(SimulationCanvas != null)
            {
                Simulator.RunningSimulation = false;
                SimulationCanvas.Children.Clear();
                rectangle1 = null;
                MyPoints.Clear();
                myRectanglesPoints.Clear();
            }
        }

    }   
}
