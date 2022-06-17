// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatsDomainTest.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Domain.Test
{
    using Ch.Kpi.Containers.Common.Exeptions;
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    using Ch.Kpi.Containers.Domain.Interfaces;
    using Ch.Kpi.Containers.Domain.Services;
    using Ch.Kpi.Containers.Entities.Entities;
    using Moq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The Stats Aplication tests.
    /// </summary>
    [TestClass]
    public class StatsDomainTest
    {
        /// <summary>
        /// The MockStatsDomain
        /// </summary>
        private Mock<IStatsDomain> MockStatsDomain;

        /// <summary>
        /// The mock unitOfWork.
        /// </summary>
        private readonly Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();

        /// <summary>
        /// The mock unitOfWorkFactory.
        /// </summary>
        private readonly Mock<IUnitOfWorkFactory> unitOfWorkFactory = new Mock<IUnitOfWorkFactory>();

        /// <summary>
        /// the mockDomainRepository
        /// </summary>
        private Mock<IRepository<Stats>> mockStatsRepository;

        /// <summary>
        /// The StatsDomain
        /// </summary>
        private StatsDomain statsDomain;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.mockStatsRepository = new Mock<IRepository<Stats>>();
            this.unitOfWorkFactory.Setup(a => a.GetUnitOfWork()).Returns(this.unitOfWorkMock.Object);
            this.MockStatsDomain = new Mock<IStatsDomain>();
            this.statsDomain = new StatsDomain(unitOfWorkFactory.Object);
        }

        /// <summary>
        /// ShouldInvokegetStatisticsAsync.
        /// </summary>
        [TestMethod]
        public async Task ShouldInvokegetStatisticsAsync()
        {
            // Arrange
            var list = setListStats();
            this.unitOfWorkMock.Setup(a => a.CreateRepository<Stats>()).Returns(this.mockStatsRepository.Object);
            this.mockStatsRepository.Setup(a => a.GetAll()).ReturnsAsync(list);
            this.MockStatsDomain.Setup(m => m.GetStatisticsAsync()).ReturnsAsync("");
            // Act
            // Execute
            var response = await this.statsDomain.GetStatisticsAsync().ConfigureAwait(false);
            // Assert
            Assert.IsNotNull(response);
        }

        /// <summary>
        /// ShouldInvokegetStatisticsAsyncExceptio.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TechnicalException))]
        public async Task ShouldInvokegetStatisticsAsyncExceptio()
        {
            // Arrange
            var list = new List<Stats>() { new Stats() { BudgetUsed = 10.0, ContainersDispatched = 20.2, ContainersNotDispatched = 20.3 } };
            this.unitOfWorkMock.Setup(a => a.CreateRepository<Stats>()).Returns(this.mockStatsRepository.Object);
            this.mockStatsRepository.Setup(a => a.GetAll()).ThrowsAsync(new TechnicalException());
            this.MockStatsDomain.Setup(m => m.GetStatisticsAsync()).ReturnsAsync("");
            // Act
            // Execute
            
            await this.statsDomain.GetStatisticsAsync().ConfigureAwait(false);
        }

        private List<Stats> setListStats()
        {
            return new List<Stats>() { new Stats() { BudgetUsed = 10.0, ContainersDispatched = 20.2, ContainersNotDispatched = 20.3 } };
        }
    }
}
