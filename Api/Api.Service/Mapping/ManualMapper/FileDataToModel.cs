using Api.Domain.Enum;
using Api.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Service.Mapping.ManualMapper
{
    /// <summary>
    /// Convert file data to models
    /// </summary>
    public class FileDataToModel
    {
        private readonly IEnumerable<ConfigurationViewModel> _configurations;

        /// <summary>
        /// Constructor file data to model 
        /// </summary>
        /// <param name="configurations"></param>
        public FileDataToModel(IEnumerable<ConfigurationViewModel> configurations)
        {
            _configurations = configurations;
        }

        /// <summary>
        /// Method for mapping properties data to property model
        /// </summary>
        /// <param name="propertiesData"></param>
        /// <returns></returns>
        public List<PropertyViewModel> MappingPropertyViewModel(Tuple<string[], List<string[]>> propertiesData)
        {
            List<PropertyViewModel> properties = new List<PropertyViewModel>();

            foreach (string[] propertiyLine in propertiesData.Item2)
            {
                properties.Add(new PropertyViewModel()
                {
                    PropertyKey = Guid.NewGuid(),
                    PropertyName = GetValueString(ConfigurationEnum.PropertyName, propertiesData.Item1, propertiyLine),
                    PropertyDescription = GetValueString(ConfigurationEnum.PropertyDescription, propertiesData.Item1, propertiyLine),
                    PropertyStatus = GetValueBool(ConfigurationEnum.PropertyStatus, propertiesData.Item1, propertiyLine),
                    AvailableManagement = GetValueBool(ConfigurationEnum.AvailableManagement, propertiesData.Item1, propertiyLine),
                    AvailableRequest = GetValueBool(ConfigurationEnum.AvailableRequest, propertiesData.Item1, propertiyLine)
                });
            }

            return properties;
        }

        /// <summary>
        /// Method for mapping rooms data to property model
        /// </summary>
        /// <param name="scheduleModel"></param>
        /// <param name="roomsData"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public List<RoomViewModel> MappingRoomViewModel(ScheduleModel scheduleModel, Tuple<string[], List<string[]>> roomsData, List<PropertyViewModel> properties)
        {
            List<RoomViewModel> rooms = new List<RoomViewModel>();

            foreach(string[] roomLine in roomsData.Item2)
            {
                BuildingViewModel building = rooms.Where(x => x.Building.BuildingName == GetValueString(ConfigurationEnum.BuildingName, roomsData.Item1, roomLine))
                    .Select(x => x.Building).FirstOrDefault() ?? new BuildingViewModel() 
                    {
                        ScheduleKey = scheduleModel.ScheduleKey,
                        ScheduleVersion = scheduleModel.ScheduleVersion,
                        BuildingKey = Guid.NewGuid(),
                        BuildingName = GetValueString(ConfigurationEnum.BuildingName, roomsData.Item1, roomLine)
                    };

                Guid roomKey = Guid.NewGuid();

                RoomViewModel roomViewModel = new RoomViewModel()
                {
                    ScheduleKey = scheduleModel.ScheduleKey,
                    ScheduleVersion = scheduleModel.ScheduleVersion,
                    RoomKey = roomKey,
                    BuildingKey = building.BuildingKey,
                    Building = building,
                    RoomName = GetValueString(ConfigurationEnum.RoomName, roomsData.Item1, roomLine),
                    NormalCapacity = GetValueInt(ConfigurationEnum.NormalCapacity, roomsData.Item1, roomLine),
                    ExamCapacity = GetValueInt(ConfigurationEnum.ExamCapacity, roomsData.Item1, roomLine)
                };

                roomViewModel.RoomProperties = GetRoomProperties(roomViewModel, properties, roomsData.Item1, roomLine);

                building.Rooms.Add(roomViewModel);

                rooms.Add(roomViewModel);
            }

            return rooms;
        }

        /// <summary>
        /// Method for mapping sessions data to property model
        /// </summary>
        /// <param name="scheduleModel"></param>
        /// <param name="sessionsData"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public List<SessionViewModel> MappingSessionViewModel(ScheduleModel scheduleModel, Tuple<string[], List<string[]>> sessionsData, List<PropertyViewModel> properties)
        {
            Dictionary<string, CourseViewModel> courses = new Dictionary<string, CourseViewModel>();
            Dictionary<string, ClassViewModel> classes = new Dictionary<string, ClassViewModel>();

            Dictionary<string, UnitViewModel> units = new Dictionary<string, UnitViewModel>();
            Dictionary<string, ShiftViewModel> shifts = new Dictionary<string, ShiftViewModel>();

            List<SessionViewModel> sessions = new List<SessionViewModel>();

            foreach (string[] sessionLine in sessionsData.Item2)
            {
                UnitViewModel unit = null;    
                units.TryGetValue(GetValueString(ConfigurationEnum.UnitName, sessionsData.Item1, sessionLine), out unit);
                
                if(unit == null)
                {
                    unit = new UnitViewModel()
                    {
                        ScheduleKey = scheduleModel.ScheduleKey,
                        ScheduleVersion = scheduleModel.ScheduleVersion,
                        UnitKey = Guid.NewGuid(),
                        UnitName = GetValueString(ConfigurationEnum.UnitName, sessionsData.Item1, sessionLine)
                    };

                    units.Add(unit.UnitName, unit);
                }

                ShiftViewModel shift = null;
                shifts.TryGetValue(GetValueString(ConfigurationEnum.ShiftName, sessionsData.Item1, sessionLine), out shift);

                DateTime startDate = new DateTime();
                DateTime endDate = new DateTime();

                if (DateTime.TryParse(GetValueString(ConfigurationEnum.Day, sessionsData.Item1, sessionLine), out startDate) &&
                    DateTime.TryParse(GetValueString(ConfigurationEnum.Day, sessionsData.Item1, sessionLine), out endDate))
                {
                    startDate = Convert.ToDateTime(
                        GetValueString(ConfigurationEnum.Day, sessionsData.Item1, sessionLine) + " " +
                        GetValueString(ConfigurationEnum.StartDate, sessionsData.Item1, sessionLine));

                    endDate = Convert.ToDateTime(
                        GetValueString(ConfigurationEnum.Day, sessionsData.Item1, sessionLine) + " " +
                        GetValueString(ConfigurationEnum.EndDate, sessionsData.Item1, sessionLine));
                }

                if (shift == null)
                {
                    shift = new ShiftViewModel()
                    {
                        ScheduleKey = scheduleModel.ScheduleKey,
                        ScheduleVersion = scheduleModel.ScheduleVersion,
                        ShiftKey = Guid.NewGuid(),
                        UnitKey = unit.UnitKey,
                        Unit = unit,
                        ShiftName = GetValueString(ConfigurationEnum.ShiftName, sessionsData.Item1, sessionLine),
                        ShiftType = startDate.Hour < 18 ? ShiftEnum.Work : ShiftEnum.AfterWork,
                        EnrolledStudents = GetValueInt(ConfigurationEnum.EnrolledStudents, sessionsData.Item1, sessionLine)
                    };

                    shifts.Add(shift.ShiftName, shift);
                };

                Guid sessionKey = Guid.NewGuid();
                PropertyViewModel propertyViewModel = GetSessionPropertyKey(properties, sessionsData.Item1, sessionLine);

                SessionViewModel sessionViewModel = new SessionViewModel()
                {
                    ScheduleKey = scheduleModel.ScheduleKey,
                    ScheduleVersion = scheduleModel.ScheduleVersion,
                    SessionKey = sessionKey,
                    ShiftKey = shift.ShiftKey,
                    Shift = shift,
                    PropertyKey = propertyViewModel?.PropertyKey ?? Guid.Empty,
                    Property = propertyViewModel,
                    StartDate = startDate,
                    EndDate = endDate
                };

                shift.Sessions.Add(sessionViewModel);

                GetClassShifts(scheduleModel, shift, classes, sessionsData.Item1, sessionLine);
                GetCourseUnits(scheduleModel, unit, courses, sessionsData.Item1, sessionLine);

                unit.Shifts.Add(shift);

                sessions.Add(sessionViewModel);
            }

            return sessions;
        }

        /// <summary>
        /// Method for get string value from configurations 
        /// </summary>
        /// <param name="convigurationType"></param>
        /// <param name="columns"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        private string GetValueString(ConfigurationEnum convigurationType, string[] columns, string[] line)
        {
            string configurationValue = _configurations.FirstOrDefault(x => x.ConfigurationType == convigurationType).Value;
            int indexColumn = Array.IndexOf(columns, configurationValue);

            return line[indexColumn];
        }

        /// <summary>
        /// Method for get string value from configurations 
        /// </summary>
        /// <param name="convigurationType"></param>
        /// <param name="columns"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        private string[] GetValuesString(ConfigurationEnum convigurationType, string[] columns, string[] line)
        {
            string configurationValue = _configurations.FirstOrDefault(x => x.ConfigurationType == convigurationType).Value;
            int indexColumn = Array.IndexOf(columns, configurationValue);

            return line[indexColumn].Split(",");
        }

        /// <summary>
        /// Method for get int value from configurations 
        /// </summary>
        /// <param name="convigurationType"></param>
        /// <param name="columns"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        private int GetValueInt(ConfigurationEnum convigurationType, string[] columns, string[] line)
        {
            string configurationValue = _configurations.FirstOrDefault(x => x.ConfigurationType == convigurationType).Value;
            int indexColumn = Array.IndexOf(columns, configurationValue);

            int number = 0;

            if(Int32.TryParse(line[indexColumn], out number))
                number = Convert.ToInt32(number);

            return number;
        }

        /// <summary>
        /// Method for get bool value from configurations 
        /// </summary>
        /// <param name="convigurationType"></param>
        /// <param name="columns"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        private bool GetValueBool(ConfigurationEnum convigurationType, string[] columns, string[] line)
        {
            string configurationValue = _configurations.FirstOrDefault(x => x.ConfigurationType == convigurationType).Value;
            int indexColumn = Array.IndexOf(columns, configurationValue);

            bool boolean = false;

            if (Boolean.TryParse(line[indexColumn], out boolean))
                boolean = Convert.ToBoolean(line[indexColumn]);

            return boolean;
        }

        /// <summary>
        /// Method for get room properties from room and properties 
        /// </summary>
        /// <param name="roomViewModel"></param>
        /// <param name="properties"></param>
        /// <param name="columns"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        private List<RoomPropertyViewModel> GetRoomProperties(RoomViewModel roomViewModel, List<PropertyViewModel> properties, string[] columns, string[] line)
        {
            List<RoomPropertyViewModel> roomProperties = new List<RoomPropertyViewModel>();

            foreach (string column in columns)
            {
                PropertyViewModel propertyViewModel = properties.FirstOrDefault(x => x.PropertyName == column);

                if (propertyViewModel != null)
                {
                    int indexColumn = Array.IndexOf(columns, column);

                    if (line[indexColumn] != string.Empty && line[indexColumn].ToLower() != "false" && line[indexColumn].ToLower() != "falso")
                        roomProperties.Add(new RoomPropertyViewModel()
                        {
                            RoomPropertyKey = Guid.NewGuid(),
                            RoomKey = roomViewModel.RoomKey,
                            Room = roomViewModel,
                            PropertyKey = propertyViewModel.PropertyKey,
                            Property = propertyViewModel
                        });
                }
            }

            return roomProperties;
        }

        /// <summary>
        /// Method for get property from properties 
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="columns"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        private PropertyViewModel GetSessionPropertyKey(List<PropertyViewModel> properties, string[] columns, string[] line)
        {
            string configurationValue = _configurations.FirstOrDefault(x => x.ConfigurationType == ConfigurationEnum.PropertySessionName).Value;
            int indexColumn = Array.IndexOf(columns, configurationValue);

            return properties.FirstOrDefault(x => x.PropertyName == line[indexColumn]);
        }

        /// <summary>
        /// Method for get course units from unit and courses 
        /// </summary>
        /// <param name="scheduleModel"></param>
        /// <param name="unit"></param>
        /// <param name="courses"></param>
        /// <param name="columns"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        private void GetCourseUnits(ScheduleModel scheduleModel, UnitViewModel unit, Dictionary<string, CourseViewModel> courses, string[] columns, string[] line)
        {
            string[] courseNames = GetValuesString(ConfigurationEnum.CourseName, columns, line);

            foreach (string courseName in courseNames)
            {
                CourseViewModel course = null;
                courses.TryGetValue(courseName.Trim(), out course);

                if (course == null)
                {
                    course = new CourseViewModel()
                    {
                        ScheduleKey = scheduleModel.ScheduleKey,
                        ScheduleVersion = scheduleModel.ScheduleVersion,
                        CourseKey = Guid.NewGuid(),
                        CourseType = courseName.StartsWith("M") ? CourseEnum.Master : CourseEnum.Degree,
                        CourseName = courseName.Trim()
                    };

                    courses.Add(course.CourseName, course);
                }

                CourseUnitViewModel courseUnit = new CourseUnitViewModel()
                {
                    CourseUnitKey = Guid.NewGuid(),
                    CourseKey = course.CourseKey,
                    Course = course,
                    UnitKey = unit.UnitKey,
                    Unit = unit
                };


                course.CourseUnits.Add(courseUnit);
                unit.UnitCourses.Add(courseUnit);
            }
        }

        /// <summary>
        /// Method for get class shifts from shift and classes 
        /// </summary>
        /// <param name="scheduleModel"></param>
        /// <param name="shift"></param>
        /// <param name="classes"></param>
        /// <param name="columns"></param>
        /// <param name="line"></param>
        private void GetClassShifts(ScheduleModel scheduleModel, ShiftViewModel shift, Dictionary<string, ClassViewModel> classes, string[] columns, string[] line)
        {
            ClassViewModel classV = null;
            classes.TryGetValue(GetValueString(ConfigurationEnum.ClassName, columns, line), out classV);

            if (classV == null)
            {
                classV = new ClassViewModel()
                {
                    ScheduleKey = scheduleModel.ScheduleKey,
                    ScheduleVersion = scheduleModel.ScheduleVersion,
                    ClassKey = Guid.NewGuid(),
                    ClassName = GetValueString(ConfigurationEnum.ClassName, columns, line),
                };

                classes.Add(classV.ClassName, classV);
            }

            ClassShiftViewModel classShift = new ClassShiftViewModel()
            {
                ClassShiftKey = Guid.NewGuid(),
                ClassKey = classV.ClassKey,
                Class = classV,
                ShiftKey = shift.UnitKey,
                Shift = shift
            };

            classV.ClassShifts.Add(classShift);
            shift.ShiftClasses.Add(classShift);
        }
    }
}
