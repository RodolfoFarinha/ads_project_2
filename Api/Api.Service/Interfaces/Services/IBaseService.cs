using Api.Domain.Interfaces;
using AutoMapper;

namespace Api.Service.Interfaces.Services
{
    public interface IBaseService
    {
        IMapper GetMapperInstance();

        IUnitOfWork GetUnitOfWorkInstance();

        void BeginTransaction();

        void Commit();
    }
}
