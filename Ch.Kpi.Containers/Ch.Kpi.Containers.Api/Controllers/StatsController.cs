using Ch.Kpi.Containers.Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ch.Kpi.Containers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : Controller
    {
        private readonly IStatsAplication statsAplication;

        public StatsController(IStatsAplication statsAplication)
        {
            this.statsAplication = statsAplication;
        }
        /// <summary>
        /// selectContainers
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [ProducesResponseType(504)]
        public async Task<string> selectContainers()
        {
            try
            {
                return await this.statsAplication.getStatistics();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError).ToString();
            }
        }
    }
}
