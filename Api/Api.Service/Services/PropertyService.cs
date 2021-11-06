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
    /// Property service
    /// </summary>
    public class PropertyService : BaseService, IPropertyService
    {
        /// <summary>
        /// Property service constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public PropertyService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        /// <summary>
        /// Method to get property by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public PropertyViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.PropertyRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Property, PropertyViewModel>(entity);
                return model;
            }
        }

        /// <summary>
        /// Method to get all properties
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PropertyViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.PropertyRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Property>, IEnumerable<PropertyViewModel>>(entities);
                return models;
            }
        }

        /// <summary>
        /// Method to save property
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public PropertyViewModel Save(PropertyViewModel obj)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();
                var entity = GetMapperInstance().Map<PropertyViewModel, Property>(obj);

                if (obj.Id > 0)
                    entity = unitOfwork.PropertyRepository.Update(entity);
                else
                    entity = unitOfwork.PropertyRepository.Add(entity);

                Commit();

                return GetMapperInstance().Map<Property, PropertyViewModel>(entity);
            }
        }

        /// <summary>
        /// Method to delete property
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public PropertyViewModel Delete(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();

                var entity = unitOfwork.PropertyRepository.GetByKey(key);
                entity.Deleted = true;

                unitOfwork.PropertyRepository.Delete(entity);

                Commit();

                return GetMapperInstance().Map<Property, PropertyViewModel>(entity);
            }
        }
    }
}
