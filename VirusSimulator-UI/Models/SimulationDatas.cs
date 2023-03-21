using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusSimulator_UI.Models
{
    public class SimulationData
    {
        [Key]
        public int Id { get; set; }
        public int AllPeople { get; set; }
        public int AllHealthyPeoples { get; set; }
        public int AllInfectedPeoples { get; set; }
        public int AllDeadPeoples { get; set; }
    }
}
