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
    /// Unit service
    /// </summary>
    public class UnitService : BaseService, IUnitService
    {
        /// <summary>
        /// Unit service constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public UnitService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        /// <summary>
        /// Method to get unit by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public UnitViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.UnitRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Unit, UnitViewModel>(entity);
                return model;
            }
        }

        /// <summary>
        /// Method to get all units
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UnitViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.UnitRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Unit>, IEnumerable<UnitViewModel>>(entities);
                return models;
            }
        }

        /// <summary>
        /// Method to save unit
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public UnitViewModel Save(UnitViewModel obj)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();
                var entity = GetMapperInstance().Map<UnitViewModel, Unit>(obj);

                if (obj.Id > 0)
                    entity = unitOfwork.UnitRepository.Update(entity);
                else
                    entity = unitOfwork.UnitRepository.Add(entity);

                Commit();

                return GetMapperInstance().Map<Unit, UnitViewModel>(entity);
            }
        }

        /// <summary>
        /// Method to delete unit
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public UnitViewModel Delete(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();

                var entity = unitOfwork.UnitRepository.GetByKey(key);
                entity.Deleted = true;

                unitOfwork.UnitRepository.Delete(entity);

                Commit();

                return GetMapperInstance().Map<Unit, UnitViewModel>(entity);
            }
        }
    }
}
