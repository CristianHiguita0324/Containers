// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MongoContext.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Context
{
    using Ch.Kpi.Containers.DataAccess.Interfaces;
    using Ch.Kpi.Containers.Entities.Configuration;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MongoContext : IMongoContext
    {
        /// <summary>
        /// The mongo data base.
        /// </summary>
        private IMongoDatabase dataBase { get; set; }

        /// <summary>
        /// The Client Session Handle.
        /// </summary>
        public IClientSessionHandle session { get; set; }

        /// <summary>
        /// The Client Mongo.
        /// </summary>
        public MongoClient mongoClient { get; set; }

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly List<Func<Task>> commands;

        /// <summary>
        /// The commands list.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoContext"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public MongoContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            commands = new List<Func<Task>>();
        }

        /// <inheritdoc/>
        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (session = await mongoClient.StartSessionAsync().ConfigureAwait(false))
            {
                session.StartTransaction();

                var commandTasks = commands.Select(c => c());

                await Task.WhenAll(commandTasks).ConfigureAwait(false);

                await session.CommitTransactionAsync().ConfigureAwait(false);
            }

            return commands.Count;
        }

        /// <inheritdoc/>
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();

            return dataBase.GetCollection<T>(name);
        }

        public void Dispose()
        {
            session?.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public void AddCommand(Func<Task> func)
        {
            commands.Add(func);
        }

        /// <summary>
        /// The configuration Mongo
        /// </summary>
        private void ConfigureMongo()
        {
            if (mongoClient != null)
            {
                return;
            }

            mongoClient = new MongoClient(configuration[ConfigurationConstants.ConnectionString]);

            dataBase = mongoClient.GetDatabase(configuration[ConfigurationConstants.DataBaseName]);
        }
    }
}