using BlackYellow.MVC.Domain.Entites;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BlackYellow.MVC.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
         void uploadProductFiles(IFormFile main_file, ICollection<IFormFile> details_files, string path);

        bool InsertProduct(Product product);

        IEnumerable<Product> ListTop12();

        IEnumerable<Product> GetByName(string name);

        IEnumerable<Product> GetByCategory(string categoryId);

        Product GetProductsImages(int id);

        List<GaleryProduct> GetImages(int id);

    }
}
