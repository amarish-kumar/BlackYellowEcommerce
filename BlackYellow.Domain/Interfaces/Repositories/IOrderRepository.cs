using System.Collections.Generic;
using BlackYellow.Domain.Entites;

namespace BlackYellow.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
     //   IEnumerable<Order> GetAll(Models.OrderReportFilters filters);
        long Insert(Order order);
        Order Get(long orderId);
        IEnumerable<Order> GetAll(long customerId);
    }
}
