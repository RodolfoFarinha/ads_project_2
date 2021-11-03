using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Service.ViewModels;
using Api.Service.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Api.Service.Services
{
    public class BuildingService : BaseService, IBuildingService
    {
        public BuildingService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        public BuildingViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.BuildingRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Building, BuildingViewModel>(entity);
                return model;
            }
        }

        public IEnumerable<BuildingViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.BuildingRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Building>, IEnumerable<BuildingViewModel>>(entities);
                return models;
            }
        }

        public BuildingViewModel Save(BuildingViewModel obj)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();
                var entity = GetMapperInstance().Map<BuildingViewModel, Building>(obj);

                if (obj.Id > 0)
                    entity = unitOfwork.BuildingRepository.Update(entity);
                else
                    entity = unitOfwork.BuildingRepository.Add(entity);

                Commit();

                return GetMapperInstance().Map<Building, BuildingViewModel>(entity);
            }
        }

        public BuildingViewModel Delete(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();

                var entity = unitOfwork.BuildingRepository.GetByKey(key);
                entity.Deleted = true;

                unitOfwork.BuildingRepository.Delete(entity);
                
                Commit();

                return GetMapperInstance().Map<Building, BuildingViewModel>(entity);
            }
        } 
    }
}
