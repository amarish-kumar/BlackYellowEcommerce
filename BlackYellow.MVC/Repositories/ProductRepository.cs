using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;

namespace BlackYellow.MVC.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public bool InsertProduct(Product product)
        {
            try
            {
                var sql = @"INSERT INTO 
                                Products( Name, 
                                          Description,
                                          Quantity,
                                          LastPrice,
                                          Price,
                                          CategoryId,
                                          DateRegister)
                        VALUES( @Name,@Description,@Quantity,@LastPrice,@Price,@CategoryId,@DateRegister)";

                db.Connection.Execute(sql, new
                {
                    Name = product.Name,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    LastPrice = product.LastPrice,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    DateRegister = DateTime.Now
                });

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            



        }
    }
}
