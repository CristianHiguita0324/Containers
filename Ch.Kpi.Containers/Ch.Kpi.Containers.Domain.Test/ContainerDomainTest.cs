// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerAplicationTest.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Domain.Test
{
    using Ch.Kpi.Containers.Common.Exeptions;
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    using Ch.Kpi.Containers.Domain.Interfaces;
    using Ch.Kpi.Containers.Domain.Services;
    using Ch.Kpi.Containers.Entities;
    using Ch.Kpi.Containers.Entities.Entities;
    using Ch.Kpi.Containers.Entities.Request;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;

    /// <summary>
    /// The Container Aplication Test.
    /// </summary>
    [TestClass]
    public class ContainerDomainTest
    {
        /// <summary>
        /// The MockStatsDomain
        /// </summary>
        private Mock<IContainerDomain> MockContainerDomain;

        /// <summary>
        /// The mock unitOfWork.
        /// </summary>
        private readonly Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();

        /// <summary>
        /// The mock unitOfWorkFactory.
        /// </summary>
        private readonly Mock<IUnitOfWorkFactory> unitOfWorkFactory = new Mock<IUnitOfWorkFactory>();

        /// <summary>
        /// the mockStatsRepository
        /// </summary>
        private Mock<IRepository<Stats>> mockStatsRepository;

        /// <summary>
        /// The ContainerDomain
        /// </summary>
        private ContainerDomain containerDomain;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.mockStatsRepository = new Mock<IRepository<Stats>>();
            this.unitOfWorkFactory.Setup(a => a.GetUnitOfWork()).Returns(this.unitOfWorkMock.Object);
            this.MockContainerDomain = new Mock<IContainerDomain>();
            this.containerDomain = new ContainerDomain(unitOfWorkFactory.Object);
        }

        /// <summary>
        /// ShouldInvokegetStatisticsAsync.
        /// </summary>
        [TestMethod]
        public async Task ShouldInvokeBudgetOkselectContainersAsync()
        {
            // Arrange
            var request = SetRequest(1508.65);
            this.unitOfWorkMock.Setup(a => a.CreateRepository<Stats>()).Returns(this.mockStatsRepository.Object);
            this.MockContainerDomain.Setup(m => m.SelectContainersAsync(It.IsAny<ContainerRequest>())).ReturnsAsync(ConstantsTest.selectContainersResponse);
            // Act
            // Execute
            var response = await this.containerDomain.SelectContainersAsync(request).ConfigureAwait(false);
            // Assert
            Assert.AreEqual(ConstantsTest.selectContainersResponse, response);
        }

        /// <summary>
        /// ShouldInvokegetStatisticsAsync.
        /// </summary>
        [TestMethod]
        public async Task ShouldInvokeBudgetFailselectContainersAsync()
        {
            // Arrange
            var request = SetRequest(150.65);
            this.unitOfWorkMock.Setup(a => a.CreateRepository<Stats>()).Returns(this.mockStatsRepository.Object);
            this.MockContainerDomain.Setup(m => m.SelectContainersAsync(It.IsAny<ContainerRequest>())).ReturnsAsync(ConstantsTest.selectContainersResponse);
            // Act
            // Execute
            var response = await this.containerDomain.SelectContainersAsync(request).ConfigureAwait(false);
            // Assert
            Assert.AreEqual(ConstantsTest.selectContainersResponseBudgetFail, response);
        }

        /// <summary>
        /// ShouldInvokegetStatisticsAsync.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TechnicalException))]
        public async Task ShouldInvokeTechnicalExceptionselectContainersAsync()
        {
            // Arrange
            var request = SetRequest(1508.65);

            this.MockContainerDomain.Setup(m => m.SelectContainersAsync(It.IsAny<ContainerRequest>())).ReturnsAsync(ConstantsTest.selectContainersResponse);
            // Act
            // Execute
            var response = await this.containerDomain.SelectContainersAsync(request).ConfigureAwait(false);
        }

        /// <summary>
        /// create container entity
        /// </summary>
        /// <returns>ContainerRequest</returns>
        private ContainerRequest SetRequest(double budget)
        {
            return new ContainerRequest()
            {
                Budget = budget,
                Containers = new List<Entities.Container>()
                {
                    new Entities.Container() { ContainerPrice = 4744.03, Name = "C1", TransportCost = 571.40},
                    new Entities.Container() { ContainerPrice = 3579.07, Name = "C2", TransportCost = 537.33},
                    new Entities.Container() { ContainerPrice = 1379.26, Name = "C3", TransportCost = 434.66},
                    new Entities.Container() { ContainerPrice = 1700.12, Name = "C4", TransportCost = 347.28},
                    new Entities.Container() { ContainerPrice = 1434.80, Name = "C5", TransportCost = 264.54},
                }
            };
        }

        /// <summary>
        /// ShouldInvokegetStatisticsAsync.
        /// </summary>
        [TestMethod]
        public  void ShouldInvokeTechnicalException()
        {
            var stream = new StreamingContext();
            // Arrange
            TechnicalException technicalException = new TechnicalException("messge","tramaBroker");

            TechnicalException _technicalException = new TechnicalException("messge", new Exception());

            TechnicalException _technicalException_ = new TechnicalException("messge", stream.ToString());
            // Assert
            Assert.IsNotNull(technicalException);
            
            Assert.IsNotNull(_technicalException);
            
            Assert.IsNotNull(_technicalException_);

            Assert.IsNotNull(technicalException.TramaBroker);
        }
    }
}
