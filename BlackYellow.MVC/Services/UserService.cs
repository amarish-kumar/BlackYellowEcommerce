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

        readonly IUserRepository _userRepository;
        public UserService(IRepositoryBase<User> repository, IUserRepository userRepository) : base(repository)
        {
            _userRepository = userRepository;
        }

        public User GetUserByMail(string email)
        {
            return _userRepository.GetUserByMail(email);
        }

        public User GetUserByNamePassword(User user)
        {
            return _userRepository.GetUserByNamePassword(user);
        }




    }
}
