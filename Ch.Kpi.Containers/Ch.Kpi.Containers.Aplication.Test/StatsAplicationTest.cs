// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatsAplicationTest.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
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
