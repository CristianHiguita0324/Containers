// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatsDomain.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Ch.Kpi.Containers.Aplication.Interfaces
{
    using System.Threading.Tasks;
    public interface IStatsAplication
    {
        /// <summary>
        /// get the statistics Interface
        /// </summary>
        /// <returns></returns>
        Task<string> GetStatisticsAsync();
    }
}
