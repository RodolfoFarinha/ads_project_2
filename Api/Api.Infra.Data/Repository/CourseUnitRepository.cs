using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    /// <summary>
    /// Course unit repository
    /// </summary>
    public class CourseUnitRepository : BaseRepository<CourseUnit>, ICourseUnitRepository
    {
        /// <summary>
        /// Course unit repository constructor
        /// </summary>
        /// <param name="context"></param>
        public CourseUnitRepository(ApiDBContext context) : base(context)
        {

        }
    }
}