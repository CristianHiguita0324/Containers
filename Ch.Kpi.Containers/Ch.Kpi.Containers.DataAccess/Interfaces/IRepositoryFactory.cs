// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryFactory.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Ch.Kpi.Containers.DataAccess.Interfaces
{
    /// <summary>
    /// The repository factory.
    /// </summary>
    public interface IRepositoryFactory
    {

        /// <summary>
        /// Creates the repository.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>
        /// The repository.
        /// </returns>
        IRepository<TEntity> CreateRepository<TEntity>()
            where TEntity : class;
    }
}