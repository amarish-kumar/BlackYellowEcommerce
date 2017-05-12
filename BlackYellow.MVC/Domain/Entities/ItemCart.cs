using Dapper.Contrib.Extensions;

namespace BlackYellow.MVC.Domain.Entites
{

    [Table("CartsItems")]
    public class ItemCart
    {
        [Key]
        public long ItemCartId { get; set; }
        [Write(false)]
        public Product Product { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        [Write(false)]
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        [Write(false)]
        public double SubTotal { get { return this.Product?.Price * Quantity ?? 0; } }


    }
}