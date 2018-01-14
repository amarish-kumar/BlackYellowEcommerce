using BlackYellow.Domain.Interfaces.Services;
using System.Collections.Generic;
using BlackYellow.Domain.Entites;
using BlackYellow.Domain.Interfaces.Repositories;
using System;

namespace BlackYellow.Service
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public Order Get(long orderId)
        {
            Order order =  _orderRepository.Get(orderId);
            foreach (var item in order.Itens)
            {
              
                item.Product.GaleryProduct.Add(_productRepository.GetProductsImages(item.ProductId).GaleryProduct[0]);
            }
            return order;
        }

        public IEnumerable<Order> GetAll(long customerId)
        {
            return _orderRepository.GetAll(customerId);
        }

        //public IEnumerable<Order> GetAll(Models.OrderReportFilters filters)
        //{
        //    return _orderRepository.GetAll(filters);
        //}

        public string MontaBoleto()
        {
            string html = @"";

            return html;
        }


        long IOrderService.Insert(Order order)
        {
            return _orderRepository.Insert(order);
        }


    }
}
