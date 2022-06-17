// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStatsDomain.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Domain.Interfaces
{
    using System.Threading.Tasks;
    public interface IStatsDomain
    {
        /// <summary>
        /// get the statistics Interface
        /// </summary>
        /// <returns></returns>
        Task<string> GetStatisticsAsync();
    }
}
