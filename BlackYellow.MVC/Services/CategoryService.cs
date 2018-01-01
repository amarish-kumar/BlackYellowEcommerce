using BlackYellow.Domain.Entites;
using BlackYellow.Domain.Interfaces.Services;
using BlackYellow.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace BlackYellow.MVC.Services
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {


        private ICategoryRepository _categoryRepository;

        public CategoryService(IRepositoryBase<Category> repository, ICategoryRepository categoryRepository) : base(repository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAllWithProducts()
        {
            return _categoryRepository.GetAllWithProducts();
        }
    }
}
