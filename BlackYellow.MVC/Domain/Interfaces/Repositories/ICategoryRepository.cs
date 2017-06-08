using System.Collections.Generic;
using BlackYellow.MVC.Domain.Entites;

namespace BlackYellow.MVC.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository  : IRepositoryBase<Category>
    {
        IEnumerable<Category> GetAllWithProducts();

    }
}
