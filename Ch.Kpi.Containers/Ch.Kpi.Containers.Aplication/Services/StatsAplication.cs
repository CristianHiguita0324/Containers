

namespace Ch.Kpi.Containers.Aplication.Services
{
    using Ch.Kpi.Containers.Aplication.Interfaces;
    using Ch.Kpi.Containers.Domain.Interfaces;

    public class StatsAplication : IStatsAplication
    {
        private readonly IStatsDomain statsDomain;

        public StatsAplication(IStatsDomain statsDomain)
        {
            this.statsDomain = statsDomain;
        }

        public Task<string> getStatistics()
        {
            return this.statsDomain.getStatistics();
        }
    }
}
