﻿using System;
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
        public User GetUserByMail(string email)
        {
            var sql = "SELECT * FROM Users WHERE Email = @email";

            return db.Connection.Query<User>(sql, param: new { email = email }).SingleOrDefault();
        }

        public User GetUserByNamePassword(User user)
        {
            try
            {
                var sql = " SELECT * FROM Users WHERE Email = @Email AND Password = @Password";

                // var row = db.Connection.Query<User>(sql, param: user);

                return db.Connection.Query<User>(sql, param: user).FirstOrDefault();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }



        }

        public IEnumerable<User> GetAllUserAdmin()
        {
            try
            {
                var sql = "SELECT * FROM Users WHERE Users.Profile = 1";

                return db.Connection.Query<User>(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
