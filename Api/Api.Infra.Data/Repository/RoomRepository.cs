using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Room repository
    /// </summary>
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        /// <summary>
        /// Room repository constructor
        /// </summary>
        /// <param name="context"></param>
        public RoomRepository(ApiDBContext context) : base(context)
        {

        }
    }
}