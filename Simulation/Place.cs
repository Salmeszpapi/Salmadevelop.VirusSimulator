using Simulation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    public class Place
    {
        public int ID { get; set; }
        public List<int> AdjencyNodes { get; set; }
        public int MaxPeople { get; set; }
        public List<People> peoples { get; set; }
        public int MaxPeoples { get; set; }

        public Place() 
        {

        }

    }
}
