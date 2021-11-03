using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Service.ViewModels;
using Api.Service.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Api.Service.Services
{
    public class UnitService : BaseService, IUnitService
    {
         public UnitService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        public UnitViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.UnitRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Unit, UnitViewModel>(entity);
                return model;
            }
        }

        public IEnumerable<UnitViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.UnitRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Unit>, IEnumerable<UnitViewModel>>(entities);
                return models;
            }
        }

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
