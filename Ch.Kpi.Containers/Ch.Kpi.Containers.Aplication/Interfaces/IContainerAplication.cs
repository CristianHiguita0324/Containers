// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContainerAplication.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Aplication.Interfaces
{
    using Ch.Kpi.Containers.Entities.Request;
    using System.Threading.Tasks;
    public interface IContainerAplication
    {
        /// <summary>
        /// Select Containers Interface
        /// </summary>
        /// <returns></returns>
        Task<string> SelectContainersAsync(ContainerRequest request); 
    }
}
