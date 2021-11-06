using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Quality schedule repository
    /// </summary>
    public class QualityScheduleRepository : BaseRepository<QualitySchedule>, IQualityScheduleRepository
    {
        /// <summary>
        /// Quality schedule repository constructor
        /// </summary>
        /// <param name="context"></param>
        public QualityScheduleRepository(ApiDBContext context) : base(context)
        {

        }
    }
}

