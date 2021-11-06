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
    /// Building service
    /// </summary>
    public class BuildingService : BaseService, IBuildingService
    {
        /// <summary>
        /// Building service constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public BuildingService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        /// <summary>
        /// Method to get building by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public BuildingViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.BuildingRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Building, BuildingViewModel>(entity);
                return model;
            }
        }

        /// <summary>
        /// Method to get all buildings
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BuildingViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.BuildingRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Building>, IEnumerable<BuildingViewModel>>(entities);
                return models;
            }
        }

        /// <summary>
        /// Method to save building
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to delete building
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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
