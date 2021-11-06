using Api.Service.Interfaces.Services;
using Api.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for quality schedule model
    /// </summary>
    public class QualitySchedulesController : BaseController<QualityScheduleViewModel, Guid>
    {
        private readonly IQualityScheduleService _service;

        /// <summary>
        /// Contructor of quality schedule controller
        /// </summary>
        /// <param name="service"></param>
        public QualitySchedulesController(IQualityScheduleService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all quality schedules
        /// </summary>
        /// <returns></returns>
        public override ActionResult<List<QualityScheduleViewModel>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        /// <summary>
        /// Get quality schedule by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<QualityScheduleViewModel> GetByKey(Guid key)
        {
            return _service.GetByKey(key);
        }

        /// <summary>
        /// Add or edit quality schedule
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override ActionResult<QualityScheduleViewModel> Save(QualityScheduleViewModel obj)
        {
            return _service.Save(obj);
        }

        /// <summary>
        /// Delete quality schedule by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ActionResult<QualityScheduleViewModel> Remove(Guid key)
        {
            return _service.Delete(key);
        }
    }
}
