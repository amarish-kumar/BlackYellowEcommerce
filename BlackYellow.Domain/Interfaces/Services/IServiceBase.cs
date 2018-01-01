using System.Collections.Generic;

namespace BlackYellow.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        bool Insert(T obj);

        bool Delete(T obj);

        bool Update(T obj);

        T Get(long id);

        IEnumerable<T> GetAll();

    }
}
