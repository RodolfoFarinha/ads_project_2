using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    public interface IUnitService
    {
        UnitViewModel GetByKey(Guid key);

        IEnumerable<UnitViewModel> GetAll();

        UnitViewModel Save(UnitViewModel obj);

        UnitViewModel Delete(Guid key);
    }
}
