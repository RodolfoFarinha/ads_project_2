using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    /// <summary>
    /// Configuration service
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Method to get configuration by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ConfigurationViewModel GetByKey(Guid key);

        /// <summary>
        /// Method to get all configurations
        /// </summary>
        /// <returns></returns>
        IEnumerable<ConfigurationViewModel> GetAll();

        /// <summary>
        /// Method to save configuration
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        ConfigurationViewModel Save(ConfigurationViewModel obj);

        /// <summary>
        /// Method to delete configuration
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ConfigurationViewModel Delete(Guid key);
    }
}
