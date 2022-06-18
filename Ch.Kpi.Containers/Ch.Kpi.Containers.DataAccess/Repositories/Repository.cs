// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Repositories
{
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The mongo context
        /// </summary>
        private readonly IMongoContext Context;

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
            this.Context = context;

            DbSet = this.Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        /// <inheritdoc/>
        public virtual void Add(TEntity obj)
        {
            this.Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id)).ConfigureAwait(false);
            return data.SingleOrDefault();
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty).ConfigureAwait(false);
            return all.ToList();
        }

        /// <inheritdoc/>
        public virtual void Remove(Guid id)
        {
            this.Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
        }
    }
}
