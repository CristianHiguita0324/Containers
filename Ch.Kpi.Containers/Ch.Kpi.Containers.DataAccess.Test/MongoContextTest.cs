// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MongoContextTest.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Test
{
    using Ch.Kpi.Containers.DataAccess.Context;
    using Ch.Kpi.Containers.Entities.Configuration;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using Moq;
    using System.Threading.Tasks;

    /// <summary>
    /// The repository factory tests.
    /// </summary>
    [TestClass]
    public class MongoContextTest
    {
        /// <summary>
        /// The MongoContext.
        /// </summary>
        private MongoContext mongoContex;

        /// <summary>
        /// The mock IMongoDatabase.
        /// </summary>
        private Mock<IMongoDatabase> mockMongoDatabase;

        /// <summary>
        /// The mock IClientSessionHandle.
        /// </summary>
        private Mock<IClientSessionHandle> mockClientSessionHandle;

        /// <summary>
        /// The mock IConfiguration.
        /// </summary>
        private Mock<IConfiguration> mockConfiguration;

        /// <summary>
        /// The mock MongoClient.
        /// </summary>
        private Mock<MongoClient> mockMongoClient;


        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.mockMongoDatabase = new Mock<IMongoDatabase>();
            this.mockConfiguration = new Mock<IConfiguration>();
            this.mockClientSessionHandle = new Mock<IClientSessionHandle>();
            this.mockMongoClient = new Mock<MongoClient>();

            this.mongoContex = new MongoContext(this.mockConfiguration.Object);
        }

        /// <summary>
        /// ShouldInvoqueDispose.
        /// </summary>
        [TestMethod]
        public void ShouldInvoqueDispose()
        {
            // Arrange
            // Act
            this.mongoContex.Dispose();
        }

        /// <summary>
        /// ShouldInvoqueAddCommand.
        /// </summary>
        [TestMethod]
        public void ShouldInvoqueAddCommand()
        {
            // Arrange
            // Act
            this.mongoContex.AddCommand(() => NewTask());
        }

        /// <summary>
        /// Creates the repository should create repository with data access.
        /// </summary>
        [TestMethod]
        public void ShouldInvoqueSaveChanges()
        {
            // Act
            this.mongoContex.Dispose();
        }

        private Task NewTask()
        {
            return Task.CompletedTask;
        }
    }
}
