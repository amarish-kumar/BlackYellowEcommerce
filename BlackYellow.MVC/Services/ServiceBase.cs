using BlackYellow.MVC.Domain.Interfaces.Repositories;
using BlackYellow.MVC.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace BlackYellow.MVC.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        // Aqui precisa fazer o Injeção de Dependencia - Verifica com o Arthur se é preciso
        readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public virtual bool Delete(T obj)
        {
           return  _repository.Delete(obj);
        }

        public virtual T Get(long id)
        {
            return _repository.Get(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual bool Insert(T obj)
        {
            return _repository.Insert(obj);
        }

        public virtual bool Update(T obj)
        {
            return _repository.Update(obj);
        }
    }
}
