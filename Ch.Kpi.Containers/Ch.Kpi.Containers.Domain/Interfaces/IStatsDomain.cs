using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch.Kpi.Containers.Domain.Interfaces
{
    public interface IStatsDomain
    {
        /// <summary>
        /// get the statistics
        /// </summary>
        /// <returns></returns>
        Task<string> getStatistics();
    }
}
