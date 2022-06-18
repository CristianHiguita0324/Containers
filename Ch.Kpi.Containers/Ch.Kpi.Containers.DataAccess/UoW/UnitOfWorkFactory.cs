// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWorkFactory.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.UoW
{
    using Ch.Kpi.Containers.DataAccess.Interfaces;

    /// <summary>
    /// The unit of work factory.
    /// </summary>
    /// <seealso cref="IUnitOfWorkFactory" />
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        ///<summary>
        /// The data context.
        /// </summary>
        private readonly IMongoContext dataContext;

        /// <summary>
        /// The repository factory.
        /// </summary>
        private readonly IRepositoryFactory repositoryFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkFactory" /> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        /// <param name="repositoryFactory">The repository factory.</param>
        public UnitOfWorkFactory(IMongoContext dataContext, IRepositoryFactory repositoryFactory)
        {
            this.dataContext = dataContext;
            this.repositoryFactory = repositoryFactory;
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <returns>
        /// The unit of work.
        /// </returns>
        public IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(this.dataContext, this.repositoryFactory);
        }
    }
}
