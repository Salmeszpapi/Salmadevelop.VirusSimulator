using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using VirusWPF.Models;

namespace VirusWPF.Windows
{
    /// <summary>
    /// Interaction logic for TestDatacontextxaml.xaml
    /// </summary>
    public partial class TestDatacontextxaml : Window, INotifyPropertyChanged
    {
        private RectanglePointer RectanglePointer;
        private int PeoplesCount;
        private int HealthyCount;
        private int InfectedCount;
        //private int DeadCount;
        private int PeopleIdcounter;
        public int IdRectangle { get;  set; }
        public int DeadCount { get { return DeadCount; } private set { } }

        public TestDatacontextxaml(RectanglePointer rectanglePointer)
        {
            InitializeComponent();
            IdRectangle = rectanglePointer.InfectedCount;
            this.RectanglePointer1 = rectanglePointer;
            this.DataContext = this;
            OnPropertyChanged();
        }

        public RectanglePointer RectanglePointer1 { get => RectanglePointer; set => RectanglePointer = value; }
        public int PeoplesCount1 { get => PeoplesCount; set => PeoplesCount = value; }
        public int HealthyCount1 { get => HealthyCount; set => HealthyCount = value; }
        public int InfectedCount1 { get => InfectedCount; set => InfectedCount = value; }
        public int DeadCount1 { get => DeadCount; set => DeadCount = value; }
        public int PeopleIdcounter1 { get => PeopleIdcounter; set => PeopleIdcounter = value; }
        public int IdRectangle1 { get => IdRectangle; set => IdRectangle = value; }

        public int PersonNameCount
        {
            get { return InfectedCount; }
            set
            {
                InfectedCount = value;
                // Call OnPropertyChanged whenever the property is updated
                
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
