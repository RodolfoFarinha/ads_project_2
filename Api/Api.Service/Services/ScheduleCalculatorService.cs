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
using Api.Domain.Enum;

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
        public List<QualityScheduleViewModel> AllocateRoomsToSessions(Tuple<string[], List<string[]>> propertiesData, Tuple<string[], List<string[]>> roomsData, Tuple<string[], List<string[]>> sessionsData)
        {
            using (IUnitOfWork unitOfwork = GetUnitOfWorkInstance())
            {
                ScheduleModel scheduleModel = new ScheduleModel() { ScheduleKey = Guid.NewGuid(), ScheduleVersion = 0 };
                List<QualityScheduleViewModel> qualitySchedules = new List<QualityScheduleViewModel>();

                List<ConfigurationViewModel> configuration = 
                    GetMapperInstance().Map<IEnumerable<Configuration>, List<ConfigurationViewModel>>(unitOfwork.ConfigurationRepository.GetAll());

                FileDataToModel fileDataToModel = new FileDataToModel(configuration);

                List<PropertyViewModel> propperties = fileDataToModel.MappingPropertyViewModel(propertiesData);
                List<RoomViewModel> rooms = fileDataToModel.MappingRoomViewModel(scheduleModel, roomsData, propperties);
                List<SessionViewModel> sessions = fileDataToModel.MappingSessionViewModel(scheduleModel, sessionsData, propperties);

                // First algorithm
                qualitySchedules.Add(NewQualityScheduleViewModel(new QualityScheduleViewModel(ScheduleTypeEnum.Normal), sessions, rooms, 0,"#1e90ff", "#D1E8FF"));

                // Second algorithm - with over booking 25%
                qualitySchedules.Add(NewQualityScheduleViewModel(new QualityScheduleViewModel(ScheduleTypeEnum.OverBooking25), sessions, rooms, 25, "#1e90ff", "#D1E8FF"));

                return qualitySchedules;
            }          
        }

        private QualityScheduleViewModel NewQualityScheduleViewModel(QualityScheduleViewModel qualityScheduleViewModel, List<SessionViewModel> sessions, List<RoomViewModel> rooms, decimal overBookingPercent, string primaryColor, string secundaryColor)
        {
            qualityScheduleViewModel.EventsCalendar = MappingSessionBasicInfoViewModel(ScheduleCalculater.CreateSessionSlots(qualityScheduleViewModel, sessions, rooms, overBookingPercent), primaryColor, secundaryColor);
            return qualityScheduleViewModel;
        }

        private List<CalendarEventViewModel> MappingSessionBasicInfoViewModel (List<SessionViewModel> sessionsViewModel, string primaryColor, string secundaryColor)
        {
            List<CalendarEventViewModel> calendarEventsViewModel = new List<CalendarEventViewModel>();

            foreach (SessionViewModel sessionViewModel in sessionsViewModel)
            {
                RoomViewModel room = sessionViewModel.Slots.AsEnumerable().Select(x => x.Room).FirstOrDefault();
                string roomName = room != null ? room.RoomName : "Sem Sala";

                CalendarEventViewModel calendarEventViewModel =
                    calendarEventsViewModel.Where(x => x.Start == sessionViewModel.StartDate && x.End == sessionViewModel.EndDate).FirstOrDefault();

                string courseName = "";

                foreach (var course in sessionViewModel.Shift.Unit.UnitCourses)
                    courseName += course.Course.CourseName + ",";

                if (calendarEventViewModel == null)
                {
                    calendarEventsViewModel.Add( new CalendarEventViewModel
                    {
                        Title = $"{sessionViewModel.Shift.Unit.UnitName} ({roomName})",
                        TotalSessionsWithoutRoom = room != null ? 0 : 1,
                        Color = new EventColor() { Primary = primaryColor, Secundary = secundaryColor },
                        Start = sessionViewModel.StartDate,
                        End = sessionViewModel.EndDate,
                        SessionsBasicInfo = new List<SessionBasicInfoViewModel>() {
                            new SessionBasicInfoViewModel {
                                SessionKey = sessionViewModel.SessionKey,
                                ShiftKey = sessionViewModel.ShiftKey,
                                ShiftName = sessionViewModel.Shift.ShiftName,
                                PropertyKey = sessionViewModel?.PropertyKey,
                                PropertyName = sessionViewModel?.Property?.PropertyName,
                                BuildingKey = room?.BuildingKey,
                                BuildingName = room?.Building?.BuildingName,
                                RoomKey = room?.RoomKey,
                                RoomName = room?.RoomName,
                                UnitKey = sessionViewModel.Shift.UnitKey,
                                UnitName = sessionViewModel.Shift.Unit.UnitName,
                                StartDate = sessionViewModel.StartDate,
                                EndDate = sessionViewModel.EndDate,
                                CourseName =  courseName
                            }
                        }
                    });
                }
                else
                {
                    calendarEventViewModel.Title += $",<br>{sessionViewModel.Shift.Unit.UnitName} ({roomName})";
                    calendarEventViewModel.TotalSessionsWithoutRoom += room != null ? 0 : 1;
                    calendarEventViewModel.SessionsBasicInfo.Add(
                        new SessionBasicInfoViewModel
                        {
                            SessionKey = sessionViewModel.SessionKey,
                            ShiftKey = sessionViewModel.ShiftKey,
                            ShiftName = sessionViewModel.Shift.ShiftName,
                            PropertyKey = sessionViewModel?.PropertyKey,
                            PropertyName = sessionViewModel?.Property?.PropertyName,
                            BuildingKey = room?.BuildingKey,
                            BuildingName = room?.Building?.BuildingName,
                            RoomKey = room?.RoomKey,
                            RoomName = room?.RoomName,
                            UnitKey = sessionViewModel.Shift.UnitKey,
                            UnitName = sessionViewModel.Shift.Unit.UnitName,
                            StartDate = sessionViewModel.StartDate,
                            EndDate = sessionViewModel.EndDate,
                            CourseName = courseName
                        });
                }
            }

            return calendarEventsViewModel;
        }
    }    
}