using BlackYellow.MVC.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackYellow.MVC.Domain.Interfaces.Repositories
{
   public  interface IProductRepository : IRepositoryBase<Product> 
    {
        bool InsertProduct(Product product);

        IEnumerable<Product> ListTop12();

        IEnumerable<Product> GetByName(string name);

        IEnumerable<Product> GetByCategory(string categoryId);
    }
}
