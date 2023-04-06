using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Sim_Web.Models
{
    public class SimulationRun
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateOfRun { get; set; }
        public string VirusName { get; set; }
        public string RectanglesWithPeople { get; set; }
        public string RectanglePointers { get; set; }
        public string Neighbours { get; set; }
    }
}
