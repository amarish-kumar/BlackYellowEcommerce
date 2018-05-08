using BlackYellow.Authentication.Domain.Customers;
using BlackYellow.Core.Domain.Interfaces;

namespace BlackYellow.Authentication.Domain.Customers.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}