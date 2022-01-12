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
using System.IO;
using System.Text;

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

                List<PropertyViewModel> properties = fileDataToModel.MappingPropertyViewModel(propertiesData);
                List<RoomViewModel> rooms = fileDataToModel.MappingRoomViewModel(scheduleModel, roomsData, properties);
                List<SessionViewModel> sessions = fileDataToModel.MappingSessionViewModel(scheduleModel, sessionsData, properties);

                // Algorithm - with normal order
                qualitySchedules.Add(NewQualityScheduleViewModel(new QualityScheduleViewModel(ScheduleTypeEnum.Normal), sessions, rooms, 0,"#1e90ff", "#D1E8FF"));

                // Algorithm - with over booking 25%
                qualitySchedules.Add(NewQualityScheduleViewModel(new QualityScheduleViewModel(ScheduleTypeEnum.OverBooking25), sessions, rooms, 25, "#1e90ff", "#D1E8FF"));

                // Algorithm - with room close capacity
                qualitySchedules.Add(NewQualityScheduleViewModel(new QualityScheduleViewModel(ScheduleTypeEnum.RoomCloseCapacity), sessions, rooms, 0, "#1e90ff", "#D1E8FF"));

                // Algorithm - with random order
                qualitySchedules.Add(NewQualityScheduleViewModel(new QualityScheduleViewModel(ScheduleTypeEnum.RandomOrder), sessions, rooms, 0, "#1e90ff", "#D1E8FF"));

                // Algorithm - with all variables
                qualitySchedules.Add(NewQualityScheduleViewModel(new QualityScheduleViewModel(ScheduleTypeEnum.AllVariables), sessions, rooms, 25, "#1e90ff", "#D1E8FF"));

                CreateCSVFiles(qualitySchedules);

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

                List<string> courseNames = new List<string>();
                string courseName = "";

                foreach (var course in sessionViewModel.Shift.Unit.UnitCourses)
                    if (!courseNames.Contains(course.Course.CourseName))
                    {
                        courseNames.Add(course.Course.CourseName);
                        courseName += course.Course.CourseName + ", ";
                    }
                        
                if (calendarEventViewModel == null)
                {
                    if (sessionViewModel.StartDate > Convert.ToDateTime("01/01/1900") && sessionViewModel.Shift.EnrolledStudents >= 5)
                    {
                        calendarEventsViewModel.Add(new CalendarEventViewModel
                        {
                            ScheduleKey = Guid.NewGuid(),
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
                                    ClassKey = sessionViewModel.Shift.ShiftClasses.FirstOrDefault().ClassKey,
                                    ClassName = sessionViewModel.Shift.ShiftClasses.FirstOrDefault().Class.ClassName,
                                    PropertyKey = sessionViewModel?.PropertyKey,
                                    PropertyName = sessionViewModel?.Property?.PropertyName,
                                    BuildingKey = room?.BuildingKey,
                                    BuildingName = room?.Building?.BuildingName,
                                    RoomKey = room?.RoomKey,
                                    RoomName = room?.RoomName,
                                    RoomCapacity = room?.NormalCapacity,
                                    UnitKey = sessionViewModel.Shift.UnitKey,
                                    UnitName = sessionViewModel.Shift.Unit.UnitName,
                                    StartDate = sessionViewModel.StartDate,
                                    EndDate = sessionViewModel.EndDate,
                                    CourseName =  courseName,
                                    Enrollments = sessionViewModel.Shift.EnrolledStudents
                                }
                            }
                        });
                    }
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
                            ClassKey = sessionViewModel.Shift.ShiftClasses.FirstOrDefault().ClassKey,
                            ClassName = sessionViewModel.Shift.ShiftClasses.FirstOrDefault().Class.ClassName,
                            PropertyKey = sessionViewModel?.PropertyKey,
                            PropertyName = sessionViewModel?.Property?.PropertyName,
                            BuildingKey = room?.BuildingKey,
                            BuildingName = room?.Building?.BuildingName,
                            RoomKey = room?.RoomKey,
                            RoomName = room?.RoomName,
                            RoomCapacity = room?.NormalCapacity,
                            UnitKey = sessionViewModel.Shift.UnitKey,
                            UnitName = sessionViewModel.Shift.Unit.UnitName,
                            StartDate = sessionViewModel.StartDate,
                            EndDate = sessionViewModel.EndDate,
                            CourseName = courseName,
                            Enrollments = sessionViewModel.Shift.EnrolledStudents
                        });
                }
            }

            return calendarEventsViewModel;
        }

        private void CreateCSVFiles(List<QualityScheduleViewModel> qualitySchedules)
        {
            foreach (ScheduleTypeEnum scheduleType in (ScheduleTypeEnum[])Enum.GetValues(typeof(ScheduleTypeEnum)))
            {
                string scheduleTypeName = Enum.GetName(typeof(ScheduleTypeEnum), scheduleType);

                var folderName = Path.Combine("Resources", "Download");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fullPathToSave = Path.Combine(pathToSave, scheduleTypeName + ".csv");
                var seperator = ";";
                var sbOutput = new StringBuilder();

                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(pathToSave + @"\");
                FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles(scheduleTypeName + "*");

                foreach (FileInfo foundFile in filesInDir)
                {
                    string fileName = foundFile.FullName;

                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                }

                var header = new string[] {
                        "Curso",
                        "Unidade de Execução",
                        "Turno",
                        "Turma",
                        "Inscritos",
                        "Inicio",
                        "Fim",
                        "Dia",
                        "Caracterista",
                        "Sala",
                        "Capacidade",
                        "Edifico"
                    };

                sbOutput.AppendLine(string.Join(seperator, header));

                foreach (var calendarEventViewModel in qualitySchedules.FirstOrDefault(x => x.ScheduleType == scheduleType).EventsCalendar)
                {
                    foreach (var session in calendarEventViewModel.SessionsBasicInfo)
                    {
                        var row = new string[] {
                                session.CourseName,
                                session.UnitName,
                                session.ShiftName,
                                session.ClassName,
                                session.Enrollments.ToString(),
                                session.StartDate.ToString("HH:mm"),
                                session.EndDate.ToString("HH:mm"),
                                session.StartDate.ToString("dd/MM/yyyy"),
                                session.PropertyName,
                                session.RoomName,
                                session.RoomCapacity.ToString(),
                                session.BuildingName
                            };

                        sbOutput.AppendLine(string.Join(seperator, row));
                    }
                }

                File.WriteAllText(fullPathToSave, sbOutput.ToString(), Encoding.Unicode);
            }
        }
    }    
}