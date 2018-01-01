using System.Collections.Generic;
using System.Linq;

namespace BlackYellow.Domain.Entites
{
    public class Cart
    {
        public int CartId { get; set; }

        public List<ItemCart> Itens { get; set; }


        public void Add(Cart cart, ItemCart item)
        {
            if (cart.Itens.Find(p => p.Product.ProductId == item.Product.ProductId) != null)
            {
                ItemCart itemCart = cart.Itens.Find(p => p.Product.ProductId == item.Product.ProductId);
                int index = cart.Itens.FindIndex(p => p.Product.ProductId == item.Product.ProductId);
                Product product = cart.Itens.Find(p => p.Product.ProductId == item.Product.ProductId).Product;
              
                itemCart.Quantity += 1;
                itemCart.Product = product;
                cart.Itens.RemoveAt(index);
                cart.Itens.Add(itemCart);

            }
            else
            {
                item.Quantity = 1;
                item.ItemCartId = (cart.Itens.OrderBy(x => x.ItemCartId).LastOrDefault()?.ItemCartId ?? 0) + 1;
                cart.Itens.Add(item);
            }
        }

        public void Remove(Cart cart, ItemCart item)
        {
            ItemCart itemCart = cart.Itens.Find(p => p.Product.ProductId == item.Product.ProductId);
            int index = cart.Itens.FindIndex(p => p.Product.ProductId == item.Product.ProductId);
            cart.Itens.RemoveAt(index);
        }

       

        public double TotalOrder
        {
            get
            {
                if (Itens  !=  null)
                    return Itens.Sum(i => i.SubTotal);
                else
                    return 0;
            }
        }

        public User User { get; set; }


        public int Quantity
        {
            get
            {
                if (Itens != null)
                    return Itens.Count;
                else
                    return 0;
            }
        }




    }
}