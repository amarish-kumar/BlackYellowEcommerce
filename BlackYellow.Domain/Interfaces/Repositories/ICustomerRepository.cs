using BlackYellow.Domain.Entites;

namespace BlackYellow.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Customer GetCustomerByDocument(string cpf);
        Customer GetCustomerByUserId(long id);
    }
}
