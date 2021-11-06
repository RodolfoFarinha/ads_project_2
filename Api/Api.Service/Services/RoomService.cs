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
    /// Room service
    /// </summary>
    public class RoomService : BaseService, IRoomService
    {
        /// <summary>
        /// Room service constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public RoomService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        /// <summary>
        /// Method to get room by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public RoomViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.RoomRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Room, RoomViewModel>(entity);
                return model;
            }
        }

        /// <summary>
        /// Method to get all rooms
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoomViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.RoomRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(entities);
                return models;
            }
        }

        /// <summary>
        /// Method to save room
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to delete room
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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
