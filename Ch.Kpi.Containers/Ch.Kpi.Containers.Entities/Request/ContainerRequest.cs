// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerRequest.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
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
        [Range(0.1, double.MaxValue, ErrorMessage = "El valor debe ser positivo.")]
        public double Budget { get; set; }

        /// <summary>
        /// Gets or sets the Containers.
        /// </summary>
        /// 
        [Required(ErrorMessage = constants.ContainerListRequired)]
        public List<Container> Containers { get; set; }    

    }
}
