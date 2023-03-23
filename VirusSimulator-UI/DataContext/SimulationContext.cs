using System.Data.Entity;
using VirusSimulator_UI.Models;

namespace VirusSimulator_UI.DataContext
{
    public class SimulationContext : DbContext
    {
        public DbSet<SimulationRun> MySimulationRun  { get; set; }
        public DbSet<SimulationData> MySimulationData { get; set; }
    }
}
