// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatsController.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Api.Controllers
{
    using Ch.Kpi.Containers.Aplication.Interfaces;
    using Ch.Kpi.Containers.Common.Exeptions;
    using Ch.Kpi.Containers.Entities.Entities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : Controller
    {
        /// <summary>
        /// the stats Aplication
        /// </summary>
        private readonly IStatsAplication statsAplication;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatsController"/> class.
        /// </summary>
        /// <param name="statsAplication"></param>
        public StatsController(IStatsAplication statsAplication)
        {
            this.statsAplication = statsAplication;
        }

        /// <summary>
        /// get the cumulative value of shipped and unshipped containers
        /// </summary>
        /// <returns></returns>
        [HttpGet("Stats")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Stats))]
        [ProducesResponseType(500)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> StatsAsync()
        {
            try
            {
                return StatusCode((int)StatusCodes.Status200OK, await statsAplication.GetStatisticsAsync().ConfigureAwait(false));
            }
            catch (TechnicalException ex)
            {
                return StatusCode((int)StatusCodes.Status409Conflict, ex.Message.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode((int)StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
