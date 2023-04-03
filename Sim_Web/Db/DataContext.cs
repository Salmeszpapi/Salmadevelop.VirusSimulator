using Microsoft.EntityFrameworkCore;
using Sim_Web.Models;
using System.Collections.Generic;

namespace Sim_Web.Db
{
    public class DataContext : DbContext
    {
        public string pathOfDb { get; set; }
        public DbSet<SimulationRun> simulationRuns => Set<SimulationRun>();
        public DbSet<SimulationData> simulationDatas => Set<SimulationData>();
        public DbSet<LoginData> loginDatas => Set<LoginData>();
        public DbSet<Virus> VirusData => Set<Virus>();

        public DataContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            pathOfDb = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            SetPath();
            optionsBuilder.UseSqlite($"Data Source={pathOfDb}\\Sim_Web\\Db\\sqlite.db");
        }
        public void SetPath()
        {
            if (pathOfDb.Contains("Debug"))
            {
                pathOfDb =  Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            }
        }
    }
}
