// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MongoDbPersistence.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Persistence
{
    using MongoDB.Bson.Serialization.Conventions;
    public static class MongoDbPersistence
    {
        public static void Configure()
        {
            StatsMap.Configure();

            // Conventions
            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("Technical test Cristian Higuita", pack, t => true);
        }
    }
}
