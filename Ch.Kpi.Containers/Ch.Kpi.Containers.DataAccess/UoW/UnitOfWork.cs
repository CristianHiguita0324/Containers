// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Ch.Kpi.Containers.DataAccess.UoW
{
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    using System;
    using System.Threading.Tasks;
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext context;

        /// <summary>
        /// The repository factory.
        /// </summary>
        private readonly IRepositoryFactory repositoryFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="repositoryFactory"></param>
        public UnitOfWork(IMongoContext context, IRepositoryFactory repositoryFactory)
        {
            this.context = context;
            this.repositoryFactory = repositoryFactory;
        }

        /// <inheritdoc/>
        public IRepository<TEntity> CreateRepository<TEntity>()
            where TEntity : class
        {
            return this.repositoryFactory.CreateRepository<TEntity>();
        }

        /// <inheritdoc/>
        public async Task<bool> Commit()
        {
            var changeAmount = await context.SaveChanges().ConfigureAwait(false);

            return changeAmount > 0;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        //public void Dispose()
        //{
        //    this.context.Dispose();
        //}
    }
}
