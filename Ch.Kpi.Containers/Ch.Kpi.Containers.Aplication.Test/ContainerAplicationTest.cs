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
        public async Task ShouldInvokeselectContainersAsync()
        {
            // Arrange
            var request = SetRequest(); 
            this.mockContainerDomain.Setup(m => m.SelectContainersAsync(It.IsAny<ContainerRequest>())).ReturnsAsync(ConstantsTest.selectContainersResponse);
            // Act
            // Execute
            var response = await this.containerAplication.SelectContainersAsync(request).ConfigureAwait(false);
            // Assert
            Assert.AreEqual(ConstantsTest.selectContainersResponse, response);
        }

        /// <summary>
        /// create container entity
        /// </summary>
        /// <returns>ContainerRequest</returns>
        private ContainerRequest SetRequest()
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
