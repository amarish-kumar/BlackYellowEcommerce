using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Services;
using System.Collections.Generic;
using BlackYellow.MVC.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System.IO;
using BlackYellow.MVC.Models;
using System;

namespace BlackYellow.MVC.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;




        public ProductService(IRepositoryBase<Product> repository, IProductRepository productRepository) : base(repository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetByCategory(string categoryId)
        {
            return _productRepository.GetByCategory(categoryId);
        }

        public IEnumerable<Product> GetByName(string name)
        {
            return _productRepository.GetByName(name);
        }

        public bool InsertProduct(Product product)
        {
            return _productRepository.InsertProduct(product);
        }

        public IEnumerable<Product> ListTop12()
        {
            return _productRepository.ListTop12();
        }

        public Product GetProductsImages(long id)
        {
            return _productRepository.GetProductsImages(id);
        }

        public async void UploadProductFiles(IFormFile main_file, ICollection<IFormFile> details_files, string path)
        {
            if (main_file.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(path, main_file.FileName), FileMode.Create))
                {
                    await main_file.CopyToAsync(fileStream);
                }

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

        public List<GaleryProduct> GetImages(long id)
        {
            return _productRepository.GetImages(id);
        }

        public object GetAll(ProductReportFilters filters)
        {
            return _productRepository.GetAll(filters);
        }
    }
}
