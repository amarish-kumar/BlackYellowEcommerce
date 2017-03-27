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
                        VALUES(@Name,@Description,@Quantity,@LastPrice,@Price,@CategoryId,@DateRegister)";

               product.ProductId =  db.Connection.ExecuteScalar<int>(sql, new
                {
                    Name = product.Name,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    LastPrice = product.LastPrice,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    DateRegister = DateTime.Now
                });


                foreach (var item in product.GaleryProduct)
                {
                    db.Connection.Execute(sql, new
                    {
                        NameImage = item.NameImage,
                        PathImage = item.PathImage,
                        IsPrincipal = item.IsPrincipal,
                        ProductId = product.ProductId
                    });
                }


                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            



        }

        public IEnumerable<Product> ListTop12()
        {
            try
            {
                var sql = @"SELECT  p.ProductId, p.Name, p.Price, g.PathImage
                                FROM Products p INNER JOIN
                                GaleryProducts g ON g.ProductId = p.ProductId
                                WHERE Quantity > 0";

                Dictionary<int, Product> produtos = new Dictionary<int, Product>();
                db.Connection.Query<Product, GaleryProduct, Product>(sql,
                                    splitOn:"PathImage",
                                    map:(p, g) => {
                                        Product pr;
                                        if (!produtos.TryGetValue(p.ProductId, out pr))
                                        {
                                            pr = p;
                                            produtos.Add(pr.ProductId, pr);
                                        }
                                        pr.GaleryProduct.Add(g);
                                        return p; }
                        
                    ).ToList();

                return produtos.Values;
                        
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
