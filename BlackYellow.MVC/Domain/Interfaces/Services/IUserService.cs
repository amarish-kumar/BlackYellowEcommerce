using BlackYellow.MVC.Domain.Entites;
using System.Collections.Generic;

namespace BlackYellow.MVC.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        User GetUserByNamePassword(User user);
        User GetUserByMail(string email);
        IEnumerable<User> GetAllUserAdmin();
        User GetUserByCustomer(long id);

     
    }
}
