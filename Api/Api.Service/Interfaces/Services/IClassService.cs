using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    /// <summary>
    /// Class service
    /// </summary>
    public interface IClassService
    {
        /// <summary>
        /// Method to get class by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ClassViewModel GetByKey(Guid key);

        /// <summary>
        /// Method to get all classes
        /// </summary>
        /// <returns></returns>
        IEnumerable<ClassViewModel> GetAll();

        /// <summary>
        /// Method to save class
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        ClassViewModel Save(ClassViewModel obj);

        /// <summary>
        /// Method to delete class
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ClassViewModel Delete(Guid key);
    }
}
