// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContainerDomain.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Domain.Interfaces
{
    using Ch.Kpi.Containers.Entities.Request;
    using System.Threading.Tasks;
    public interface IContainerDomain
    {
        /// <summary>
        /// The Select Containers Interface
        /// </summary>
        /// <returns></returns>
        Task<string> SelectContainersAsync(ContainerRequest request);
    }
}
