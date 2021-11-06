using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Property repository
    /// </summary>
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        /// <summary>
        /// Property repository constructor
        /// </summary>
        /// <param name="context"></param>
        public PropertyRepository(ApiDBContext context) : base(context)
        {

        }
    }
}