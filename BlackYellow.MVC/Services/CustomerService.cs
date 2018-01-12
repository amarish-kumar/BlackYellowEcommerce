using BlackYellow.Domain.Entites;
using BlackYellow.Domain.Interfaces.Services;
using BlackYellow.Domain.Interfaces.Repositories;

namespace BlackYellow.MVC.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {

        private ICustomerRepository _customerRepository;
        private IUserRepository _userRepository;

        public CustomerService(IRepositoryBase<Customer> repository , ICustomerRepository customerRepository, IUserRepository userRepository) : base(repository)
        {
            _userRepository = userRepository;
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

        public Customer GetCustomerByEmailAndPassword(User user)
        {
            var customer = _customerRepository.GetCustomerByUserId((long) user.UserId);

            if (customer == null) return null;

            customer.User = new User();
            customer.User = user;
            return customer;
        }
    }
}
