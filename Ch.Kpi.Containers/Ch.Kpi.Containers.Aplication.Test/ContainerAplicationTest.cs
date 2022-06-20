// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerAplicationTest.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Aplication.Test
{
    using Ch.Kpi.Containers.Aplication.Services;
    using Ch.Kpi.Containers.Domain.Interfaces;
    using Ch.Kpi.Containers.Entities;
    using Ch.Kpi.Containers.Entities.Request;
    using Moq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The Container Aplication Test.
    /// </summary>
    [TestClass]
    public class ContainerAplicationTest
    {
        /// <summary>
        /// The MockStatsDomain
        /// </summary>
        private Mock<IContainerDomain> mockContainerDomain;


        /// <summary>
        /// The ContainerAplication
        /// </summary>
        private ContainerAplication containerAplication;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.mockContainerDomain = new Mock<IContainerDomain>();
            this.containerAplication = new ContainerAplication(mockContainerDomain.Object);
        }

        /// <summary>
        /// ShouldInvokegetStatisticsAsync.
        /// </summary>
        [TestMethod]
        public async Task ShouldInvokeBudgetOkSelectContainersAsync()
        {
            // Arrange
            var request = new ContainerRequest();
            this.mockContainerDomain.Setup(m => m.SelectContainersAsync(It.IsAny<ContainerRequest>())).ReturnsAsync(ConstantsTest.selectContainersResponse);
            // Act
            // Execute
            var response = await this.containerAplication.SelectContainersAsync(request).ConfigureAwait(false);
            // Assert
            Assert.AreEqual(ConstantsTest.selectContainersResponse, response);
        }

        /// <summary>
        /// ShouldInvokegetStatisticsAsync.
        /// </summary>
        [TestMethod]
        public async Task ShouldInvokeBudgetFailSelectContainersAsync()
        {
            // Arrange
            var request = new ContainerRequest();
            this.mockContainerDomain.Setup(m => m.SelectContainersAsync(It.IsAny<ContainerRequest>())).ReturnsAsync(ConstantsTest.selectContainersResponse);
            // Act
            // Execute
            var response = await this.containerAplication.SelectContainersAsync(request).ConfigureAwait(false);
            // Assert
            Assert.AreEqual(ConstantsTest.selectContainersResponse, response);
        }
    }
}
