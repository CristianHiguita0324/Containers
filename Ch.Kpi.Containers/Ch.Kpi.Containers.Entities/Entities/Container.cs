﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace Ch.Kpi.Containers.Entities
{
    public class Container
    {
        /// <summary>
        /// The container name
        /// </summary>
        [Required(ErrorMessage = constants.ContainerNameRequired)]
        public string Name { get; set; }

        /// <summary>
        /// The transport cost
        /// </summary>
        
        [Required(ErrorMessage = constants.TransportCostRequired)]
        public double TransportCost { get; set; }

        /// <summary>
        /// The container price
        /// </summary>
        /// 
        [Required(ErrorMessage = constants.ContainerPriceRequired)]
        public double ContainerPrice { get; set; }

    }
}
