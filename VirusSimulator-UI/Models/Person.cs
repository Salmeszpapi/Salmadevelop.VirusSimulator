using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public int Age { get; set; }
        public double Imunity { get; set; }

        public Person(int Id)
        {
            this.Id = Id;
            this.InfectedDays = 0;
            GenerateAge();
            GetInfectedWhenGenerated();

        }
        private void GetInfectedWhenGenerated()
        {
            if (new Random().NextDouble() < Simulator.InfectionChance * this.Imunity)
            {
                Infected = true;
                TimesInfected++;
            }
        }

        private void GenerateAge()
        {
            Age = new Random().Next(1,90);
            GenerateImunity();
        }

        private void GenerateImunity()
        {
            switch(Age)
            {
                case <= 18: 
                    Imunity = new Random().Next(1, 10) / 10.0;
                    break;
                case <= 40: 
                    Imunity = new Random().Next(4, 10) / 10.0;
                    break;
                case <= 65:
                    Imunity = new Random().Next(6, 10) / 10.0;
                    break;
                case <= 90:
                    Imunity = new Random().Next(8, 10) / 10.0;
                    break;

            }
        }
    }

}
