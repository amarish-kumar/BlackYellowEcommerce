using BlackYellow.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using BlackYellow.Domain.Entites;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Linq;

namespace BlackYellow.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {

        public override Order Get(long orderId)
        {

            return GetAll("WHERE Orders.OrderId = @orderId", new { orderId }).FirstOrDefault();

        }

        public IEnumerable<Order> GetAll(long customerId)
        {
            return GetAll("WHERE Orders.CustomerId = @customerId", new { customerId });
        }

        //public IEnumerable<Order> GetAll(Models.OrderReportFilters filters)
        //{
        //    return GetAll("WHERE cast(Orders.OrderDate as date) BETWEEN @InitDate AND @EndDate AND Orders.OrderStatus in @Status", filters);
        //}

        private IEnumerable<Order> GetAll(string where, object param)
        {

            var @return = new Dictionary<long, Order>();

            var sql = $@"SELECT * 
                            FROM Orders
                            INNER JOIN Customers
                                ON Orders.CustomerId = Customers.CustomerId
                            INNER JOIN Adresses
                                ON Adresses.CustomerId = Customers.CustomerId
                            INNER JOIN Users
                                ON Users.UserId = Customers.UserId
                            INNER JOIN CartsItems
                                ON CartsItems.OrderId = Orders.OrderId
                            INNER JOIN Products
                                ON Products.ProductId = CartsItems.ProductId
                            INNER JOIN Categories
                                ON Categories.CategoryId = Products.CategoryId
                           {where}";

            var queryResult = base.db.Connection.Query<Order, Customer, Address, User, ItemCart, Product, Category, Order>(sql,
                splitOn: "CustomerId,AddressId,UserId,ItemCartId,ProductId,CategoryId",
                map: (ord, cust, addr, user, item, prod, cat) =>
                {

                    Order result;

                    if (!@return.TryGetValue(ord.OrderId, out result))
                    {
                        result = ord;
                        @return.Add(result.OrderId, result);
                    }

                    result.Customer = cust;
                    result.Customer.Address = addr;
                    result.Customer.User = user;

                    if (result.Itens == null)
                        result.Itens = new List<ItemCart>();

                    if (!result.Itens.Contains(item))
                        result.Itens.Add(item);

                    item.Product = prod;
                    item.Product.Category = cat;

                    return ord;

                },
                param: param);

            return @return.Values;

        }

        long IOrderRepository.Insert(Order order)
        {
            return base.db.Connection.Insert(order);
        }
    }
}
