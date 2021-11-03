using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    public interface IBuildingService
    {
        BuildingViewModel GetByKey(Guid key);

        IEnumerable<BuildingViewModel> GetAll();

        BuildingViewModel Save(BuildingViewModel obj);

        BuildingViewModel Delete(Guid key);
    }
}
