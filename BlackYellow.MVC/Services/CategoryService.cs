using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Services;
using BlackYellow.MVC.Domain.Interfaces.Repositories;

namespace BlackYellow.MVC.Services
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        public CategoryService(IRepositoryBase<Category> repository) : base(repository)
        {
        }
    }
}
