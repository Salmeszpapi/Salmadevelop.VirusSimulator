using System.ComponentModel.DataAnnotations;

namespace Simulator_Web.Models
{
    public class SimulationRun
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateOfRun { get; set; }
        public string VirusName { get; set; }
    }
}
