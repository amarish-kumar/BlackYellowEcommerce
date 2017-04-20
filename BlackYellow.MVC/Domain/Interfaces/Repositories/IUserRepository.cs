using BlackYellow.MVC.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackYellow.MVC.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetUserByNamePassword(User user);
        User GetUserByMail(string email);
        IEnumerable<User> GetAllUserAdmin();
    }
}
