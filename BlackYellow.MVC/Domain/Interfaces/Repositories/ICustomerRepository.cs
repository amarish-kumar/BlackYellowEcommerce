using BlackYellow.MVC.Domain.Entites;

namespace BlackYellow.MVC.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Customer GetCustomerByDocument(string cpf);
        Customer GetCustomerByUserId(int id);
    }
}
