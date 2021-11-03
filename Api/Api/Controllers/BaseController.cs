using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    /// <summary>
    /// Base controller which extend by all controllers
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<T, TGuid> : ControllerBase
    {
        /// <summary>
        /// Get all generic
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public abstract ActionResult<List<T>> GetAll();

        /// <summary>
        /// Get generic by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("{key}")]
        [AllowAnonymous]
        public abstract ActionResult<T> GetByKey(TGuid key);

        /// <summary>
        /// Add or edit generic
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public abstract ActionResult<T> Save(T obj);

        /// <summary>
        /// Delete generic by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete("{key}")]
        [AllowAnonymous]
        public abstract ActionResult<T> Remove(TGuid key);

    }
}
