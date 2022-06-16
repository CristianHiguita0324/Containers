// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContainerDomain.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Ch.Kpi.Containers.Entities.Request;
using System.Threading.Tasks;

namespace Ch.Kpi.Containers.Domain.Interfaces
{
    public interface IContainerDomain
    {
        /// <summary>
        /// get the statistics
        /// </summary>
        /// <returns></returns>
        Task<string> selectContainersAsync(ContainerRequest request);
    }
}
