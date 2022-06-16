using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch.Kpi.Containers.Aplication.Interfaces
{
    public interface IStatsAplication
    {
        /// <summary>
        /// get the statistics
        /// </summary>
        /// <returns></returns>
        Task<string> getStatistics();
    }
}
