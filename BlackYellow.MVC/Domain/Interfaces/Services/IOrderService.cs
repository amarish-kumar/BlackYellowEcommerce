using System.Collections.Generic;
using BlackYellow.MVC.Domain.Entites;

namespace BlackYellow.MVC.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll(Models.OrderReportFilters filters);

        string MontaBoleto();
    }

}
