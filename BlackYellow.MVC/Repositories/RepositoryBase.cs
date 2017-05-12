using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using BlackYellow.MVC.Context;
using BlackYellow.MVC.Domain.Interfaces.Repositories;

namespace BlackYellow.MVC.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>  where T : class
    {
        public BlackYellowContext db = new BlackYellowContext();

        public virtual bool Delete(T obj)
        {
            return  db.Connection.Delete(obj);
                    
        }

        public virtual T Get(long id)
        {
            return db.Connection.Get<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return db.Connection.GetAll<T>();
        }

        public virtual bool Insert(T obj)
        {
            var rows = db.Connection.Insert(obj);
            return rows > 0;
        }

        public virtual bool Update(T obj)
        {
            return db.Connection.Update(obj);
        }
    }
}
