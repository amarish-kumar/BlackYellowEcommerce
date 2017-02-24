using System.Collections.Generic;

namespace BlackYellow.MVC.Domain.Entites
{
    public class Cart
    {
        public int CartId { get; set; }

        public List<Product> Products { get; set; }

        public double TotalOrder { get; set; }

        public User User { get; set; }


        public int GetQtdProducts()

        {
            return Products.Count;
        }

        public double GetTotalOrder()
        {
            foreach (var product in Products)
            {
                this.TotalOrder += product.Price * product.Quantity;
            }

            return this.TotalOrder;
        }

        
    }
}