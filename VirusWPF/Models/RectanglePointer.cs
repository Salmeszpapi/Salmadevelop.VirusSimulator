using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace VirusWPF.Models
{
    class RectanglePointer
    {
        public string Id { get; set; }
        public Rectangle rectangle { get; set; }
        public Point pointer { get; set; }
        public bool Removable { get; set; }
        public RectanglePointer(string Id, Rectangle rectangle, Point pointer) 
        {
            this.Id = Id;
            this.pointer = pointer;
            this.rectangle = rectangle; 
        }
        

    }
}
