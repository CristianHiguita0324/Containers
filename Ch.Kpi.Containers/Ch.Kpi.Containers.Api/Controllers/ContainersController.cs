using Ch.Kpi.Containers.DataAccess.Interfaces;
using Ch.Kpi.Containers.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ch.Kpi.Containers.Api.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : Controller
    {
        /// <summary>
        /// The unit of work factory.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        public ContainersController(IUnitOfWorkFactory unitOfWorkFactoy)
        {
            this.unitOfWork = unitOfWorkFactoy.GetUnitOfWork();
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
        public IActionResult selectContainers()
        {
            try
            {
               var repo = this.unitOfWork.CreateRepository<Container>();

                //repo.Add(new Container()
                //{
                //    ContainerPrice = 4744.03,
                //    TransportCost = 571.40,
                //    Name = "C1"
                //});

                //this.unitOfWork.Commit();

                var resp =  repo.GetAll();
                List<Container> containersReturn = new List<Container>();
                List<Container> containers = new List<Container>
                {
                    new Container(){
                        ContainerPrice =4744.03,
                        TransportCost = 571.40,
                        Name = "C1"
                        },

                    new Container(){
                        ContainerPrice =3579.07,
                        TransportCost = 537.33,
                        Name = "C2"
                        },

                    new Container(){
                        ContainerPrice =1379.26,
                        TransportCost = 434.66,
                        Name = "C3"
                        },

                    new Container(){
                        ContainerPrice =1700.12,
                        TransportCost = 347.28,
                        Name = "C4"
                        },

                    new Container(){
                        ContainerPrice =1434.80,
                        TransportCost = 264.54,
                        Name = "C5"
                        },
                };
                double costoMaximo = 1508.65;

                var list = containers.OrderByDescending(x => x.ContainerPrice).ThenBy(x=> x.TransportCost).ToList();

                foreach (var item in list)
                {
                    if(containersReturn.Sum(x=> x.TransportCost) < costoMaximo && (containersReturn.Sum(x => x.TransportCost)+item.TransportCost)<=costoMaximo)
                    {
                        containersReturn.Add(item);
                    }
                }
                return Ok(containersReturn);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
