using BlackYellow.MVC.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.MVC.Domain.Interfaces.Repositories;
using BlackYellow.MVC.Domain.Interfaces.Services;

namespace BlackYellow.MVC.Services
{
    public class UserService : ServiceBase<User> , IUserService
    {
        public UserService(IRepositoryBase<User> repository) : base(repository)
        {
        }
    }
}
