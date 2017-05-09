namespace BlackYellow.MVC.Domain.Interfaces.Services
{
    public interface IPayment
    {

        void ExecutePay();
        string HtmlResult { get; }

    }
}