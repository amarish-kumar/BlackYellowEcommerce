using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Context;
using BlackYellow.MVC.Domain.Interfaces.Repositories;

namespace BlackYellow.MVC.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>  where T : class
    {
        public BlackYellowContext db = new BlackYellowContext();

        public bool Delete(T obj)
        {
            return  db.Connection.Delete(obj);
                    
        }

        public T Get(int id)
        {
            return db.Connection.Get<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Connection.GetAll<T>();
        }

        public bool Insert(T obj)
        {
            var rows = db.Connection.Insert(obj);
            return rows > 0;
        }

        public bool Update(T obj)
        {
            return db.Connection.Update(obj);
        }
    }
}
