using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusSimulator_UI.Models
{
    public class SimulationRun
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateOfRun { get; set; }
    }
}
