using Api.Service.Interfaces.Services;
using Api.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for course model
    /// </summary>
    public class CoursesController : BaseController<CourseViewModel, Guid>
    {
        private readonly ICourseService _service;

        /// <summary>
        /// Contructor of course controller
        /// </summary>
        /// <param name="service"></param>
        public CoursesController(ICourseService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all courses
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<CourseViewModel>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Get course by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<CourseViewModel> GetByKey(Guid key)
        {
            return _service.GetByKey(key);
        }

        /// <summary>
        /// Add or edit course
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override ActionResult<CourseViewModel> Save(CourseViewModel obj)
        {
            return _service.Save(obj);
        }

        /// <summary>
        /// Delete course by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<CourseViewModel> Remove(Guid key)
        {
            return _service.Delete(key);
        }
    }
}
