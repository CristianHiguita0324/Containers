// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerAplication.cs" company="CristianHiguita">
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
    using Ch.Kpi.Containers.Entities.Request;
    using System;
    using System.Threading.Tasks;
    public class ContainerAplication : IContainerAplication
    {
        /// <summary>
        /// The IContainerDomain
        /// </summary>
        private readonly IContainerDomain containerDomain;

        public ContainerAplication(IContainerDomain containerDomain)
        {
            this.containerDomain = containerDomain;
        }

    
        /// <summary>
        /// The selectContainers
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<string> selectContainersAsync(ContainerRequest request)
        {
            return await this.containerDomain.selectContainersAsync(request).ConfigureAwait(false);
        }
    }
}
