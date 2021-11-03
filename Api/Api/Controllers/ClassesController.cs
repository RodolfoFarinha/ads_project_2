using Api.Service.Interfaces.Services;
using Api.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for class model
    /// </summary>
    public class ClassesController : BaseController<ClassViewModel, Guid>
    {
        private readonly IClassService _service;

        /// <summary>
        /// Contructor of class controller
        /// </summary>
        /// <param name="service"></param>
        public ClassesController(IClassService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all classes
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<ClassViewModel>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Get class by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<ClassViewModel> GetByKey(Guid key)
        {
            return _service.GetByKey(key);
        }

        /// <summary>
        /// Add or edit class
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override ActionResult<ClassViewModel> Save(ClassViewModel obj)
        {
            return _service.Save(obj);
        }

        /// <summary>
        /// Delete class by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<ClassViewModel> Remove(Guid key)
        {
            return _service.Delete(key);
        }
    }
}
