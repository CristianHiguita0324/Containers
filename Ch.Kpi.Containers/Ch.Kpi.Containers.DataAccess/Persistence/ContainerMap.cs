using Ch.Kpi.Containers.Entities;
using Ch.Kpi.Containers.Entities.Entities;
using MongoDB.Bson.Serialization;

namespace Ch.Kpi.Containers.DataAccess.Persistence
{
    public static class ContainerMap
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
