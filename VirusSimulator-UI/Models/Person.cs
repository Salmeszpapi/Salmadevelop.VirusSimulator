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
        public Person(int Id)
        {
            this.Id = Id;
        }

    }
}
