using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Shift repository
    /// </summary>
    public class ShiftRepository : BaseRepository<Shift>, IShiftRepository
    {
        /// <summary>
        /// Shift repository constructor
        /// </summary>
        /// <param name="context"></param>
        public ShiftRepository(ApiDBContext context) : base(context)
        {

        }
    }
}

