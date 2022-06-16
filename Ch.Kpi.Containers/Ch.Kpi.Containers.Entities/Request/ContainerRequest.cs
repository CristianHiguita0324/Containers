// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerRequest.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ch.Kpi.Containers.Entities.Request
{
    public class ContainerRequest
    {
        /// <summary>
        /// Gets or sets the Budget.
        /// </summary>
        [Required(ErrorMessage = constants.BudgetRequired)]
        public double Budget { get; set; }

        /// <summary>
        /// Gets or sets the Containers.
        /// </summary>
        /// 
        [Required(ErrorMessage = constants.ContainerListRequired)]
        public List<Container> Containers { get; set; }    

    }
}
