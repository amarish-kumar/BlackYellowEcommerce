using System;
using System.Linq;
using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BlackYellow.MVC.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {

        public override bool Insert(Customer customer)
        {

            using (var tran = base.db.Connection.BeginTransaction())
            {

                var transactionResult =
                ((customer.UserId = base.db.Connection.Insert(customer.User, tran)) > 0) &&
                ((customer.Address.CustomerId = base.db.Connection.Insert(customer, tran)) > 0) &&
                (base.db.Connection.Insert(customer.Address) > 0);

                if (transactionResult)
                    tran.Commit();
                else
                    tran.Rollback();

                return transactionResult;

            }


        }


        public Customer GetCustomerByDocument(string cpf)
        {
            var sql = "select * from Customers where cpf = @cpf";
            return base.db.Connection.Query<Customer>(sql, cpf).SingleOrDefault();
        }
    }
}
