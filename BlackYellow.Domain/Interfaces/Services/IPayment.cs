namespace BlackYellow.Domain.Interfaces.Services
{
    public interface IPayment
    {

        void ExecutePay();
        string HtmlResult { get; }

    }
}