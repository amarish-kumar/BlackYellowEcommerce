using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Services;
using BlackYellow.MVC.Domain.Interfaces.Repositories;
using System;

namespace BlackYellow.MVC.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {

    private ICustomerRepository _customerRepository ;

        public CustomerService(IRepositoryBase<Customer> repository, ICustomerRepository customerRepository) : base(repository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetCustomerByDocument(string cpf)
        {
            return _customerRepository.GetCustomerByDocument(cpf);
        }
    }
}
