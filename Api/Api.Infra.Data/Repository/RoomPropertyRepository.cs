using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Room property repository
    /// </summary>
    public class RoomPropertyRepository : BaseRepository<RoomProperty>, IRoomPropertyRepository
    {
        /// <summary>
        /// Room property repository constructor
        /// </summary>
        /// <param name="context"></param>
        public RoomPropertyRepository(ApiDBContext context) : base(context)
        {

        }
    }
}