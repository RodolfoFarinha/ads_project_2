using Api.Service.Interfaces.Services;
using Api.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for configuration model
    /// </summary>
    public class ConfigurationsController : BaseController<ConfigurationViewModel, Guid>
    {
        private readonly IConfigurationService _service;

        /// <summary>
        /// Contructor of configuration controller
        /// </summary>
        /// <param name="service"></param>
        public ConfigurationsController(IConfigurationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all configurations
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<ConfigurationViewModel>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Get configuration by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<ConfigurationViewModel> GetByKey(Guid key)
        {
            return _service.GetByKey(key);
        }

        /// <summary>
        /// Add or edit configuration
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override ActionResult<ConfigurationViewModel> Save(ConfigurationViewModel obj)
        {
            return _service.Save(obj);
        }

        /// <summary>
        /// Delete configuration by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<ConfigurationViewModel> Remove(Guid key)
        {
            return _service.Delete(key);
        }
    }
}
