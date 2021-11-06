using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Slot repository
    /// </summary>
    public class SlotRepository : BaseRepository<Slot>, ISlotRepository
    {
        /// <summary>
        /// Slot repository constructor
        /// </summary>
        /// <param name="context"></param>
        public SlotRepository(ApiDBContext context) : base(context)
        {

        }
    }
}

