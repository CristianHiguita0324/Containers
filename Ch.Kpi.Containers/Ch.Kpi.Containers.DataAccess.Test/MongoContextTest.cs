// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MongoContextTest.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------



namespace Ch.Kpi.Containers.DataAccess.Test
{
    using Ch.Kpi.Containers.DataAccess.Context;
    using Ch.Kpi.Containers.Entities.Configuration;
    using Ch.Kpi.Containers.Entities.Entities;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using Moq;
    using System;
    using System.Collections.Generic;
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
            this.mockMongoClient.Setup(x => x.Settings);
            // Act
            this.mongoContex.AddCommand(() => NewTask());
        }

        /// <summary>
        /// ShouldInvoqueDispose.
        /// </summary>
        [TestMethod]
        public void ShouldInvoqueGetCollection()
        {
            // Arrange
            Mock<IConfigurationSection> mockSection = new Mock<IConfigurationSection>();
            mockSection.Setup(x => x.Value).Returns("ConfigValue");

            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(x => x.GetSection(It.Is<string>(k => k == ConfigurationConstants.ConnectionString))).Returns(mockSection.Object);

            this.mockMongoClient.Setup(x=>x.Settings.)
            // Act
            this.mongoContex.GetCollection<Stats>("Stats");
        }

        /// <summary>
        /// Creates the repository should create repository with data access.
        /// </summary>
        [TestMethod]
        public void ShouldInvoqueSaveChanges()
        {
            // Arrange
            // Act
           // this.mockConfiguration.Setup(x => x.GetConnectionString).Returns("ConfigValue");
            //this.mockConfiguration.Setup(x => x.GetConnectionString(It.IsAny<string>())).Returns("");

            Mock<IConfigurationSection> mockSection = new Mock<IConfigurationSection>();
            mockSection.Setup(x => x.Value).Returns("ConfigValue");

            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(x => x.GetSection(It.Is<string>(k => k == ConfigurationConstants.ConnectionString))).Returns(mockSection.Object);


            // Act
            this.mongoContex.Dispose();

            // Assert
            // this.mockDataContext.Verify(m => m.AddCommand<Container>(), Times.Once);
        }

        private Task NewTask()
        {
            return Task.CompletedTask;
        }
    }
}
