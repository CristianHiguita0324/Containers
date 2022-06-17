// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatsControllerTest.cs" company="Microsoft">
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
    using Moq;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The MovementController test class.
    /// </summary>
    [TestClass]
    public class StatsControllerTest
    {
        /// <summary>
        /// The mockStatsAplication
        /// </summary>
        private Mock<IStatsAplication> mockStatsAplication;

        private StatsController statsController;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.mockStatsAplication = new Mock<IStatsAplication>();
            this.statsController = new StatsController(this.mockStatsAplication.Object);
        }

        /// <summary>
        /// ShouldInvokeStatsAplicationAsync successful
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ShouldInvokeStatsAplicationAsync()
        {
            // Prepare
            this.mockStatsAplication
                .Setup(p => p.GetStatisticsAsync()).Returns(Task.FromResult("Result"));

            // Execute
            await this.statsController.StatsAsync().ConfigureAwait(false);
            // Assert
            this.mockStatsAplication.Verify(m => m.GetStatisticsAsync(), Times.Once);
        }

        /// <summary>
        /// ShouldInvokeStatsAplicationTechnicalExceptionAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ShouldInvokeStatsAplicationTechnicalExceptionAsync()
        {
            // Prepare
            this.mockStatsAplication
                .Setup(p => p.GetStatisticsAsync()).ThrowsAsync(new TechnicalException());

            // Execute
            await this.statsController.StatsAsync().ConfigureAwait(false);
            // Assert
            this.mockStatsAplication.Verify(m => m.GetStatisticsAsync(), Times.Once);
        }

        /// <summary>
        /// ShouldInvokeStatsAplicationExceptionAsync
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task ShouldInvokeStatsAplicationExceptionAsync()
        {
            // Prepare
            this.mockStatsAplication
                .Setup(p => p.GetStatisticsAsync()).ThrowsAsync(new Exception());

            // Execute
            await this.statsController.StatsAsync().ConfigureAwait(false);
            // Assert
            this.mockStatsAplication.Verify(m => m.GetStatisticsAsync(), Times.Once);
        }
    }
}
