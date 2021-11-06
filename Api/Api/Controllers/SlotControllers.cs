using Api.Service.Interfaces.Services;
using Api.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for slot model
    /// </summary>
    public class SlotsController : BaseController<SlotViewModel, Guid>
    {
        private readonly ISlotService _service;

        /// <summary>
        /// Contructor of slot controller
        /// </summary>
        /// <param name="service"></param>
        public SlotsController(ISlotService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all slots
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<SlotViewModel>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Get slot by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<SlotViewModel> GetByKey(Guid key)
        {
            return _service.GetByKey(key);
        }

        /// <summary>
        /// Add or edit slot
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override ActionResult<SlotViewModel> Save(SlotViewModel obj)
        {
            return _service.Save(obj);
        }

        /// <summary>
        /// Delete slot by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<SlotViewModel> Remove(Guid key)
        {
            return _service.Delete(key);
        }
    }
}
