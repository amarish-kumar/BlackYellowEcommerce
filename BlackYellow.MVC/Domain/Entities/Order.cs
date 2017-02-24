using System.Collections.Generic;

namespace BlackYellow.MVC.Domain.Entites
{
    public class Order
    {
        public int OrderId { get; set; }

        public Customer Customer  { get; set; }

        public List<ItemCart> Itens { get; set; }

        public double TotalOrder { get; private set; }

        public double GetTotalOrder()
        {
            foreach (var item in Itens)
            {
                this.TotalOrder = item.GetSubTotal();
            }

            return this.TotalOrder;
        }


    }
}