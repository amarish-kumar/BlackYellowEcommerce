using BlackYellow.Domain.Entites;

namespace BlackYellow.Domain.Interfaces.Services
{
    public interface ICustomerService : IServiceBase<Customer>
    {
        Customer GetCustomerByDocument(string cpf);
        Customer GetCustomerByUserId(long id);
    }
}
