// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatsDomain.cs" company="CristianHiguita">
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
    using Newtonsoft.Json;
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
        /// the get statistics
        /// </summary>
        /// <returns>the Statistics</returns>
        /// <exception cref="TechnicalException"></exception>
        public async Task<string> getStatisticsAsync()
        {
            try
            {
                var statsRepository = this.unitOfWork.CreateRepository<Stats>();
                var listStats = await statsRepository.GetAll().ConfigureAwait(false);

                return listStats.Any() ? 
                    JsonConvert.SerializeObject(setResponseStats(listStats.ToList())):
                    constants.NoDataStatsError;
            }
            catch (Exception ex)
            {
                throw new TechnicalException($"{constants.DataConnectionError}  {ex.Message}");
            }
        }

        /// <summary>
        /// The set Response Stats
        /// </summary>
        /// <param name="listStats"></param>
        /// <returns></returns>
        private Stats setResponseStats(List<Stats> listStats)
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
