using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusSimulator_UI.Models
{
    public class Viruses
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double ProbabilityToDead { get; set; }
        public double IncubationTime { get; set; }
        public double InfectionSeverity { get; set; }
    }
}
