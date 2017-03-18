using BlackYellow.MVC.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackYellow.MVC.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Customer GetCustomerByDocument(string cpf);
    }
}
