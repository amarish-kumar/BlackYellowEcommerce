using BlackYellow.Domain.Entites;
using System.Collections.Generic;

namespace BlackYellow.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetUserByNamePassword(User user);
        User GetUserByMail(string email);
        IEnumerable<User> GetAllUserAdmin();

        User GetUserByCustomer(long id);
    }
}
