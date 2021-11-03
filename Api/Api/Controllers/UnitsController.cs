using Api.Service.Interfaces.Services;
using Api.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for unit model
    /// </summary>
    public class UnitsController : BaseController<UnitViewModel, Guid>
    {
        private readonly IUnitService _service;

        /// <summary>
        /// Contructor of unit controller
        /// </summary>
        /// <param name="service"></param>
        public UnitsController(IUnitService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all units
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<UnitViewModel>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Get unit by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<UnitViewModel> GetByKey(Guid key)
        {
            return _service.GetByKey(key);
        }

        /// <summary>
        /// Add or edit unit
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override ActionResult<UnitViewModel> Save(UnitViewModel obj)
        {
            return _service.Save(obj);
        }

        /// <summary>
        /// Delete unit by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<UnitViewModel> Remove(Guid key)
        {
            return _service.Delete(key);
        }
    }
}
