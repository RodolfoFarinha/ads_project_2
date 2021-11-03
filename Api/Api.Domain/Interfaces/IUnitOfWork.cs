using Api.Domain.Interfaces.Repositories;
using System;

namespace Api.Domain.Interfaces
{
    /// <summary>
    /// Unit of work pattern
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Building repository
        /// </summary>
        IBuildingRepository BuildingRepository { get; }

        /// <summary>
        /// Class repository
        /// </summary>
        IClassRepository ClassRepository { get; }

        /// <summary>
        /// Course repository
        /// </summary>
        ICourseRepository CourseRepository { get; }

        /// <summary>
        /// Course unit repository
        /// </summary>
        ICourseUnitRepository CourseUnitRepository { get; }

        /// <summary>
        /// Property repository
        /// </summary>
        IPropertyRepository PropertyRepository { get; }

        /// <summary>
        /// Room property repository
        /// </summary>
        IRoomPropertyRepository RoomPropertyRepository { get; }

        /// <summary>
        /// Room repository
        /// </summary>
        IRoomRepository RoomRepository { get; }

        /// <summary>
        /// Session repository
        /// </summary>
        ISessionRepository SessionRepository { get; }

        /// <summary>
        /// Shift repository
        /// </summary>
        IShiftRepository ShiftRepository { get; }

        /// <summary>
        /// Unit repository
        /// </summary>
        IUnitRepository UnitRepository { get; }

        /// <summary>
        /// Begin transaction to insert values in database
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commit changes to insert database
        /// </summary>
        void Commit();
    }
}
