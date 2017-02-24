using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackYellow.MVC.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        bool Insert(T obj);

        bool Delete(T obj);

        bool Update(T obj);

        T Get(int id);

        IEnumerable<T> GetAll();

    }
}
