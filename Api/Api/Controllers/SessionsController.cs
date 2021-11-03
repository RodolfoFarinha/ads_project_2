using Api.Service.Interfaces.Services;
using Api.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for session model
    /// </summary>
    public class SessionsController : BaseController<SessionViewModel, Guid>
    {
        private readonly ISessionService _service;

        /// <summary>
        /// Contructor of session controller
        /// </summary>
        /// <param name="service"></param>
        public SessionsController(ISessionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all sessions
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<SessionViewModel>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Get session by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<SessionViewModel> GetByKey(Guid key)
        {
            return _service.GetByKey(key);
        }

        /// <summary>
        /// Add or edit session
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override ActionResult<SessionViewModel> Save(SessionViewModel obj)
        {
            return _service.Save(obj);
        }

        /// <summary>
        /// Delete session by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<SessionViewModel> Remove(Guid key)
        {
            return _service.Delete(key);
        }
    }
}
