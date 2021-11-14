using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Service.Interfaces.Services;
using Api.Service.Mapping.ManualMapper;
using Api.Service.Business;
using Api.Service.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Api.Service.Services
{
    /// <summary>
    /// Session service
    /// </summary>
    public class ScheduleCalculatorService : BaseService, IScheduleCalculatorService
    {
        /// <summary>
        /// Session service constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public ScheduleCalculatorService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        /// <summary>
        /// Method that allocate rooms to sessions
        /// </summary>
        /// <param name="propertiesData"></param>
        /// <param name="roomsData"></param>
        /// <param name="sessionsData"></param>
        /// <returns></returns>
        public QualityScheduleViewModel AllocateRoomsToSessions(Tuple<string[], List<string[]>> propertiesData, Tuple<string[], List<string[]>> roomsData, Tuple<string[], List<string[]>> sessionsData)
        {
            using (IUnitOfWork unitOfwork = GetUnitOfWorkInstance())
            {
                ScheduleModel scheduleModel = new ScheduleModel() { ScheduleKey = Guid.NewGuid(), ScheduleVersion = 0 };
                QualityScheduleViewModel qualitySchedule = new QualityScheduleViewModel();

                List<ConfigurationViewModel> configuration = 
                    GetMapperInstance().Map<IEnumerable<Configuration>, List<ConfigurationViewModel>>(unitOfwork.ConfigurationRepository.GetAll());

                FileDataToModel fileDataToModel = new FileDataToModel(configuration);

                List<PropertyViewModel> propperties = fileDataToModel.MappingPropertyViewModel(propertiesData);
                List<RoomViewModel> rooms = fileDataToModel.MappingRoomViewModel(scheduleModel, roomsData, propperties);
                List<SessionViewModel> sessions = fileDataToModel.MappingSessionViewModel(scheduleModel, sessionsData, propperties);

                // First algorithm
                DateTime exectutionStart = DateTime.Now;
                qualitySchedule.BasicSessions = MappingSessionBasicInfoViewModel(ScheduleCalculater.CreateSessionSlots(qualitySchedule, sessions, rooms));
                qualitySchedule.TimeExecution = DateTime.Now.Subtract(exectutionStart);

                return qualitySchedule;
            }          
        }

        private List<SessionBasicInfoViewModel> MappingSessionBasicInfoViewModel (List<SessionViewModel> sessionsViewModel)
        {
            List<SessionBasicInfoViewModel> sessionsBasicInfoViewModel = new List<SessionBasicInfoViewModel>();

            foreach (SessionViewModel sessionViewModel in sessionsViewModel)
            {
                RoomViewModel room = sessionViewModel.Slots.AsEnumerable().Select(x => x.Room).FirstOrDefault();

                if(room != null)
                {
                    int i = 0;
                }

                sessionsBasicInfoViewModel.Add(new SessionBasicInfoViewModel
                {
                    SessionKey = sessionViewModel.SessionKey,
                    ShiftKey = sessionViewModel.ShiftKey,
                    PropertyKey = sessionViewModel.PropertyKey,
                    BuildingKey = room?.BuildingKey,
                    BuildingName = room?.Building.BuildingName,
                    RoomKey = room?.RoomKey,
                    RoomName = room?.RoomName,
                    Title = sessionViewModel.Shift.ShiftName + ", " + sessionViewModel.Shift.Unit.UnitName,
                    Start = sessionViewModel.StartDate,
                    End = sessionViewModel.EndDate
                });
            }

            return sessionsBasicInfoViewModel;
        }
    }    
}