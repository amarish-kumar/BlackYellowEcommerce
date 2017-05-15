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

        public long ProductId { get; set; }

        public long OrderId { get; set; }

        [Write(false)]
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        [Write(false)]
        public double SubTotal { get { return this.Product?.Price * Quantity ?? 0; } }

        // override object.Equals
        public override bool Equals(object obj)
        {
     

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (ItemCart)obj;
            
            return other.ProductId.Equals(this.ProductId) && other.OrderId.Equals(this.OrderId);

        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.OrderId.GetHashCode() ^ 7 + this.ProductId.GetHashCode() ^ 7;
        }


    }
}