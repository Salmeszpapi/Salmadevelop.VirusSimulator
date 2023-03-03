using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
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
    /// Interaction logic for ShowPeaplesInNodeWindow.xaml
    /// </summary>
    public partial class ShowPeaplesInNodeWindow : Window, INotifyPropertyChanged
    {
        private static volatile ShowPeaplesInNodeWindow instance = null;
        private ShowPeaplesInNodeWindow() { InitializeComponent(); }

        public event PropertyChangedEventHandler? PropertyChanged;
        public int PeoplesCount;
        public int HealthyCount;
        public int InfectedCount;
        public int DeadCount;
        public int PeopleIdcounter;
        public int IdRectangle;

        private void SetPeoplesCount(int count)
        {
            PeoplesCount = count;
            OnPropertyChanged();
        }

        public int SAD
        {
            get { return PeoplesCount; }
            set
            {
                PeoplesCount = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public int GetPeoplesCount()
        {
            return PeoplesCount;
        }

        private void SetHealthyCount(int count)
        {
            HealthyCount = count;
            OnPropertyChanged();
        }
        private void SetInfectedCount(int count)
        {
            InfectedCount = count;
            OnPropertyChanged();
        }

        private void SetDeadCount(int count)
        {
            DeadCount = count;
            OnPropertyChanged();
        }

        private void SetPeopleIdcounter(int count)
        {
            PeopleIdcounter = count;
            OnPropertyChanged();
        }

        public static ShowPeaplesInNodeWindow getInstance()
        {
            if(instance == null)
            {
                instance = new ShowPeaplesInNodeWindow();
            }
            return instance;
        }
        public void SetPointer(RectanglePointer rectanglePointer)
        {
            SetPeopleIdcounter(rectanglePointer.PeopleIdcounter);
            SetDeadCount(rectanglePointer.DeadCount);
            SetInfectedCount(rectanglePointer.InfectedCount);
            SetHealthyCount(rectanglePointer.HealthyCount);
            SetPeoplesCount(rectanglePointer.PeoplesCount);
            this.DataContext = this;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
