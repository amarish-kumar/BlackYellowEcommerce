using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.MVC.Domain.Entites;

namespace BlackYellow.MVC.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll(Models.OrderReportFilters filters);
    }
}
