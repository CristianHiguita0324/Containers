using Ch.Kpi.Containers.Entities;
using MongoDB.Bson.Serialization;

namespace Ch.Kpi.Containers.DataAccess.Persistence
{
    public class ContainerMap
        {
            public static void Configure()
            {
                BsonClassMap.RegisterClassMap<Container>(map =>
                {
                    map.AutoMap();
                    map.SetIgnoreExtraElements(true);
                    map.MapMember(x => x.TransportCost).SetIsRequired(true);
                    map.MapMember(x => x.ContainerPrice).SetIsRequired(true);
                    map.MapMember(x => x.Name).SetIsRequired(true);
                });
            }
        }
}
