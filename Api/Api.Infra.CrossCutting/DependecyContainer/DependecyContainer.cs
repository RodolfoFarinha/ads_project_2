﻿using Api.Domain.Interfaces;
using Api.Infra.Data.UnitOfWork;
using Api.Infra.CrossCutting.DependecyContainer;
using Api.Service.Interfaces.Services;
using Api.Service.Mapping;
using Api.Service.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Indra.CrossCutting.DependecyContainer
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
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IUnitService, UnitService>();
        }
    }
}