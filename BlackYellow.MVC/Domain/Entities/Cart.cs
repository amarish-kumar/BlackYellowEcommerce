using System.Collections.Generic;

namespace BlackYellow.MVC.Domain.Entites
{
    public class Cart
    {
        public int CartId { get; set; }

        public List<ItemCart> Itens { get; set; }

        public double TotalOrder { get; private set; }

        public User User { get; set; }


        public int GetQtdProducts()
        {
            return Itens.Count;
        }

        public double GetTotalOrder()
        {
            foreach (var item in Itens)
            {
                this.TotalOrder += item.GetSubTotal();
            }

            return this.TotalOrder;
        }

        
    }
}