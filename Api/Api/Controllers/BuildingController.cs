using Api.Service.Interfaces.Services;
using Api.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for building model
    /// </summary>
    public class BuildingsController : BaseController<BuildingViewModel, Guid>
    {
        private readonly IBuildingService _service;

        /// <summary>
        /// Contructor of building controller
        /// </summary>
        /// <param name="service"></param>
        public BuildingsController(IBuildingService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all buildings
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<BuildingViewModel>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Get building by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<BuildingViewModel> GetByKey(Guid key)
        {
            return _service.GetByKey(key);
        }

        /// <summary>
        /// Add or edit building
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override ActionResult<BuildingViewModel> Save(BuildingViewModel obj)
        {
            return _service.Save(obj);
        }

        /// <summary>
        /// Delete building by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<BuildingViewModel> Remove(Guid key)
        {
            return _service.Delete(key);
        }
    }
}
