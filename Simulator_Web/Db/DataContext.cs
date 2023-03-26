using Microsoft.EntityFrameworkCore;
using Simulator_Web.Models;

namespace Simulator_Web.Db
{
    public class DataContext : DbContext
    {

        public DbSet<SimulationRun> simulationRuns => Set<SimulationRun>();
        public DbSet<SimulationData> simulationDatas => Set<SimulationData>();

        public DataContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Diploma\\ApplicationCore\\Simulator_Web\\Db\\sqlite.db");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var dbPath = Path.Combine(Simulator_Web.Current.LocalFolder.Path, "YourDbName.db");
        //    optionsBuilder.UseSqlite("Filename = " + dbPath);
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
