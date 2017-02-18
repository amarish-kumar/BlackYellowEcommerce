using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace BlackYellow.MVC.Repositories
{
    public class RepositoryBase
    {
        public Context.BlackYellowContext db;

        //public int Insert()
        //{
        //    db.Connection.Insert
        //}
    }
}
