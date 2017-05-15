using BlackYellow.MVC.Domain.Entites;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using BlackYellow.MVC.Models;

namespace BlackYellow.MVC.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
         void UploadProductFiles(IFormFile main_file, ICollection<IFormFile> details_files, string path);

        bool InsertProduct(Product product);

        IEnumerable<Product> ListTop12();

        IEnumerable<Product> GetByName(string name);

        IEnumerable<Product> GetByCategory(string categoryId);

        Product GetProductsImages(long id);

        List<GaleryProduct> GetImages(long id);
        object GetAll(ProductReportFilters filters);
    }
}
