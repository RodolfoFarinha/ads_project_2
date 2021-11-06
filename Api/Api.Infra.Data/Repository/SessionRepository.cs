using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Session repository
    /// </summary>
    public class SessionRepository : BaseRepository<Session>, ISessionRepository
    {
        /// <summary>
        /// Session repository constructor
        /// </summary>
        /// <param name="context"></param>
        public SessionRepository(ApiDBContext context) : base(context)
        {

        }
    }
}
