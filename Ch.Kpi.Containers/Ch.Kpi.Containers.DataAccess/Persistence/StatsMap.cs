// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerMap.cs" company="CristianHiguita">
// The following code applies to the technical test proposed by MercadoLibre
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Ch.Kpi.Containers.DataAccess.Persistence
{
    using Ch.Kpi.Containers.Entities.Entities;
    using MongoDB.Bson.Serialization;
    public static class StatsMap
        {
            public static void Configure()
            {
                BsonClassMap.RegisterClassMap<Stats>(map =>
                {
                    map.AutoMap();
                    map.SetIgnoreExtraElements(true);
                    map.MapMember(x => x.ContainersDispatched).SetIsRequired(true);
                    map.MapMember(x => x.BudgetUsed).SetIsRequired(true);
                    map.MapMember(x => x.ContainersNotDispatched).SetIsRequired(true);
                });
            }
        }
}
