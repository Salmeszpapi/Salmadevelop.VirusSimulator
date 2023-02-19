using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace VirusWPF.Models
{
    public class RectanglePointer
    {
        public string Id { get; set; }
        public Rectangle rectangle { get; set; }
        public Point pointer { get; set; }
        public TextBlock textBox = new TextBlock();
        public List<Line> lines = new List<Line>();
        public List<RectanglePointer> neighbours = new List<RectanglePointer>();
        public RectanglePointer(string Id, Rectangle rectangle, Point pointer) 
        {
            this.Id = Id;
            this.pointer = pointer;
            this.rectangle = rectangle; 
        }
    }
}
