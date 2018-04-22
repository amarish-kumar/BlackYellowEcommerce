using BlackYellow.Domain.Entites;
using BlackYellow.Domain.Interfaces.Services;
using BlackYellow.Domain.Interfaces.Repositories;
using BlackYellow.Domain.Enum;

namespace BlackYellow.Service
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
           
            customer.User.Profile = Profile.User;

            if (!customer.IsValid())
            {
                //TODO
            }
            else if (_userRepository.GetUserByMail(customer.User.Email) != null)
            {
                //TODO
            }
            else if (!string.IsNullOrEmpty(_customerRepository.GetCustomerByDocument(customer.Cpf)?.Cpf))
            {
               // TODO
            }
            
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
