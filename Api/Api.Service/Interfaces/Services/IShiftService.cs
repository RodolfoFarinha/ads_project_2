using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    public interface IShiftService
    {
        ShiftViewModel GetByKey(Guid key);

        IEnumerable<ShiftViewModel> GetAll();

        ShiftViewModel Save(ShiftViewModel obj);

        ShiftViewModel Delete(Guid key);
    }
}
