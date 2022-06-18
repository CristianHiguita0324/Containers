// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWorkFactory.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Interfaces
{
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;
    public interface IMongoContext : IDisposable
    {
        /// <summary>
        /// tha add command
        /// </summary>
        /// <param name="func"></param>
        void AddCommand(Func<Task> func);

        /// <summary>
        /// SaveChanges
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChanges();

        /// <summary>
        /// GetCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        IMongoCollection<T> GetCollection<T>(string name);
    }
}