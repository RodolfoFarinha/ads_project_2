using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Service.ViewModels;
using Api.Service.Interfaces.Services;
using AutoMapper;
using System.Collections.Generic;
using System;

namespace Api.Service.Services
{
    public class ClassService : BaseService, IClassService
    {
        public ClassService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        public ClassViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.ClassRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Class, ClassViewModel>(entity);
                return model;
            }
        }

        public IEnumerable<ClassViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.ClassRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Class>, IEnumerable<ClassViewModel>>(entities);
                return models;
            }
        }

        public ClassViewModel Save(ClassViewModel obj)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();
                var entity = GetMapperInstance().Map<ClassViewModel, Class>(obj);

                if (obj.Id > 0)
                    entity = unitOfwork.ClassRepository.Update(entity);
                else
                    entity = unitOfwork.ClassRepository.Add(entity);

                Commit();

                return GetMapperInstance().Map<Class, ClassViewModel>(entity);
            }
        }

        public ClassViewModel Delete(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();

                var entity = unitOfwork.ClassRepository.GetByKey(key);
                entity.Deleted = true;

                unitOfwork.ClassRepository.Delete(entity);

                Commit();

                return GetMapperInstance().Map<Class, ClassViewModel>(entity);
            }
        }
    }
}
