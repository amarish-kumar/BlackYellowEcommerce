namespace BlackYellow.MVC.Domain.Entites
{
    public class ItemCart
    {
        public int ItemCartId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public double SubTotal { get; private set; }


        public double GetSubTotal()
        {
            this.SubTotal = Product.Price * Quantity;
            return SubTotal;
        }
    }
}