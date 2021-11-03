using Api.Service.Interfaces.Services;
using Api.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for shift model
    /// </summary>
    public class ShiftsController : BaseController<ShiftViewModel, Guid>
    {
        private readonly IShiftService _service;

        /// <summary>
        /// Contructor of shift controller
        /// </summary>
        /// <param name="service"></param>
        public ShiftsController(IShiftService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all shifts
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<ShiftViewModel>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Get shift by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<ShiftViewModel> GetByKey(Guid key)
        {
            return _service.GetByKey(key);
        }

        /// <summary>
        /// Add or edit shift
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override ActionResult<ShiftViewModel> Save(ShiftViewModel obj)
        {
            return _service.Save(obj);
        }

        /// <summary>
        /// Delete shift by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<ShiftViewModel> Remove(Guid key)
        {
            return _service.Delete(key);
        }
    }
}
