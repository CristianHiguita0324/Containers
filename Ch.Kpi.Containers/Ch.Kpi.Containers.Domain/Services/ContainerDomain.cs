// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerDomain.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
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
        /// Initializes a new instance of the <see cref="StatsDomain"/> class.
        /// </summary>
        /// <param name="unitOfWorkFactoy"></param>
        public ContainerDomain(IUnitOfWorkFactory unitOfWorkFactoy)
        {
            this.unitOfWork = unitOfWorkFactoy.GetUnitOfWork();
        }

        /// <summary>
        /// the selectContainers
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<string> selectContainersAsync(ContainerRequest request)
        {
            var list = request.Containers.OrderByDescending(x => x.ContainerPrice).ThenBy(x => x.TransportCost).ToList();

            double sumTransportCost = 0, sumContainerPrice = 0;
            var response = new StringBuilder();
            response.Append(constants.ContainersDispatchedMessage);
            foreach (var item in list)
            {
                if (sumTransportCost < request.Budget && (sumTransportCost + item.TransportCost) <= request.Budget)
                {
                    sumTransportCost+= item.TransportCost;
                    sumContainerPrice+=item.ContainerPrice;
                    response.Append(constants.MiddleBar);
                    response.Append(item.Name);
                }
            }
            
            await setStatsAsync(SetStats(request , sumContainerPrice)).ConfigureAwait(false);
            return response.ToString();
        }

        /// <summary>
        /// The Set Stats to add mongoBd
        /// </summary>
        /// <param name="request"></param>
        /// <param name="sumContainerPrice"></param>
        /// <returns></returns>
        private Stats SetStats(ContainerRequest request, double sumContainerPrice)
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
        private async Task setStatsAsync(Stats stats)
        {
            try
            {
                var repository = this.unitOfWork.CreateRepository<Stats>();
                repository.Add(stats);
                await this.unitOfWork.Commit().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new TechnicalException($"{constants.DataConnectionError}  {ex.Message}");
            }
        }
    }
}
