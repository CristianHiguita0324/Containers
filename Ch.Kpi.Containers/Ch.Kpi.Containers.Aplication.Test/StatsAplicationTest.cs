// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatsAplicationTest.cs" company="CristianHiguita">
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
    using Moq;
    using System.Threading.Tasks;

    /// <summary>
    /// The Stats Aplication tests.
    /// </summary>
    [TestClass]
    public class StatsAplicationTest
    {
        /// <summary>
        /// The MockStatsDomain
        /// </summary>
        private Mock<IStatsDomain> MockStatsDomain;

        /// <summary>
        /// The StatsAplication
        /// </summary>
        private StatsAplication statsAplication;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.MockStatsDomain = new Mock<IStatsDomain>();
            this.statsAplication = new StatsAplication(MockStatsDomain.Object);
        }

        /// <summary>
        /// ShouldInvokegetStatisticsAsync.
        /// </summary>
        [TestMethod]
        public async Task ShouldInvokegetStatisticsAsync()
        {
            // Arrange
            this.MockStatsDomain.Setup(m => m.GetStatisticsAsync()).ReturnsAsync("");
            // Act
            // Execute
            var response = await this.statsAplication.GetStatisticsAsync().ConfigureAwait(false);
            // Assert
            Assert.IsNotNull(response);
        }
    }
}
