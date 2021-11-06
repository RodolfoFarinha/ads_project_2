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
    /// Session service
    /// </summary>
    public class SessionService : BaseService, ISessionService
    {
        /// <summary>
        /// Session service constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public SessionService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        /// <summary>
        /// Method to get session by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SessionViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.SessionRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Session, SessionViewModel>(entity);
                return model;
            }
        }

        /// <summary>
        /// Method to get all sessions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SessionViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.SessionRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Session>, IEnumerable<SessionViewModel>>(entities);
                return models;
            }
        }

        /// <summary>
        /// Method to save session
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public SessionViewModel Save(SessionViewModel obj)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();
                var entity = GetMapperInstance().Map<SessionViewModel, Session>(obj);

                if (obj.Id > 0)
                    entity = unitOfwork.SessionRepository.Update(entity);
                else
                    entity = unitOfwork.SessionRepository.Add(entity);

                Commit();

                return GetMapperInstance().Map<Session, SessionViewModel>(entity);
            }
        }

        /// <summary>
        /// Method to delete session
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SessionViewModel Delete(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();

                var entity = unitOfwork.SessionRepository.GetByKey(key);
                entity.Deleted = true;

                unitOfwork.SessionRepository.Delete(entity);

                Commit();

                return GetMapperInstance().Map<Session, SessionViewModel>(entity);
            }
        }
    }
}
