using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Service.ViewModels;
using Api.Service.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Api.Service.Services
{
    public class CourseService : BaseService, ICourseService
    {
        public CourseService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        public CourseViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.CourseRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Course, CourseViewModel>(entity);
                return model;
            }
        }

        public IEnumerable<CourseViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.CourseRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(entities);
                return models;
            }
        }

        public CourseViewModel Save(CourseViewModel obj)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();
                var entity = GetMapperInstance().Map<CourseViewModel, Course>(obj);

                if (obj.Id > 0)
                    entity = unitOfwork.CourseRepository.Update(entity);
                else
                    entity = unitOfwork.CourseRepository.Add(entity);

                Commit();

                return GetMapperInstance().Map<Course, CourseViewModel>(entity);
            }
        }

        public CourseViewModel Delete(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();

                var entity = unitOfwork.CourseRepository.GetByKey(key);
                entity.Deleted = true;

                unitOfwork.CourseRepository.Delete(entity);

                Commit();

                return GetMapperInstance().Map<Course, CourseViewModel>(entity);
            }
        }
    }
}
