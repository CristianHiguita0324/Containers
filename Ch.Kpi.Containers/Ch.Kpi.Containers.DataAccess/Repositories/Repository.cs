// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="CristianHiguita">
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//    THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
//    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Repositories
{
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    using MongoDB.Driver;
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The mongo context
        /// </summary>
        protected readonly IMongoContext Context;

        /// <summary>
        /// The dbSet
        /// </summary>
        protected IMongoCollection<TEntity> DbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(IMongoContext context)
        {
            Context = context;

            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        /// <inheritdoc/>
        public virtual void Add(TEntity obj)
        {
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
                return all.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }

        /// <inheritdoc/>
        public virtual void Remove(Guid id)
        {
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
