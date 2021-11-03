using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Service.ViewModels;
using Api.Service.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Api.Service.Services
{
    public class SessionService : BaseService, ISessionService
    {
        public SessionService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        public SessionViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.SessionRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Session, SessionViewModel>(entity);
                return model;
            }
        }

        public IEnumerable<SessionViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.SessionRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Session>, IEnumerable<SessionViewModel>>(entities);
                return models;
            }
        }

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
