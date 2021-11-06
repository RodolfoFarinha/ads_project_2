using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    /// <summary>
    /// Session service
    /// </summary>
    public interface ISessionService
    {
        /// <summary>
        /// Method to get session by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SessionViewModel GetByKey(Guid key);

        /// <summary>
        /// Method to get all sessions
        /// </summary>
        /// <returns></returns>
        IEnumerable<SessionViewModel> GetAll();

        /// <summary>
        /// Method to save session
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        SessionViewModel Save(SessionViewModel obj);

        /// <summary>
        /// Method to delete session
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SessionViewModel Delete(Guid key);
    }
}
