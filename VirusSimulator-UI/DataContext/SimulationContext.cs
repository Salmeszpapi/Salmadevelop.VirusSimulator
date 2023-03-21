using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusSimulator_UI.Models;

namespace VirusSimulator_UI.DataContext
{
    internal class SimulationContext : DbContext
    {
        public SimulationContext():base("Data Source=localhostasd;Initial Catalog=Energy;Integrated Security=true;")
        {

        }

        public virtual DbSet<SimulationData> Simulation { get; set; }
        public virtual DbSet<SimulationRun> SimulationRun { get; set; }

    }
}
