// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatsDomain.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Domain.Services
{
    using Ch.Kpi.Containers.Common;
    using Ch.Kpi.Containers.Common.Exeptions;
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    using Ch.Kpi.Containers.Domain.Interfaces;
    using Ch.Kpi.Containers.Entities;
    using Ch.Kpi.Containers.Entities.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class StatsDomain : IStatsDomain
    {
        /// <summary>
        /// The unit of work factory.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatsDomain"/> class.
        /// </summary>
        /// <param name="unitOfWorkFactoy"></param>
        public StatsDomain(IUnitOfWorkFactory unitOfWorkFactoy)
        {
            this.unitOfWork = unitOfWorkFactoy.GetUnitOfWork();
        }

        /// <summary>
        /// obtains the accumulated value of the shipped and unshipped containers
        /// </summary>
        /// <returns>the Statistics</returns>
        /// <exception cref="TechnicalException"></exception>
        public async Task<string> GetStatisticsAsync()
        {
            try
            {
                var listStats = await GetStatsAsync().ConfigureAwait(false);

                return this.SerializeResponse(listStats);
            }
            catch (Exception ex)
            {
                throw new TechnicalException($"{constants.DataConnectionError}  {ex.Message}");
            }
        }

        /// <summary>
        /// deserializes the entity and returns it in string
        /// </summary>
        /// <param name="listStats"></param>
        /// <returns></returns>
        private string SerializeResponse(IEnumerable<Stats> listStats)
        {
            return listStats.Any() ?
                   Extensions.SerializeObject((object)SetResponseStats(listStats)) :
                   constants.NoDataStatsError;
        }

        /// <summary>
        /// get all the records of the statistics table
        /// </summary>
        /// <returns>List Stats</returns>
        private async Task<IEnumerable<Stats>> GetStatsAsync()
        {
            var statsRepository = this.unitOfWork.CreateRepository<Stats>();
            return await statsRepository.GetAll().ConfigureAwait(false);
        }

        /// <summary>
        /// The set Response Stats
        /// </summary>
        /// <param name="listStats"></param>
        /// <returns></returns>
        private Stats SetResponseStats(IEnumerable<Stats> listStats)
        {
            return new Stats()
            {
                BudgetUsed = listStats.Sum(x => x.BudgetUsed),
                ContainersNotDispatched = listStats.Sum(x => x.ContainersNotDispatched),
                ContainersDispatched = listStats.Sum(x => x.ContainersDispatched)
            };
        }
    }
}
