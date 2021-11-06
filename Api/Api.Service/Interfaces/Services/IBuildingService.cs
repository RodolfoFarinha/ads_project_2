using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    /// <summary>
    /// Building service
    /// </summary>
    public interface IBuildingService
    {
        /// <summary>
        /// Method to get building by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        BuildingViewModel GetByKey(Guid key);

        /// <summary>
        /// Method to get all buildings
        /// </summary>
        /// <returns></returns>
        IEnumerable<BuildingViewModel> GetAll();

        /// <summary>
        /// Method to save building
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        BuildingViewModel Save(BuildingViewModel obj);

        /// <summary>
        /// Method to delete building
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        BuildingViewModel Delete(Guid key);
    }
}
