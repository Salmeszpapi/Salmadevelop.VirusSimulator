using System.ComponentModel.DataAnnotations;

namespace Sim_Web.Models
{
    public class Virus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double ProbabilityToDead { get; set; }
        public double IncubationTime { get; set; }
        public double InfectionSeverity { get; set; }
        public double ProbabilityToCure{ get; set; }
    }
}
