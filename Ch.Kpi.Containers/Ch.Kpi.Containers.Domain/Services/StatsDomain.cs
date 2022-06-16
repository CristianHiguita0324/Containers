using Ch.Kpi.Containers.DataAccess.Interfaces;
using Ch.Kpi.Containers.Domain.Interfaces;
using Ch.Kpi.Containers.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch.Kpi.Containers.Domain.Services
{
    public class StatsDomain : IStatsDomain
    {
        /// <summary>
        /// The unit of work factory.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        public StatsDomain(IUnitOfWorkFactory unitOfWorkFactoy)
        {
            this.unitOfWork = unitOfWorkFactoy.GetUnitOfWork();
        }
        public async Task<string> getStatistics()
        {
            var repo = this.unitOfWork.CreateRepository<Container>();

            var resp = await repo.GetAll();

            return JsonConvert.SerializeObject(resp);
        }
    }
}
