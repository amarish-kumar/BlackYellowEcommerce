using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackYellow.MVC.Domain.Entites
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }


        public Customer Customer  { get; set; }

        public List<ItemCart> Itens { get; set; }

        public double TotalOrder { get { return this.Itens.Sum(i => i.SubTotal); } }


    }
}