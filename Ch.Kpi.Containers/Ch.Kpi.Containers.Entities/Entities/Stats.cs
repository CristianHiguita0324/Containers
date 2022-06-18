// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Stats.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Entities.Entities
{
    public class Stats
    {
        /// <summary>
        /// The containers dispatched
        /// </summary>
        public double ContainersDispatched { get; set; }

        /// <summary>
        /// The containers not dispatched
        /// </summary>
        public double ContainersNotDispatched { get; set; }

        /// <summary>
        /// The budget used
        /// </summary>
        public double BudgetUsed { get; set; }
    }
}
