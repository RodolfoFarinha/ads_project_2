using Api.Service.Interfaces.Services;
using Api.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for room model
    /// </summary>
    public class RoomsController : BaseController<RoomViewModel, Guid>
    {
        private readonly IRoomService _service;

        /// <summary>
        /// Contructor of room controller
        /// </summary>
        /// <param name="service"></param>
        public RoomsController(IRoomService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all rooms
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<RoomViewModel>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Get room by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<RoomViewModel> GetByKey(Guid key)
        {
            return _service.GetByKey(key);
        }

        /// <summary>
        /// Add or edit room
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override ActionResult<RoomViewModel> Save(RoomViewModel obj)
        {
            return _service.Save(obj);
        }

        /// <summary>
        /// Delete room by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<RoomViewModel> Remove(Guid key)
        {
            return _service.Delete(key);
        }
    }
}
