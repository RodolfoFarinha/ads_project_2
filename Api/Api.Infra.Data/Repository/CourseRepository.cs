using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Course repository
    /// </summary>
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        /// <summary>
        /// Course repository constructor
        /// </summary>
        /// <param name="context"></param>
        public CourseRepository(ApiDBContext context) : base(context)
        {

        }
    }
}