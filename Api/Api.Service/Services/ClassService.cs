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
    /// Class service
    /// </summary>
    public class ClassService : BaseService, IClassService
    {
        /// <summary>
        /// Class service constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public ClassService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        /// <summary>
        /// Method to get class by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ClassViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.ClassRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Class, ClassViewModel>(entity);
                return model;
            }
        }

        /// <summary>
        /// Method to get all classs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ClassViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.ClassRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Class>, IEnumerable<ClassViewModel>>(entities);
                return models;
            }
        }

        /// <summary>
        /// Method to save class
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to delete class
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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
