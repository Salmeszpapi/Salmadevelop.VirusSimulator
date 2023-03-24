using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Simulation_Web.Models;

namespace Simulation_Web.Db
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
