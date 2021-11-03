using Api.Service.Interfaces.Services;
using Api.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for property model
    /// </summary>
    public class PropertiesController : BaseController<PropertyViewModel, Guid>
    {
        private readonly IPropertyService _service;

        /// <summary>
        /// Contructor of property controller
        /// </summary>
        /// <param name="service"></param>
        public PropertiesController(IPropertyService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all properties
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<PropertyViewModel>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Get property by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<PropertyViewModel> GetByKey(Guid key)
        {
            return _service.GetByKey(key);
        }

        /// <summary>
        /// Add or edit property
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override ActionResult<PropertyViewModel> Save(PropertyViewModel obj)
        {
            return _service.Save(obj);
        }

        /// <summary>
        /// Delete property by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<PropertyViewModel> Remove(Guid key)
        {
            return _service.Delete(key);
        }
    }
}
