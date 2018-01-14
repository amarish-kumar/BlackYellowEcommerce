using BlackYellow.Domain.Entites;
using System.Collections.Generic;
using BlackYellow.Domain.Interfaces.Repositories;
using BlackYellow.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BlackYellow.Service
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

        public IEnumerable<User> GetAllUserAdmin()
        {
            return _userRepository.GetAllUserAdmin();
        }

        public User GetUserByCustomer(long id)
        {
            return _userRepository.GetUserByCustomer(id);
        }
    }
}
