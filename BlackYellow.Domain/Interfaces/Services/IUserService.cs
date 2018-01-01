using BlackYellow.Domain.Entites;
using System.Collections.Generic;

namespace BlackYellow.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        User GetUserByNamePassword(User user);
        User GetUserByMail(string email);
        IEnumerable<User> GetAllUserAdmin();
        User GetUserByCustomer(long id);

     
    }
}
