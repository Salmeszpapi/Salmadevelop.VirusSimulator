using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusSimulator_UI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public bool Infected { get; set; } = false;
        public bool Dead { get; set; } = false;
        public int InfectedDays { get; set; }
        //public int Immunity { get; set; }
        public int TimesInfected { get; set; }
        public Person(int Id)
        {
            this.Id = Id;
            this.InfectedDays = 0;
            GetInfectedWhenGenerated();
        }
        private void GetInfectedWhenGenerated()
        {
            if (new Random().NextDouble() < Simulator.InfectionChance)
            {
                Infected = true;
                TimesInfected++;
            }
        }
    }
}
