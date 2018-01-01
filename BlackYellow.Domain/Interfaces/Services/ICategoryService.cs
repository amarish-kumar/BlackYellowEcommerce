using System.Collections.Generic;
using BlackYellow.Domain.Entites;

namespace BlackYellow.Domain.Interfaces.Services
{
    public interface ICategoryService  : IServiceBase<Category>
    {
        IEnumerable<Category> GetAllWithProducts();
    }
}
