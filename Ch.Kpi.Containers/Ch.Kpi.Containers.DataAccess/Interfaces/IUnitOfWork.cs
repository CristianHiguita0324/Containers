// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Interfaces
{
    using System;
    using System.Threading.Tasks;
    public interface IUnitOfWork : IDisposable
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

        /// <summary>
        /// The commit
        /// </summary>
        /// <returns>bool</returns>
        Task<bool> Commit();
    }
}