using Microsoft.EntityFrameworkCore;
using Sim_Web.Models;
using System.Collections.Generic;

namespace Sim_Web.Db
{
    public class DataContext : DbContext
    {

        public DbSet<SimulationRun> simulationRuns => Set<SimulationRun>();
        public DbSet<SimulationData> simulationDatas => Set<SimulationData>();
        public DbSet<LoginData> loginDatas => Set<LoginData>();

        public DataContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Diploma\\ApplicationCore\\Sim_Web\\Db\\sqlite.db");
        }
    }
}
