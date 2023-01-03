using Simulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Model
{
    public class People : IPeople
    {
        public int ID { get; set; }
        public int Immunity { get; set; }
        public bool FullImmunity { get; set; }
        public int Friends { get; set; }
        public bool Mask { get; set; }
        public int Contagiousness { get; set; }
        public int ContagiousDays { get; set; }
        public bool Infecter { get; set; }
        public bool Dead { get; set; }
        public List<Int32>[] adjency;
        public People() 
        {
            
        }
    }
}
