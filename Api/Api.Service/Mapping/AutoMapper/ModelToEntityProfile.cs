using Api.Domain.Entities;
using Api.Service.ViewModels;
using AutoMapper;

namespace Api.Service.Mapping.AutoMapper
{
    /// <summary>
    /// Model to entity profile
    /// </summary>
    public class ModelToEntityProfile : Profile
    {
        /// <summary>
        /// Model to entity profile constructor
        /// </summary>
        public ModelToEntityProfile()
        {
            CreateMap<BaseModel, BaseEntity>();
            CreateMap<ScheduleModel, ScheduleEntity>();

            CreateMap<BuildingViewModel, Building>();
            CreateMap<ClassViewModel, Class>();
            CreateMap<ClassShiftViewModel, ClassShift>();
            CreateMap<ConfigurationViewModel, Configuration>();
            CreateMap<CourseViewModel, Course>();
            CreateMap<CourseUnitViewModel, CourseUnit>();
            CreateMap<PropertyViewModel, Property>();
            CreateMap<QualityScheduleViewModel, QualitySchedule>();
            CreateMap<RoomViewModel, Room>();
            CreateMap<RoomPropertyViewModel, RoomProperty>();
            CreateMap<SessionViewModel, Session>();
            CreateMap<ShiftViewModel, Shift>();
            CreateMap<SlotViewModel, Slot>();
            CreateMap<UnitViewModel, Unit>();
        }
    }
}
