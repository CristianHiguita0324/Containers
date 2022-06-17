// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerAplicationTest.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.Aplication.Test
{
    using Ch.Kpi.Containers.Common.Exeptions;
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    using Ch.Kpi.Containers.Domain.Interfaces;
    using Ch.Kpi.Containers.Domain.Services;
    using Ch.Kpi.Containers.Entities.Entities;
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
        public async Task ShouldInvokeselectContainersAsync()
        {
            // Arrange
            var request = setRequest(); 
            this.unitOfWorkMock.Setup(a => a.CreateRepository<Stats>()).Returns(this.mockStatsRepository.Object);
            this.MockContainerDomain.Setup(m => m.selectContainersAsync(It.IsAny<ContainerRequest>())).ReturnsAsync("");
            // Act
            // Execute
            var response = await this.containerDomain.selectContainersAsync(request).ConfigureAwait(false);
            // Assert
            Assert.AreEqual("Los contenedores que deben ser enviados son :  - C1 - C2 - C4", response);
        }

        /// <summary>
        /// create container entity
        /// </summary>
        /// <returns>ContainerRequest</returns>
        private ContainerRequest setRequest()
        {
            return new ContainerRequest()
            {
                Budget = 1508.65,
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
    }
}
