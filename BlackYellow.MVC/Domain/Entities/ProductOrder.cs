namespace BlackYellow.MVC.Domain.Entites
{
    public class ProductOrder
    {
        public int ProductOrderId { get; set; }
        public Order Order { get; set; }
    }
}