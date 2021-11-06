using Api.Domain.Interfaces;
using Api.Service.Interfaces.Services;
using AutoMapper;

namespace Api.Service.Services
{
    /// <summary>
    /// Base service
    /// </summary>
    public class BaseService : IBaseService
    {
        /// <summary>
        /// Get and set mapper
        /// </summary>
        private readonly IMapper _mapper;
        
        /// <summary>
        /// Get and set unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Base service constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public BaseService (IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Method to get mapper instance
        /// </summary>
        /// <returns></returns>
        public IMapper GetMapperInstance()
        {
            return _mapper;
        }

        /// <summary>
        /// Method to get unit of work instance
        /// </summary>
        /// <returns></returns>
        public IUnitOfWork GetUnitOfWorkInstance()
        {
            return _unitOfWork;
        }

        /// <summary>
        /// Method to begin transaction
        /// </summary>
        public void BeginTransaction()
        {
            _unitOfWork.BeginTransaction();
        }

        /// <summary>
        /// Method to commit changes
        /// </summary>
        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
