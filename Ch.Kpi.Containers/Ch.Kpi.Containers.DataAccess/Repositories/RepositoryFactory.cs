// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryFactory.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Repositories
{
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    public class RepositoryFactory : IRepositoryFactory
    {
        /// <summary>
        /// The data context.
        /// </summary>
        private readonly IMongoContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryFactory" /> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        public RepositoryFactory(IMongoContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IRepository<TEntity> CreateRepository<TEntity>()
            where TEntity : class
        {
            return new Repository<TEntity>(dataContext);
        }
    }
}
