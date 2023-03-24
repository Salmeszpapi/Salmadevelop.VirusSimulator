using Microsoft.EntityFrameworkCore;
using Simulator_Web.Models;

namespace Simulator_Web.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<SimulationRun> simulationRuns => Set<SimulationRun>();
        public DbSet<SimulationData> simulationDatas => Set<SimulationData>();
    }
}
