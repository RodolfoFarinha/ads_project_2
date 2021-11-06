using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Service.ViewModels;
using Api.Service.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Api.Service.Services
{
    /// <summary>
    /// Configuration service
    /// </summary>
    public class ConfigurationService : BaseService, IConfigurationService
    {
        /// <summary>
        /// Configuration service constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public ConfigurationService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        /// <summary>
        /// Method to get configuration by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ConfigurationViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.ConfigurationRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Configuration, ConfigurationViewModel>(entity);
                return model;
            }
        }

        /// <summary>
        /// Method to get all configurations
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConfigurationViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.ConfigurationRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Configuration>, IEnumerable<ConfigurationViewModel>>(entities);
                return models;
            }
        }

        /// <summary>
        /// Method to save configuration
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ConfigurationViewModel Save(ConfigurationViewModel obj)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();
                var entity = GetMapperInstance().Map<ConfigurationViewModel, Configuration>(obj);

                if (obj.Id > 0)
                    entity = unitOfwork.ConfigurationRepository.Update(entity);
                else
                    entity = unitOfwork.ConfigurationRepository.Add(entity);

                Commit();

                return GetMapperInstance().Map<Configuration, ConfigurationViewModel>(entity);
            }
        }

        /// <summary>
        /// Method to delete configuration
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ConfigurationViewModel Delete(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();

                var entity = unitOfwork.ConfigurationRepository.GetByKey(key);
                entity.Deleted = true;

                unitOfwork.ConfigurationRepository.Delete(entity);
                
                Commit();

                return GetMapperInstance().Map<Configuration, ConfigurationViewModel>(entity);
            }
        } 
    }
}
