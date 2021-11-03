using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Service.ViewModels;
using Api.Service.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Api.Service.Services
{
    public class RoomService : BaseService, IRoomService
    {
        public RoomService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        public RoomViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.RoomRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Room, RoomViewModel>(entity);
                return model;
            }
        }

        public IEnumerable<RoomViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.RoomRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(entities);
                return models;
            }
        }

        public RoomViewModel Save(RoomViewModel obj)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();
                var entity = GetMapperInstance().Map<RoomViewModel, Room>(obj);

                if (obj.Id > 0)
                    entity = unitOfwork.RoomRepository.Update(entity);
                else
                    entity = unitOfwork.RoomRepository.Add(entity);

                Commit();

                return GetMapperInstance().Map<Room, RoomViewModel>(entity);
            }
        }

        public RoomViewModel Delete(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();

                var entity = unitOfwork.RoomRepository.GetByKey(key);
                entity.Deleted = true;

                unitOfwork.RoomRepository.Delete(entity);

                Commit();

                return GetMapperInstance().Map<Room, RoomViewModel>(entity);
            }
        }
    }
}
