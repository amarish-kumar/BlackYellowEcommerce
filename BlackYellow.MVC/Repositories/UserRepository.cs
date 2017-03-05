using System;
using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Repositories;
using Dapper.Contrib.Extensions;
using Dapper;
using Dapper.Contrib;
using System.Collections.Generic;
using System.Linq;

namespace BlackYellow.MVC.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public User GetUserByNamePassword(User user)
        {
            try
            {
                var sql = " SELECT Email, Profile FROM USERS WHERE Email = @Email AND Password = @Password";
                var row = db.Connection.Query<User>(sql, new { user.Email, user.Password });
                if(row != null)
                {
                    return db.Connection.Query<User>(sql, new { user.Email, user.Password }).First();
                }

                return null;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
          
            
           
        }
    }
}
