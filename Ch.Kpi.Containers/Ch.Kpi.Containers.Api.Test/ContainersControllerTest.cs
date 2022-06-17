// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainersControllerTest.cs" company="Microsoft">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Api.Test
{
    using Ch.Kpi.Containers.Api.Controllers;
    using Ch.Kpi.Containers.Aplication.Interfaces;
    using Ch.Kpi.Containers.Common.Exeptions;
    using Ch.Kpi.Containers.Entities.Request;
    using Moq;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The MovementController test class.
    /// </summary>
    [TestClass]
    public class ContainersControllerTest
    {
        private Mock<IContainerAplication> mockContainerAplication;

        private ContainersController containersController;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.mockContainerAplication = new Mock<IContainerAplication>();
            this.containersController = new ContainersController(this.mockContainerAplication.Object);
        }

        /// <summary>
        /// ShouldInvokeContainerAplicationAsync successful
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ShouldInvokeContainerAplicationAsync()
        {
            // Prepare
            this.mockContainerAplication
                .Setup(p => p.SelectContainersAsync(
                    It.IsAny<ContainerRequest>()))
                .Returns(Task.FromResult("Result"));

            // Execute
            ContainerRequest request = new ContainerRequest();
            await this.containersController.SelectContainersAsync(request).ConfigureAwait(false);
            // Assert
            this.mockContainerAplication.Verify(m => m.SelectContainersAsync(request), Times.Once);
        }

        /// <summary>
        /// ShouldInvokeContainerAplicationTechnicalExceptionAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ShouldInvokeContainerAplicationTechnicalExceptionAsync()
        {
            // Prepare
            this.mockContainerAplication.Setup(p => p.SelectContainersAsync(It.IsAny<ContainerRequest>())).ThrowsAsync(new TechnicalException());

            // Execute
            ContainerRequest request = new ContainerRequest();
            await this.containersController.SelectContainersAsync(request).ConfigureAwait(false);

            // Assert
            this.mockContainerAplication.Verify(m => m.SelectContainersAsync(request), Times.Once);
        }

        /// <summary>
        /// ShouldInvokeContainerAplicationTechnicalExceptionAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ShouldInvokeContainerAplicationExceptionAsync()
        {
            // Prepare
            this.mockContainerAplication.Setup(p => p.SelectContainersAsync(It.IsAny<ContainerRequest>())).ThrowsAsync(new Exception());

            // Execute
            ContainerRequest request = new ContainerRequest();
            await this.containersController.SelectContainersAsync(request).ConfigureAwait(false);

            // Assert
            this.mockContainerAplication.Verify(m => m.SelectContainersAsync(request), Times.Once);
        }
    }
}
