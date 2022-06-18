// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Ch.Kpi.Containers.DataAccess.UoW
{
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    using System;
    using System.Threading.Tasks;
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The Mongo data base context
        /// </summary>
        private readonly IMongoContext context;

        /// <summary>
        /// The repository factory.
        /// </summary>
        private readonly IRepositoryFactory repositoryFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="repositoryFactory"></param>
        public UnitOfWork(IMongoContext context, IRepositoryFactory repositoryFactory)
        {
            this.context = context;
            this.repositoryFactory = repositoryFactory;
        }

        /// <inheritdoc/>
        public IRepository<TEntity> CreateRepository<TEntity>()
            where TEntity : class
        {
            return this.repositoryFactory.CreateRepository<TEntity>();
        }

        /// <inheritdoc/>
        public async Task<bool> Commit()
        {
            var changeAmount = await context.SaveChanges().ConfigureAwait(false);

            return changeAmount > 0;
        }

        private bool disposed = false;

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
