// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatsAplication.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre






// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Aplication.Services
{
    using Ch.Kpi.Containers.Aplication.Interfaces;
    using Ch.Kpi.Containers.Domain.Interfaces;
    using System.Threading.Tasks;

    public class StatsAplication : IStatsAplication
    {
        /// <summary>
        /// The stats domain 
        /// </summary>
        private readonly IStatsDomain statsDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatsAplication"/> class.
        /// </summary>
        /// <param name="statsDomain"></param>
        public StatsAplication(IStatsDomain statsDomain)
        {
            this.statsDomain = statsDomain;
        }

        /// <summary>
        /// get stadistics 
        /// </summary>
        /// <returns>string</returns>
        public async Task<string> GetStatisticsAsync()
        {
            return await this.statsDomain.GetStatisticsAsync().ConfigureAwait(false);
        }
    }
}
