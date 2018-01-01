using System.Collections.Generic;
using BlackYellow.Domain.Entites;

namespace BlackYellow.Domain.Interfaces.Services
{
    public interface IOrderService
    {
      //  IEnumerable<Order> GetAll(Models.OrderReportFilters filters);

        string MontaBoleto();
        long Insert(Order order);
        Order Get(long id);
        IEnumerable<Order> GetAll(long customerId);
    }

}
