using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Service.ViewModels;
using Api.Service.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Api.Service.Services
{
    public class PropertyService : BaseService, IPropertyService
    {
        public PropertyService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        public PropertyViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.PropertyRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Property, PropertyViewModel>(entity);
                return model;
            }
        }

        public IEnumerable<PropertyViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.PropertyRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Property>, IEnumerable<PropertyViewModel>>(entities);
                return models;
            }
        }

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
