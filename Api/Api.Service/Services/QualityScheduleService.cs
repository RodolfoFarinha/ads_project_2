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
    /// QualitySchedule service
    /// </summary>
    public class QualityScheduleService : BaseService, IQualityScheduleService
    {
        /// <summary>
        /// Quality schedule service constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public QualityScheduleService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        /// <summary>
        /// Method to get quality schedule by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public QualityScheduleViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.QualityScheduleRepository.GetByKey(key);
                var model = GetMapperInstance().Map<QualitySchedule, QualityScheduleViewModel>(entity);
                return model;
            }
        }

        /// <summary>
        /// Method to get all quality schedules
        /// </summary>
        /// <returns></returns>
        public IEnumerable<QualityScheduleViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.QualityScheduleRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<QualitySchedule>, IEnumerable<QualityScheduleViewModel>>(entities);
                return models;
            }
        }

        /// <summary>
        /// Method to save quality schedule
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public QualityScheduleViewModel Save(QualityScheduleViewModel obj)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();
                var entity = GetMapperInstance().Map<QualityScheduleViewModel, QualitySchedule>(obj);

                if (obj.Id > 0)
                    entity = unitOfwork.QualityScheduleRepository.Update(entity);
                else
                    entity = unitOfwork.QualityScheduleRepository.Add(entity);

                Commit();

                return GetMapperInstance().Map<QualitySchedule, QualityScheduleViewModel>(entity);
            }
        }

        /// <summary>
        /// Method to delete quality schedule
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public QualityScheduleViewModel Delete(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();

                var entity = unitOfwork.QualityScheduleRepository.GetByKey(key);
                entity.Deleted = true;

                unitOfwork.QualityScheduleRepository.Delete(entity);
                
                Commit();

                return GetMapperInstance().Map<QualitySchedule, QualityScheduleViewModel>(entity);
            }
        } 
    }
}
