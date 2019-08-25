using JP_Devolupment.Application.EventSourcedNormalizers;
using JP_Devolupment.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace JP_Devolupment.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
        IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
