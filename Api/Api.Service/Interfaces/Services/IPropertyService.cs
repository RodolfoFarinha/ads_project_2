using Api.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Api.Service.Interfaces.Services
{
    public interface IPropertyService
    {
        PropertyViewModel GetByKey(Guid key);

        IEnumerable<PropertyViewModel> GetAll();

        PropertyViewModel Save(PropertyViewModel obj);

        PropertyViewModel Delete(Guid key);
    }
}
