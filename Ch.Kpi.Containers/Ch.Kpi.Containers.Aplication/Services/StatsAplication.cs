// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatsAplication.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
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
