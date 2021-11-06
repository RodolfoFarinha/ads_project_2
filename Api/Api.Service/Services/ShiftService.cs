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
    /// Shift service
    /// </summary>
    public class ShiftService : BaseService, IShiftService
    {
        /// <summary>
        /// Shift service constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public ShiftService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        /// <summary>
        /// Method to get shift by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ShiftViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.ShiftRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Shift, ShiftViewModel>(entity);
                return model;
            }
        }

        /// <summary>
        /// Method to get all shifts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ShiftViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.ShiftRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Shift>, IEnumerable<ShiftViewModel>>(entities);
                return models;
            }
        }

        /// <summary>
        /// Method to save shift
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ShiftViewModel Save(ShiftViewModel obj)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();
                var entity = GetMapperInstance().Map<ShiftViewModel, Shift>(obj);

                if (obj.Id > 0)
                    entity = unitOfwork.ShiftRepository.Update(entity);
                else
                    entity = unitOfwork.ShiftRepository.Add(entity);

                Commit();

                return GetMapperInstance().Map<Shift, ShiftViewModel>(entity);
            }
        }

        /// <summary>
        /// Method to delete shift
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ShiftViewModel Delete(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();

                var entity = unitOfwork.ShiftRepository.GetByKey(key);
                entity.Deleted = true;

                unitOfwork.ShiftRepository.Delete(entity);

                Commit();

                return GetMapperInstance().Map<Shift, ShiftViewModel>(entity);
            }
        }
    }
}
