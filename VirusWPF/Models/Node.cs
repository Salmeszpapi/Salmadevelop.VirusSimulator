using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusWPF.Models
{
    internal class Node
    {
        public string Id { get; set; }
        public int MaxPerson { get; set; }
        public List<string> neighbours = new List<string>();
        public List<Node> neighbourNodes = new List<Node>();
        public Node(RectanglePointer rectanglePointer) 
        {
            Id = rectanglePointer.Id;
            nodeNeighbours(rectanglePointer);
        }
        private void nodeNeighbours(RectanglePointer rectanglePointer)
        {
            foreach(var neighbour in rectanglePointer.neighbours) 
            {
                neighbours.Add(neighbour.Id);
            }
        }
    }
}
