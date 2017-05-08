namespace BlackYellow.MVC.Domain.Entites
{
    public class ItemCart
    {
        public int ItemCartId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }


        public double SubTotal { get { return this.Product?.Price * Quantity ?? 0; } }


    }
}