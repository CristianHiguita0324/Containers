// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IRepository<TEntity>
        where TEntity : class
    {
       
        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="obj"></param>
        void Add(TEntity obj);

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetById(Guid id);

        /// <summary>
        /// the get all
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Remove by id
        /// </summary>
        /// <param name="id"></param>
        void Remove(Guid id);
    }
}