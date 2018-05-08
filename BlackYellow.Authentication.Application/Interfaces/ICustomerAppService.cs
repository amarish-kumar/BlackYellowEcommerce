using BlackYellow.Authentication.Application.ViewModels;
using BlackYellow.Authentication.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Authentication.Application.Interfaces
{
    public interface ICustomerAppService
    {

        void Add(CustomerViewModel customerViewModel);

        bool Update(Customer customer);

        bool Delete(Customer customer);

        Customer Get(long id);

        Customer GetByCPF(string cpf);

        Customer GetByEmail(string email);
    }
}
