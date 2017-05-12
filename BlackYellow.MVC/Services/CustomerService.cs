using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Services;
using BlackYellow.MVC.Domain.Interfaces.Repositories;

namespace BlackYellow.MVC.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {

    private ICustomerRepository _customerRepository ;

        public CustomerService(IRepositoryBase<Customer> repository , ICustomerRepository customerRepository) : base(repository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetCustomerByDocument(string cpf)
        {
            return _customerRepository.GetCustomerByDocument(cpf);
        }

        public override bool Insert(Customer customer) {
            return _customerRepository.Insert(customer);
        }

        public override Customer Get(long id)
        {
            return _customerRepository.Get(id);
        }

        public override bool Update(Customer obj)
        {
            return _customerRepository.Update(obj);
        }

        public Customer GetCustomerByUserId(long id)
        {
           return  _customerRepository.GetCustomerByUserId(id);
        }
    }
}
