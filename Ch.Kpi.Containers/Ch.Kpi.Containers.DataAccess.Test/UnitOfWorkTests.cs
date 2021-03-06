// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWorkTests.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Test
{
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    using Ch.Kpi.Containers.DataAccess.UoW;
    using Ch.Kpi.Containers.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Threading.Tasks;

    /// <summary>
    /// The unit of work tests.
    /// </summary>
    [TestClass]
    public class UnitOfWorkTests
    {
        /// <summary>
        /// The unit of work instance.
        /// </summary>
        private UnitOfWork unitOfWork;

        /// <summary>
        /// The mock data context.
        /// </summary>
        private Mock<IMongoContext> mockDataContext;

        /// <summary>
        /// The mock repository factory.
        /// </summary>
        private Mock<IRepositoryFactory> mockRepositoryFactory;

        [TestInitialize]
        public void Initialize()
        {
            this.mockDataContext = new Mock<IMongoContext>();
            this.mockRepositoryFactory = new Mock<IRepositoryFactory>();
            this.unitOfWork = new UnitOfWork(this.mockDataContext.Object, this.mockRepositoryFactory.Object);
        }

        /// <summary>
        /// Creates the repository should create repository from repository factory when invoked.
        /// </summary>
        [TestMethod]
        public void CreateRepositoryShouldCreateRepositoryFromRepositoryFactoryWhenInvoked()
        {
            // Arrange
            var repo = new Mock<IRepository<Container>>();
            this.mockRepositoryFactory.Setup(f => f.CreateRepository<Container>()).Returns(repo.Object);

            // Act
            var categoryRepository = this.unitOfWork.CreateRepository<Container>();

            // Assert
            Assert.IsNotNull(categoryRepository);
            this.mockRepositoryFactory.Verify(f => f.CreateRepository<Container>(), Times.Once);
        }

        /// <summary>
        /// Saves the asynchronous should save using data context when invoked.
        /// </summary>
        /// <returns>
        /// The task.
        /// </returns>
        [TestMethod]
        public async Task SaveAsyncShouldSaveUsingDataContextWhenInvokedAsync()
        {
            // Arrange
            this.mockDataContext.Setup(m => m.SaveChanges()).ReturnsAsync(1);

            // Act
            var result = await unitOfWork.Commit().ConfigureAwait(false);

            // Asert
            Assert.AreEqual(true, result);
            this.mockDataContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DisposeShouldDisposeDataContextWhenInvoked()
        {
            // Arange
            this.mockDataContext.Setup(m => m.Dispose());

            // Act
            this.unitOfWork.Dispose();

            // Assert
            this.mockDataContext.Verify(m => m.Dispose(), Times.Once);
        }
    }
}
