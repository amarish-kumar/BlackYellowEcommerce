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

        public override Customer Get(long id)
        {
            try
            {

                var sql = @"SELECT  a.AddressId, c.CustomerId, c.FirstName, c.LastName, c.Birthday, c.Cpf, c.Phone, a.AddressId, a.Street, a.Number, a.ZipCode, a.State, a.City
                                FROM Customers c INNER JOIN
                                Adresses a ON c.CustomerId = a.CustomerId
                                WHERE c.CustomerId = " + id;


                return db.Connection.Query<Customer, Address, Customer>(sql,
                      (c, a) => { c.Address = a; return c; }, splitOn: "AddressId").First();


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Customer GetCustomerByUserId(long id)
        {
            try
            {
                var sql = "SELECT * FROM Customers c INNER JOIN Users u ON c.UserId = u.UserId WHERE u.UserId =" + id;

                var customer = db.Connection.Query<Customer>(sql
                 ).First();

                return customer;
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public override bool Update(Customer obj)
        {
            try
            {
                obj.Address.CustomerId = obj.CustomerId;
                db.Connection.Update(obj.Address);
                //  db.Connection.Update(obj.User);
                //  obj.User = null;
                obj.Address = null;
                obj.UserId = obj.User.UserId;
                db.Connection.Update(obj);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}
