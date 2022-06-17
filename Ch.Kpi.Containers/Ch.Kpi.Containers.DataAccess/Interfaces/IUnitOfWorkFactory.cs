// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWorkFactory.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Interfaces
{
    /// <summary>
    /// The unit of work factory.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <returns>The unit of work.</returns>
        IUnitOfWork GetUnitOfWork();
    }
}
