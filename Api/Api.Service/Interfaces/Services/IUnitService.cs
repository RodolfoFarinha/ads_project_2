using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    /// <summary>
    /// Unit Service
    /// </summary>
    public interface IUnitService
    {
        /// <summary>
        /// Method to get unit by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        UnitViewModel GetByKey(Guid key);

        /// <summary>
        /// Method to get all units
        /// </summary>
        /// <returns></returns>
        IEnumerable<UnitViewModel> GetAll();

        /// <summary>
        /// Method to save unit
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        UnitViewModel Save(UnitViewModel obj);

        /// <summary>
        /// Method to delete unit
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        UnitViewModel Delete(Guid key);
    }
}
