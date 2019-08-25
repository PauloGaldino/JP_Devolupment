using JP_Devolupment.Domain.Interfaces;
using JP_Devolupment.Domain.Models;
using JP_Devolupment.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JP_Devolupment.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DevolupmentContext context)
            : base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
