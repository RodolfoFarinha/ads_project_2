using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    public interface ICourseService
    {
        CourseViewModel GetByKey(Guid key);

        IEnumerable<CourseViewModel> GetAll();

        CourseViewModel Save(CourseViewModel obj);

        CourseViewModel Delete(Guid key);
    }
}
