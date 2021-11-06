using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Class shift repository
    /// </summary>
    public class ClassShiftRepository : BaseRepository<ClassShift>, IClassShiftRepository
    {
        /// <summary>
        /// Class shift repository constructor
        /// </summary>
        /// <param name="context"></param>
        public ClassShiftRepository(ApiDBContext context) : base(context)
        {

        }
    }
}