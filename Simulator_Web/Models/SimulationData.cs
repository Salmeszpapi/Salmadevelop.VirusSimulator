using System.ComponentModel.DataAnnotations;

namespace Simulator_Web.Models
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
