// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Entities
{
    using System.ComponentModel.DataAnnotations;
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
        [Range(0.1, double.MaxValue, ErrorMessage = "El valor debe ser positivo.")]
        public double TransportCost { get; set; }

        /// <summary>
        /// The container price
        /// </summary>
        /// 
        [Required(ErrorMessage = constants.ContainerPriceRequired)]
        [Range(0.1, double.MaxValue, ErrorMessage = "El valor debe ser positivo.")]
        public double ContainerPrice { get; set; }

    }
}
