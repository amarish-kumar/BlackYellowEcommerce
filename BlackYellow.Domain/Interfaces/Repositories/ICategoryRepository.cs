using System.Collections.Generic;
using BlackYellow.Domain.Entites;

namespace BlackYellow.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository  : IRepositoryBase<Category>
    {
        IEnumerable<Category> GetAllWithProducts();

    }
}
