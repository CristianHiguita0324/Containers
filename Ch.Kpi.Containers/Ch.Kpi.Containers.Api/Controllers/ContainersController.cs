// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainersController.cs" company="CristianHiguita">
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
    using Ch.Kpi.Containers.Entities.Request;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : Controller
    {
        /// <summary>
        /// The IContainerAplication.
        /// </summary>
        private readonly IContainerAplication containerAplication;

        public ContainersController(IContainerAplication containerAplication)
        {
            this.containerAplication = containerAplication;
        }

        /// <summary>
        /// selectContainers
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        [HttpGet("SelectContainers")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> SelectContainersAsync([FromBody] ContainerRequest request)
        {
            try
            {
                return StatusCode((int)StatusCodes.Status200OK, await this.containerAplication.SelectContainersAsync(request).ConfigureAwait(false));
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
