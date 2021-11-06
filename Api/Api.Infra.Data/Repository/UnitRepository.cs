using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Unit repository
    /// </summary>
    public class UnitRepository : BaseRepository<Unit>, IUnitRepository
    {
        /// <summary>
        /// Unit repository constructor
        /// </summary>
        /// <param name="context"></param>
        public UnitRepository(ApiDBContext context) : base(context)
        {

        }
    }
}