using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    public class CourseUnitRepository : BaseRepository<CourseUnit>, ICourseUnitRepository
    {
        public CourseUnitRepository(ApiDBContext context) : base(context)
        {

        }
    }
}