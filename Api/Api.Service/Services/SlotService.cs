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
    /// Slot service
    /// </summary>
    public class SlotService : BaseService, ISlotService
    {
        /// <summary>
        /// Slot service constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public SlotService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }

        /// <summary>
        /// Method to get slot by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SlotViewModel GetByKey(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entity = unitOfwork.SlotRepository.GetByKey(key);
                var model = GetMapperInstance().Map<Slot, SlotViewModel>(entity);
                return model;
            }
        }

        /// <summary>
        /// Method to get all slots
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SlotViewModel> GetAll()
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                var entities = unitOfwork.SlotRepository.GetAll();
                var models = GetMapperInstance().Map<IEnumerable<Slot>, IEnumerable<SlotViewModel>>(entities);
                return models;
            }
        }

        /// <summary>
        /// Method to save slot
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public SlotViewModel Save(SlotViewModel obj)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();
                var entity = GetMapperInstance().Map<SlotViewModel, Slot>(obj);

                if (obj.Id > 0)
                    entity = unitOfwork.SlotRepository.Update(entity);
                else
                    entity = unitOfwork.SlotRepository.Add(entity);

                Commit();

                return GetMapperInstance().Map<Slot, SlotViewModel>(entity);
            }
        }

        /// <summary>
        /// Method to delete slot
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SlotViewModel Delete(Guid key)
        {
            using (var unitOfwork = GetUnitOfWorkInstance())
            {
                BeginTransaction();

                var entity = unitOfwork.SlotRepository.GetByKey(key);
                entity.Deleted = true;

                unitOfwork.SlotRepository.Delete(entity);
                
                Commit();

                return GetMapperInstance().Map<Slot, SlotViewModel>(entity);
            }
        } 
    }
}
