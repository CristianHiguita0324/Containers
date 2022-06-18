// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainersController.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
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

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainersController"/> class.
        /// </summary>
        /// <param name="containerAplication"></param>
        public ContainersController(IContainerAplication containerAplication)
        {
            this.containerAplication = containerAplication;
        }

        /// <summary>
        /// resource to select the containers that are going to be dispatched
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
