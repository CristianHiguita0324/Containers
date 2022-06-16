// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryFactoryTests.cs" company="CristiaHiguita">
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
           // this.mockDataContext.Verify(m => m.AddCommand<Container>(), Times.Once);
        }

    }
}
