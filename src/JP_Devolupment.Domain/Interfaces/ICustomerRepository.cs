using JP_Devolupment.Domain.Models;

namespace JP_Devolupment.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}