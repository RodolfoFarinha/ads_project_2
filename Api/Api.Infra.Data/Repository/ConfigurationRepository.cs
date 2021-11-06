using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Configuration repository
    /// </summary>
    public class ConfigurationRepository : BaseRepository<Configuration>, IConfigurationRepository
    {
        /// <summary>
        /// Configuration repository constructor
        /// </summary>
        /// <param name="context"></param>
        public ConfigurationRepository(ApiDBContext context) : base(context)
        {

        }
    }
}

