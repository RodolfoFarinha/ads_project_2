using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    public interface ISessionService
    {
        SessionViewModel GetByKey(Guid key);

        IEnumerable<SessionViewModel> GetAll();

        SessionViewModel Save(SessionViewModel obj);

        SessionViewModel Delete(Guid key);
    }
}
