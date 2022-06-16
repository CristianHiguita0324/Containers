// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWorkFactory.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.UnitofWork
{
    using Ch.Kpi.Containers.DataAccess.Interfaces;

    /// <summary>
    /// The unit of work factory.
    /// </summary>
    /// <seealso cref="IUnitOfWorkFactory" />
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        ///<summary>
        /// The data context.
        /// </summary>
        private readonly IMongoContext dataContext;

        /// <summary>
        /// The repository factory.
        /// </summary>
        private readonly IRepositoryFactory repositoryFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkFactory" /> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        /// <param name="repositoryFactory">The repository factory.</param>
        public UnitOfWorkFactory(IMongoContext dataContext, IRepositoryFactory repositoryFactory)
        {
            this.dataContext = dataContext;
            this.repositoryFactory = repositoryFactory;
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <returns>
        /// The unit of work.
        /// </returns>
        public IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(this.dataContext, this.repositoryFactory);
        }
    }
}
