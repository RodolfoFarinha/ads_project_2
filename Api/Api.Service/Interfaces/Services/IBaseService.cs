using Api.Domain.Interfaces;
using AutoMapper;

namespace Api.Service.Interfaces.Services
{
    /// <summary>
    /// Base service
    /// </summary>
    public interface IBaseService
    {
        /// <summary>
        /// Method to get mapper instance
        /// </summary>
        /// <returns></returns>
        IMapper GetMapperInstance();

        /// <summary>
        /// Method to get unit of work instance
        /// </summary>
        /// <returns></returns>
        IUnitOfWork GetUnitOfWorkInstance();

        /// <summary>
        /// Method to begin transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Method to commit changes
        /// </summary>
        void Commit();
    }
}
