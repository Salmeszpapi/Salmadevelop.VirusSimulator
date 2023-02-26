using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using VirusWPF.Models;

namespace VirusWPF.Windows
{
    /// <summary>
    /// Interaction logic for ShowPeaplesInNodeWindow.xaml
    /// </summary>
    public partial class ShowPeaplesInNodeWindow : Window
    {
        private static volatile ShowPeaplesInNodeWindow instance = null;
        private ShowPeaplesInNodeWindow() { InitializeComponent(); }
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
            //PeoplesCount = rectanglePointer.GetPersonCount();
            //Healthy = rectanglePointer.GetHealthyPersonCount();
            //Infected = rectanglePointer.GetInfectedPersonCount();
            //Dead = rectanglePointer.GetDeadPersonCount();
            //HouseTypeEnumHouseType = rectanglePointer.GetHouseType();
            this.DataContext = rectanglePointer;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }
    }
}
