using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Building repository
    /// </summary>
    public class BuildingRepository : BaseRepository<Building>, IBuildingRepository
    {
        /// <summary>
        /// Building repository constructor
        /// </summary>
        /// <param name="context"></param>
        public BuildingRepository(ApiDBContext context) : base(context)
        {

        }
    }
}

