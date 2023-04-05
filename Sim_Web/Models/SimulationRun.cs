using System.ComponentModel.DataAnnotations;

namespace Sim_Web.Models
{
    public class SimulationRun
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateOfRun { get; set; }
        public string VirusName { get; set; }
        public string RectanglesWithPeople { get; set; }
    }
}
