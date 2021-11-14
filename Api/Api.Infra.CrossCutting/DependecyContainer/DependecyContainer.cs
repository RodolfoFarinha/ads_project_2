using Api.Domain.Interfaces;
using Api.Infra.Data.UnitOfWork;
using Api.Service.Interfaces.Services;
using Api.Service.Mapping.AutoMapper;
using Api.Service.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace Api.Infra.CrossCutting.DependecyContainer
{
    /// <summary>
    /// Dependecy container register
    /// </summary>
    public static class DependecyContainer
    {
        /// <summary>
        /// Method to add configuration, automapper and register services on service collection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddApiConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseSetup(configuration);

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             );

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    policy =>
                    {
                        policy
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                    });
            });

            services.AddAutoMapper(typeof(AutoMapperConfig));
            
            services.RegisterServices();
        }

        /// <summary>
        /// Method to register all services
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IPropertyService, PropertyService>(); 
            services.AddScoped<IQualityScheduleService, QualityScheduleService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IScheduleCalculatorService, ScheduleCalculatorService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<ISlotService, SlotService>();
            services.AddScoped<IUnitService, UnitService>();
        }
    }
}
