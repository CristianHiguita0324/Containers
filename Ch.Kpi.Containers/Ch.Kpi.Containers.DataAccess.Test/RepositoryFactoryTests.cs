// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryFactoryTests.cs" company="CristiaHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Test
{
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    using Ch.Kpi.Containers.DataAccess.Repositories;
    using Ch.Kpi.Containers.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// The repository factory tests.
    /// </summary>
    [TestClass]
    public class RepositoryFactoryTests
    {
        /// <summary>
        /// The repository.
        /// </summary>
        private RepositoryFactory factory;

        /// <summary>
        /// The mock data context.
        /// </summary>
        private Mock<IMongoContext> mockDataContext;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.mockDataContext = new Mock<IMongoContext>();

            this.factory = new RepositoryFactory(this.mockDataContext.Object);
        }

        /// <summary>
        /// Creates the repository should create repository with data access.
        /// </summary>
        [TestMethod]
        public void CreateRepositoryShouldCreateRepositoryWithDataAccess()
        {
            // Act
            var repository = this.factory.CreateRepository<Container>();

            // Assert
            Assert.IsNotNull(repository);
        }
    }
}
