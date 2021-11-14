using Api.Domain.Entities;
using Api.Service.ViewModels;
using AutoMapper;

namespace Api.Service.Mapping.AutoMapper
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
                cfg.AddProfile(new EntityToModelProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });
        }
    }
}
