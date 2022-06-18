// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryTests.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
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
    }
}
