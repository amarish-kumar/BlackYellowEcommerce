using System.Collections.Generic;

namespace BlackYellow.MVC.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        bool Insert(T obj);

        bool Delete(T obj);

        bool Update(T obj);

        IEnumerable<T> GetAll();

        T Get(int id);
    }
}
