using Api.Domain.Interfaces;
using Api.Service.Interfaces.Services;
using AutoMapper;

namespace Api.Service.Services
{
    public class BaseService : IBaseService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BaseService (IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IMapper GetMapperInstance()
        {
            return _mapper;
        }

        public IUnitOfWork GetUnitOfWorkInstance()
        {
            return _unitOfWork;
        }

        public void BeginTransaction()
        {
            _unitOfWork.BeginTransaction();
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
