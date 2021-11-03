using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    public interface IRoomService
    {
        RoomViewModel GetByKey(Guid key);

        IEnumerable<RoomViewModel> GetAll();

        RoomViewModel Save(RoomViewModel obj);

        RoomViewModel Delete(Guid key);
    }
}
