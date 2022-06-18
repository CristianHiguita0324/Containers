// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MongoDbPersistenceTest.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Ch.Kpi.Containers.DataAccess.Persistence;

namespace Ch.Kpi.Containers.DataAccess.Test
{
    /// <summary>
    /// The MongoDbPersistence tests.
    /// </summary>
    [TestClass]
    public class MongoDbPersistenceTest
    {
        /// <summary>
        /// Creates the repository should create repository with data access.
        /// </summary>
        [TestMethod]
        public void CreateRepositoryShouldCreateRepositoryWithDataAccess()
        {
            // Act
            MongoDbPersistence.Configure();
        }
    }
}
