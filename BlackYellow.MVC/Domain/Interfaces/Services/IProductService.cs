using BlackYellow.MVC.Domain.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackYellow.MVC.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
         void uploadProductFiles(IFormFile main_file, ICollection<IFormFile> details_files, string path);

        bool InsertProduct(Product product);

        List<Product> ListTop12();
       
    }
}
