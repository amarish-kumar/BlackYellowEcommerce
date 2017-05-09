using BlackYellow.MVC.Domain.Entites;

namespace BlackYellow.MVC.Domain.Interfaces.Services
{
    public interface ICustomerService : IServiceBase<Customer>
    {
        Customer GetCustomerByDocument(string cpf);
        Customer GetCustomerByUserId(int id);
    }
}
