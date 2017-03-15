using System.Collections.Generic;
using System.Linq;

namespace BlackYellow.MVC.Domain.Entites
{
    public class Cart
    {
        public int CartId { get; set; }

        public List<ItemCart> Itens { get; set; }

        public double TotalOrder
        {
            get
            {
                return Itens.Sum(i => i.SubTotal);
            }
        }

        public User User { get; set; }


        public int Quantity
        {
            get
            {
                return Itens.Count;
            }
        }




    }
}