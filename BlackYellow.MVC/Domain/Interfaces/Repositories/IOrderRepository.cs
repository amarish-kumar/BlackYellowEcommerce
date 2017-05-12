using System.Collections.Generic;
using BlackYellow.MVC.Domain.Entites;

namespace BlackYellow.MVC.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll(Models.OrderReportFilters filters);
        long Insert(Order order);
    }
}
