using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Service.ViewModels;
using Api.Service.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Api.Service.Services
{
    public class ShiftService : BaseService, IShiftService
    {
        public ShiftService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        public ShiftViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.ShiftRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Shift, ShiftViewModel>(entity);
                return model;
            }
        }

        public IEnumerable<ShiftViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.ShiftRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Shift>, IEnumerable<ShiftViewModel>>(entities);
                return models;
            }
        }

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
