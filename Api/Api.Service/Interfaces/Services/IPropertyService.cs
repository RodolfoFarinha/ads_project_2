using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    /// <summary>
    /// Property service
    /// </summary>
    public interface IPropertyService
    {
        /// <summary>
        /// Method to get property by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        PropertyViewModel GetByKey(Guid key);

        /// <summary>
        /// Method to get all properties
        /// </summary>
        /// <returns></returns>
        IEnumerable<PropertyViewModel> GetAll();

        /// <summary>
        /// Method to save property
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        PropertyViewModel Save(PropertyViewModel obj);

        /// <summary>
        /// Method to delete property
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        PropertyViewModel Delete(Guid key);
    }
}
