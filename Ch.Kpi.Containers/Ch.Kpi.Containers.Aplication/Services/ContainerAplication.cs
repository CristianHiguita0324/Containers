// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerAplication.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Aplication.Services
{
    using Ch.Kpi.Containers.Aplication.Interfaces;
    using Ch.Kpi.Containers.Domain.Interfaces;
    using Ch.Kpi.Containers.Entities.Request;
    using System.Threading.Tasks;
    public class ContainerAplication : IContainerAplication
    {
        /// <summary>
        /// The IContainerDomain
        /// </summary>
        private readonly IContainerDomain containerDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerAplication"/> class.
        /// </summary>
        /// <param name="containerDomain"></param>
        public ContainerAplication(IContainerDomain containerDomain)
        {
            this.containerDomain = containerDomain;
        }

        /// <summary>
        /// The selectContainers
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<string> SelectContainersAsync(ContainerRequest request)
        {
            return await this.containerDomain.SelectContainersAsync(request).ConfigureAwait(false);
        }
    }
}
