using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;
using Api.Infra.Data.Repository;
using System;

namespace Api.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDBContext _apiDBContext;
        private bool _disposed;

        public UnitOfWork(ApiDBContext apiDBContext)
        {
            _apiDBContext = apiDBContext;
        }

        public IBuildingRepository BuildingRepository
        {
            get { return new BuildingRepository(_apiDBContext); }
        }

        public IClassRepository ClassRepository
        {
            get { return new ClassRepository(_apiDBContext); }
        }

        public IClassShiftRepository ClassShiftRepository
        {
            get { return new ClassShiftRepository(_apiDBContext); }
        }

        public ICourseRepository CourseRepository
        {
            get { return new CourseRepository(_apiDBContext); }
        }

        public ICourseUnitRepository CourseUnitRepository
        {
            get { return new CourseUnitRepository(_apiDBContext); }
        }

        public IPropertyRepository PropertyRepository
        {
            get { return new PropertyRepository(_apiDBContext); }
        }

        public IRoomPropertyRepository RoomPropertyRepository
        {
            get { return new RoomPropertyRepository(_apiDBContext); }
        }
        public IRoomRepository RoomRepository
        {
            get { return new RoomRepository(_apiDBContext); }
        }

        public ISessionRepository SessionRepository
        {
            get { return new SessionRepository(_apiDBContext); }
        }

        public IShiftRepository ShiftRepository
        {
            get { return new ShiftRepository(_apiDBContext); }
        }

        public IUnitRepository UnitRepository
        {
            get { return new UnitRepository(_apiDBContext); }
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _apiDBContext.SaveChanges();
        }

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
