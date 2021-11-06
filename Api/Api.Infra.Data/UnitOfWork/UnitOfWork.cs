using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;
using Api.Infra.Data.Repository;
using System;

namespace Api.Infra.Data.UnitOfWork
{
    /// <summary>
    /// Unit of work pattern
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Application database context
        /// </summary>
        private readonly ApiDBContext _apiDBContext;
        
        /// <summary>
        /// Disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Unit of work constructor
        /// </summary>
        /// <param name="apiDBContext"></param>
        public UnitOfWork(ApiDBContext apiDBContext)
        {
            _apiDBContext = apiDBContext;
        }

        /// <summary>
        /// Building instance repository
        /// </summary>
        public IBuildingRepository BuildingRepository
        {
            get { return new BuildingRepository(_apiDBContext); }
        }

        /// <summary>
        /// Class instance repository
        /// </summary>
        public IClassRepository ClassRepository
        {
            get { return new ClassRepository(_apiDBContext); }
        }

        /// <summary>
        /// Class shift instance repository
        /// </summary>
        public IClassShiftRepository ClassShiftRepository
        {
            get { return new ClassShiftRepository(_apiDBContext); }
        }

        /// <summary>
        /// Course instance repository
        /// </summary>
        public ICourseRepository CourseRepository
        {
            get { return new CourseRepository(_apiDBContext); }
        }

        /// <summary>
        /// Course unit instance repository
        /// </summary>
        public ICourseUnitRepository CourseUnitRepository
        {
            get { return new CourseUnitRepository(_apiDBContext); }
        }

        /// <summary>
        /// Property instance repository
        /// </summary>
        public IPropertyRepository PropertyRepository
        {
            get { return new PropertyRepository(_apiDBContext); }
        }

        /// <summary>
        /// Quality schedule instance repository
        /// </summary>
        public IQualityScheduleRepository QualityScheduleRepository
        {
            get { return new QualityScheduleRepository(_apiDBContext); }
        }

        /// <summary>
        /// Room property instance repository
        /// </summary>
        public IRoomPropertyRepository RoomPropertyRepository
        {
            get { return new RoomPropertyRepository(_apiDBContext); }
        }

        /// <summary>
        /// Room instance repository
        /// </summary>
        public IRoomRepository RoomRepository
        {
            get { return new RoomRepository(_apiDBContext); }
        }

        /// <summary>
        /// Session instance repository
        /// </summary>
        public ISessionRepository SessionRepository
        {
            get { return new SessionRepository(_apiDBContext); }
        }

        /// <summary>
        /// Shift instance repository
        /// </summary>
        public IShiftRepository ShiftRepository
        {
            get { return new ShiftRepository(_apiDBContext); }
        }

        /// <summary>
        /// Slot instance repository
        /// </summary>
        public ISlotRepository SlotRepository
        {
            get { return new SlotRepository(_apiDBContext); }
        }

        /// <summary>
        /// Unit instance repository
        /// </summary>
        public IUnitRepository UnitRepository
        {
            get { return new UnitRepository(_apiDBContext); }
        }

        /// <summary>
        /// Begin transaction
        /// </summary>
        public void BeginTransaction()
        {
            _disposed = false;
        }

        /// <summary>
        /// Commit changes
        /// </summary>
        public void Commit()
        {
            _apiDBContext.SaveChanges();
        }

       /// <summary>
       /// Dispose
       /// </summary>
       /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _apiDBContext.Dispose();
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Dipose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
