// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MongoDbPersistenceTest.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
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
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {

        }

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
