using BlackYellow.Authentication.Domain.Customers;

using BlackYellow.Authetication.Data.Context;
using System;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Linq;
using BlackYellow.Authentication.Users;
using BlackYellow.Core.Domain.Interfaces;
using BlackYellow.Authentication.Domain.Customers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlackYellow.Authetication.Data.Repository
{
    public class CustomerRepository : Repository<Customer> , ICustomerRepository
    {

        public CustomerRepository(CustomerEFContext context)
            : base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.User.Email == email);
        }
    }
}
