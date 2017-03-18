using System;
using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Repositories;

namespace BlackYellow.MVC.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public Customer GetCustomerByDocument(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
