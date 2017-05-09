using BlackYellow.MVC.Domain.Entites;
using System.Collections.Generic;

namespace BlackYellow.MVC.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetUserByNamePassword(User user);
        User GetUserByMail(string email);
        IEnumerable<User> GetAllUserAdmin();

        User GetUserByCustomer(int id);
    }
}
