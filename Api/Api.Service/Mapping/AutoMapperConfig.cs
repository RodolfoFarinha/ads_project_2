using Api.Domain.Entities;
using Api.Service.ViewModels;
using AutoMapper;

namespace Api.Service.Mapping
{
    /// <summary>
    /// Automapper configuration
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// Method to register all mappings
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Building, BuildingViewModel>().ReverseMap();
                cfg.CreateMap<Class, ClassViewModel>().ReverseMap();
                cfg.CreateMap<ClassShift, ClassShiftViewModel>().ReverseMap();
                cfg.CreateMap<Course, CourseViewModel>().ReverseMap();
                cfg.CreateMap<CourseUnit, CourseUnitViewModel>().ReverseMap();
                cfg.CreateMap<Property, PropertyViewModel>().ReverseMap();
                cfg.CreateMap<Room, RoomViewModel>().ReverseMap();
                cfg.CreateMap<RoomProperty, RoomPropertyViewModel>().ReverseMap();             
                cfg.CreateMap<Session, SessionViewModel>().ReverseMap();
                cfg.CreateMap<Shift, ShiftViewModel>().ReverseMap();
                cfg.CreateMap<Unit, UnitViewModel>().ReverseMap();
            });
        }
    }
}
