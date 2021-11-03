using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    public class RoomPropertyRepository : BaseRepository<RoomProperty>, IRoomPropertyRepository
    {
        public RoomPropertyRepository(ApiDBContext context) : base(context)
        {

        }
    }
}