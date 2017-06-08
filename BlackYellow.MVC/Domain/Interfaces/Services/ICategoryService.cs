using System.Collections.Generic;
using BlackYellow.MVC.Domain.Entites;

namespace BlackYellow.MVC.Domain.Interfaces.Services
{
    public interface ICategoryService  : IServiceBase<Category>
    {
        IEnumerable<Category> GetAllWithProducts();
    }
}
