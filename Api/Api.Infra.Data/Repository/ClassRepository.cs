using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Class repository
    /// </summary>
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        /// <summary>
        /// Class repository constructor
        /// </summary>
        /// <param name="context"></param>
        public ClassRepository(ApiDBContext context) : base(context)
        {

        }
    }
}

