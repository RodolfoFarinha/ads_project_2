using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    public class ClassShiftRepository : BaseRepository<ClassShift>, IClassShiftRepository
    {
        public ClassShiftRepository(ApiDBContext context) : base(context)
        {

        }
    }
}