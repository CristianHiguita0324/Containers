// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerDomain.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Domain.Services
{
    using Ch.Kpi.Containers.Common.Exeptions;
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    using Ch.Kpi.Containers.Domain.Interfaces;
    using Ch.Kpi.Containers.Entities;
    using Ch.Kpi.Containers.Entities.Entities;
    using Ch.Kpi.Containers.Entities.Request;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ContainerDomain : IContainerDomain
    {
        /// <summary>
        /// The unit of work factory.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// The sumContainerPrice variable
        /// </summary>
        private double sumContainerPrice;

        /// <summary>
        /// response variable
        /// </summary>
        private  string response;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatsDomain"/> class.
        /// </summary>
        /// <param name="unitOfWorkFactoy"></param>
        public ContainerDomain(IUnitOfWorkFactory unitOfWorkFactoy)
        {
            this.unitOfWork = unitOfWorkFactoy.GetUnitOfWork();
            this.sumContainerPrice = 0;
            this.response = string.Empty;
        }

        /// <summary>
        /// the selectContainers
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<string> SelectContainersAsync(ContainerRequest request)
        {
            var list = request.Containers.OrderByDescending(x => x.ContainerPrice).ThenBy(x => x.TransportCost).ToList();

            if(request.Budget >= list.Min(x=> x.TransportCost))
            {
                (this.response, this.sumContainerPrice) = GetContainersToShip(list, request.Budget);

                await SaveStatsAsync(CreateStatsEntity(request, this.sumContainerPrice)).ConfigureAwait(false);
                return this.response;
            }
            return "El presupuesto enviado no alcanza a cubrir el valos minimo de envio";
            
          
        }

        /// <summary>
        /// get the best choice of containers to ship
        /// </summary>
        /// <param name="containerList"></param>
        /// <param name="budget"></param>
        /// <returns></returns>
        private (string,double) GetContainersToShip(List<Container> containerList, double budget)
        {
            double sumTransportCost = 0, sumContainerPrice = 0;
            var response = new StringBuilder();
            response.Append(constants.ContainersDispatchedMessage);

            containerList.ForEach(x =>
            {
                if (sumTransportCost < budget && (sumTransportCost + x.TransportCost) <= budget)
                {
                    sumTransportCost += x.TransportCost;
                    sumContainerPrice += x.ContainerPrice;
                    response.Append(constants.MiddleBar);
                    response.Append(x.Name);
                }
            });
            return (response.ToString(), sumContainerPrice);
        }
        /// <summary>
        /// The Set Stats to add mongoBd
        /// </summary>
        /// <param name="request"></param>
        /// <param name="sumContainerPrice"></param>
        /// <returns></returns>
        private Stats CreateStatsEntity(ContainerRequest request, double sumContainerPrice)
        {
            return new Stats()
            {
                BudgetUsed = request.Budget,
                ContainersDispatched = sumContainerPrice,
                ContainersNotDispatched = request.Containers.Sum(x => x.ContainerPrice) - sumContainerPrice
            };
        }

        /// <summary>
        /// Add new stats to mongo bd
        /// </summary>
        /// <param name="stats"></param>
        /// <returns></returns>
        /// <exception cref="TechnicalException"></exception>
        private async Task SaveStatsAsync(Stats stats)
        {
            try
            {
                var Statsrepository = this.unitOfWork.CreateRepository<Stats>();
                Statsrepository.Add(stats);
                await this.unitOfWork.Commit().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new TechnicalException($"{constants.DataConnectionError}  {ex.Message}");
            }
        }
    }
}
