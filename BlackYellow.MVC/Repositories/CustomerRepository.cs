using System;
using System.Linq;
using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Repositories;
using Dapper;

namespace BlackYellow.MVC.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public Customer GetCustomerByDocument(string cpf)
        {
            var sql = "select * from Customers where cpf = @cpf";
            return base.db.Connection.Query<Customer>(sql, cpf).SingleOrDefault();
        }
    }
}
