using BlackYellow.MVC.Domain.Interfaces.Services;
using System.Collections.Generic;
using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Repositories;

namespace BlackYellow.MVC.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetAll(Models.OrderReportFilters filters)
        {
            return _orderRepository.GetAll(filters);
        }


    }
}
