using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simulator_Web.Db;
using Simulator_Web.Models;

namespace Simulator_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _dataContext1;
        public ValuesController()
        {
            _dataContext1 = new DataContext();
        }
        [HttpPost]
        public async Task<ActionResult<List<SimulationRun>>> AddSomething()
        {
            _dataContext1.simulationRuns.Add(new SimulationRun()
            {
                DateOfRun = DateTime.Now,
            });
            _dataContext1.SaveChanges();

            return Ok(_dataContext1.simulationRuns.ToListAsync());
        }
    }
}
