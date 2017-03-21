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

            using (var cn = base.db.Connection)
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {


                    var insertUser = ((customer.UserId = cn.Insert(customer.User, tran)) > 0);
                    var insertCustomer = ((customer.CustomerId = customer.Address.CustomerId = cn.Insert(customer, tran)) > 0);
                    var insertAddress = ((customer.Address.AddressId = cn.Insert(customer.Address, tran)) > 0);

                    var transactionResult = insertUser && insertCustomer && insertAddress;

                    if (transactionResult)
                        tran.Commit();
                    else
                        tran.Rollback();

                    return transactionResult;

                }
            }

        }


        public Customer GetCustomerByDocument(string cpf)
        {
            var sql = "select * from Customers where cpf = @cpf";
            return base.db.Connection.Query<Customer>(sql, new { cpf = cpf }).SingleOrDefault();
        }
    }
}
