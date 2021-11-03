using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    public interface IClassService
    {
        ClassViewModel GetByKey(Guid key);

        IEnumerable<ClassViewModel> GetAll();

        ClassViewModel Save(ClassViewModel obj);

        ClassViewModel Delete(Guid key);
    }
}
