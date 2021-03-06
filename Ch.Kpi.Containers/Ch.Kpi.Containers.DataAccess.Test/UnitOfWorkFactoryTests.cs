// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWorkFactoryTests.cs" company="Microsoft">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Test
{
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    using Ch.Kpi.Containers.DataAccess.UoW;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// The unit of work factory tests.
    /// </summary>
    [TestClass]
    public class UnitOfWorkFactoryTests
    {
        /// <summary>
        /// The factory.
        /// </summary>
        private UnitOfWorkFactory factory;

        /// <summary>
        /// The mock data context.
        /// </summary>
        private Mock<IMongoContext> mockDataContext;

        /// <summary>
        /// The mock business context.
        /// </summary>
        private Mock<IRepositoryFactory> mockRepoFactory;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.mockDataContext = new Mock<IMongoContext>();
            this.mockRepoFactory = new Mock<IRepositoryFactory>();
            this.factory = new UnitOfWorkFactory(this.mockDataContext.Object, this.mockRepoFactory.Object);
        }

        /// <summary>
        /// Gets the unit of work should return unit of work with respository factory when initialized.
        /// </summary>
        [TestMethod]
        public void GetUnitOfWorkShouldReturnUnitOfWorkWithRespositoryFactoryWhenInitialized()
        {
            // Act
            using (var unitOfWork = this.factory.GetUnitOfWork())
            {
                // Assert
                Assert.IsNotNull(unitOfWork);
            }
        }
    }
}
