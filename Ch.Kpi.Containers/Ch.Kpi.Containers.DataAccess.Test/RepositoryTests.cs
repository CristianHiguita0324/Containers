// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryTests.cs" company="CristianHiguita">
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
    using MongoDB.Driver;
    using Moq;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The repository tests.
    /// </summary>
    [TestClass]
    public class RepositoryTests
    {
        /// <summary>
        /// The repository. Container
        /// </summary>
        private Mock<Repository<Container>> mockrepository;

        /// <summary>
        /// The repository.
        /// </summary>
        private Repository<Container> repository;

        /// <summary>
        /// The mock data context.
        /// </summary>
        private Mock<IMongoContext> mockDataContext;

        /// <summary>
        /// The dbSet
        /// </summary>
        private Mock<IMongoCollection<Container>> mockDbSet;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.mockDbSet = new Mock<IMongoCollection<Container>>();
            this.mockrepository = new Mock<Repository<Container>>();
            this.mockDataContext = new Mock<IMongoContext>();
            this.repository = new Repository<Container>(this.mockDataContext.Object);
            
        }

        /// <summary>
        /// Inserts the should insert using data access.
        /// </summary>
        [TestMethod]
        public void InsertShouldAddUsingDataAccess()
        {
            // Arrange
            var container = new Container();
            this.mockrepository.Setup(m => m.Add(It.IsAny<Container>()));
            // Act
            this.repository.Add(container);
        }

        /// <summary>
        /// Updates the should update using data access.
        /// </summary>
        [TestMethod]
        public void RemoveShouldRemoveUsingDataAccess()
        {
            // Arrange
            var id = new Guid();
            this.mockrepository.Setup(m => m.Remove(It.IsAny<Guid>()));

            // Act
            this.repository.Remove(id);

        }


        /// <summary>
        /// Gets the by identifier asynchronous should get entity from data access.
        /// </summary>
        /// <returns>
        /// The task.
        /// </returns>
        [TestMethod]
        public async Task GetByIdAsyncShouldGetEntityFromDataAccessAsync()
        {
            // Arrange
            var id = new Guid();
            var container = new Container();
            this.mockrepository.Setup(m => m.GetById(id)).ReturnsAsync(container);

            // Act
            var result = await this.repository.GetById(id).ConfigureAwait(false);

            // Assert
            Assert.AreEqual(result, container);
        }

        /// <summary>
        /// Gets the by identifier asynchronous should get entity from data access.
        /// </summary>
        /// <returns>
        /// The task.
        /// </returns>
        [TestMethod]
        public async Task GetAllAsyncShouldReturnAllContainersFromDataAccessAsync()
        {
            // Arrange
            var categories = new[] { new Container() };
            this.mockrepository.Setup(m => m.GetAll()).ReturnsAsync(categories);

            // Act
            var result = await this.repository.GetAll().ConfigureAwait(false);

            // Assert
            Assert.AreEqual(categories, result);
        }
    }
}
