using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusSimulator_UI.Models;

namespace VirusSimulator_UI.DataContext
{
    internal class SimulationContext : DbContext
    {
        public SimulationContext()
         : base("name=SimulationDbConnection")
        {
            this.Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<SimulationData> Simulation { get; set; }
        public virtual DbSet<SimulationRun> SimulationRun { get; set; }

    }
}
