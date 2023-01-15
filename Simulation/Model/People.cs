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
        public int Age { get; set; }
        public int Immunity { get; set; }
        public bool FullImmunity { get; set; }
        public int Friends { get; set; }
        public bool Mask { get; set; }
        public bool Infected { get; set; }
        public int Contagiousness { get; set; }
        public int ContagiousDays { get; set; }
        public bool Dead { get; set; }
        public List<int> FriendsList;
        public People(int id) 
        {
            ID = id;
            initialization();
        }
        private void initialization()
        {
            Dead = false;
            Friends = new Random().Next(10);
            Age = new Random().Next(100);

            if (new Random().Next(100) < 2) 
            { 
                Infected = true;
                Contagiousness = 10;
                ContagiousDays = 10;
            }
            else
            {
                Infected = false;
                Contagiousness = 0;
                ContagiousDays = 0;
            }
        }
    }
}
