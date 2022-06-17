// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainersControllerTest.cs" company="Microsoft">
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//   THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//   OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//   ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//   OTHER DEALINGS IN THE SOFTWARE.
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
                .Setup(p => p.selectContainersAsync(
                    It.IsAny<ContainerRequest>()))
                .Returns(Task.FromResult("Result"));

            // Execute
            ContainerRequest request = new ContainerRequest();
            await this.containersController.selectContainersAsync(request).ConfigureAwait(false);
            // Assert
            this.mockContainerAplication.Verify(m => m.selectContainersAsync(request), Times.Once);
        }

        /// <summary>
        /// ShouldInvokeContainerAplicationTechnicalExceptionAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ShouldInvokeContainerAplicationTechnicalExceptionAsync()
        {
            // Prepare
            this.mockContainerAplication.Setup(p => p.selectContainersAsync(It.IsAny<ContainerRequest>())).ThrowsAsync(new TechnicalException());

            // Execute
            ContainerRequest request = new ContainerRequest();
            await this.containersController.selectContainersAsync(request).ConfigureAwait(false);

            // Assert
            this.mockContainerAplication.Verify(m => m.selectContainersAsync(request), Times.Once);
        }

        /// <summary>
        /// ShouldInvokeContainerAplicationTechnicalExceptionAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ShouldInvokeContainerAplicationExceptionAsync()
        {
            // Prepare
            this.mockContainerAplication.Setup(p => p.selectContainersAsync(It.IsAny<ContainerRequest>())).ThrowsAsync(new Exception());

            // Execute
            ContainerRequest request = new ContainerRequest();
            await this.containersController.selectContainersAsync(request).ConfigureAwait(false);

            // Assert
            this.mockContainerAplication.Verify(m => m.selectContainersAsync(request), Times.Once);
        }
    }
}
