using Avalonia;
using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusSimulator_UI.Models
{
    public class SaveRectangle
    {
        public int Id { get; set; }
        public Point pointer { get; set; }
        public List<Line> lines = new List<Line>();
        public int PeoplesCount { get; set; }
        public int HealthyCount { get; set; }
        public int InfectedCount { get; set; }
        public int DeadCount { get; set; }
        public int PeopleIdcounter { get; set; }
    }
}
