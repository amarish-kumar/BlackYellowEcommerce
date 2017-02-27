using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Services;
using BlackYellow.MVC.Domain.Interfaces.Repositories;


namespace BlackYellow.MVC.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        public CustomerService(IRepositoryBase<Customer> repository) : base(repository)
        {

        }
    }
}
