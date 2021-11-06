using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    /// <summary>
    /// QualitySchedule service
    /// </summary>
    public interface IQualityScheduleService
    {
        /// <summary>
        /// Method to get quality schedule by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        QualityScheduleViewModel GetByKey(Guid key);

        /// <summary>
        /// Method to get all quality schedules
        /// </summary>
        /// <returns></returns>
        IEnumerable<QualityScheduleViewModel> GetAll();

        /// <summary>
        /// Method to save quality schedule
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        QualityScheduleViewModel Save(QualityScheduleViewModel obj);

        /// <summary>
        /// Method to delete quality schedule
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        QualityScheduleViewModel Delete(Guid key);
    }
}
