using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    /// <summary>
    /// Course service
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Method to get course by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        CourseViewModel GetByKey(Guid key);

        /// <summary>
        /// Method to get all courses
        /// </summary>
        /// <returns></returns>
        IEnumerable<CourseViewModel> GetAll();

        /// <summary>
        /// Method to save course
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        CourseViewModel Save(CourseViewModel obj);

        /// <summary>
        /// Method to delete course
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        CourseViewModel Delete(Guid key);
    }
}
