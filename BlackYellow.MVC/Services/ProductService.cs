using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.MVC.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BlackYellow.MVC.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IRepositoryBase<Product> repository, IProductRepository productRepository) : base(repository)
        {
            _productRepository = productRepository;
        }

        public bool InsertProduct(Product product)
        {
            return _productRepository.InsertProduct(product);
        }

        public async void uploadProductFiles(IFormFile main_file, ICollection<IFormFile> details_files, string path)
        {          
            if (main_file.Length > 0)
            {
                File.Create(Path.Combine(path, main_file.FileName));               
            }

            foreach (var file in details_files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
        }
    }
}
