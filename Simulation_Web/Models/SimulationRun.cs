using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_Web.Models
{
    public class SimulationRun
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateOfRun { get; set; }
    }
}
