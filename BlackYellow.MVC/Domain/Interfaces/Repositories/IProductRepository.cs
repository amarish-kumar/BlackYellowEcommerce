using BlackYellow.MVC.Domain.Entites;
using System.Collections.Generic;

namespace BlackYellow.MVC.Domain.Interfaces.Repositories
{
    public  interface IProductRepository : IRepositoryBase<Product> 
    {
        bool InsertProduct(Product product);

        IEnumerable<Product> ListTop12();

        IEnumerable<Product> GetByName(string name);

        IEnumerable<Product> GetByCategory(string categoryId);
        Product GetProductsImages(long id);
        List<GaleryProduct> GetImages(long id);
    }
}
