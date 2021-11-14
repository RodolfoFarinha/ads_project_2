using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    /// <summary>
    /// Schedule calculator service
    /// </summary>
    public interface IScheduleCalculatorService
    {
        /// <summary>
        /// Method that allocate rooms to sessions
        /// </summary>
        /// <param name="propertiesData"></param>
        /// <param name="roomsData"></param>
        /// <param name="sessionsData"></param>
        /// <returns></returns>
        QualityScheduleViewModel AllocateRoomsToSessions(Tuple<string[], List<string[]>> propertiesData, Tuple<string[], List<string[]>> roomsData, Tuple<string[], List<string[]>> sessionsData);
    }
}