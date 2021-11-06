using Api.Domain.Entities;
using Api.Service.ViewModels;
using AutoMapper;

namespace Api.Service.Mapping
{
    /// <summary>
    /// Entity to model profile
    /// </summary>
    public class EntityToModelProfile : Profile
    {
        /// <summary>
        /// Entity to model profile constructor
        /// </summary>
        public EntityToModelProfile()
        {
            CreateMap<BaseEntity, BaseModel>();
            CreateMap<ScheduleEntity, ScheduleModel>();

            CreateMap<Building, BuildingViewModel>();
            CreateMap<Class, ClassViewModel>();
            CreateMap<ClassShift, ClassShiftViewModel>();
            CreateMap<Configuration, ConfigurationViewModel>();
            CreateMap<Course, CourseViewModel>();
            CreateMap<CourseUnit, CourseUnitViewModel>();
            CreateMap<Property, PropertyViewModel>();
            CreateMap<QualitySchedule, QualityScheduleViewModel>();
            CreateMap<Room, RoomViewModel>();
            CreateMap<RoomProperty, RoomPropertyViewModel>();
            CreateMap<Session, SessionViewModel>();
            CreateMap<Shift, ShiftViewModel>();
            CreateMap<Slot, SlotViewModel>();
            CreateMap<Unit, UnitViewModel>();
        }
    }
}
