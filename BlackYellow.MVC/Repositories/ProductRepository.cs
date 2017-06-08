using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper.Contrib.Extensions;
using Dapper;
using BlackYellow.MVC.Models;

namespace BlackYellow.MVC.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public IEnumerable<Product> GetByCategory(string categoryId)
        {
            try
            {
                var sql = @"SELECT  p.ProductId, p.Name, p.Price, g.PathImage, g.IsPrincipal
                                FROM Products p INNER JOIN
                                GaleryProducts g ON g.ProductId = p.ProductId
                                INNER JOIN Categories c ON c.CategoryId = p.CategoryId
                                WHERE Quantity > 0 AND g.IsPrincipal = 1 AND  p.CategoryId = " + categoryId;

                Dictionary<int, Product> produtos = new Dictionary<int, Product>();
                db.Connection.Query<Product, GaleryProduct, Product>(sql,
                                    splitOn: "PathImage",
                                    map: (p, g) =>
                                    {
                                        Product pr;
                                        if (!produtos.TryGetValue((int)p.ProductId, out pr))
                                        {
                                            pr = p;
                                            produtos.Add((int)pr.ProductId, pr);
                                        }
                                        if (g.IsPrincipal)
                                        {
                                            pr.GaleryProduct.Add(g);

                                        }
                                        return p;
                                    }


                    ).ToList();

                return produtos.Values;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Product> GetByName(string name)
        {
            try
            {
                var sql = @"SELECT  p.ProductId, p.Name, p.Price, g.PathImage, g.IsPrincipal
                                FROM Products p
                                LEFT JOIN GaleryProducts g ON g.ProductId = p.ProductId AND g.IsPrincipal = 1 
                                WHERE Quantity > 0 AND p.Name like @filter";

                Dictionary<int, Product> produtos = new Dictionary<int, Product>();
                db.Connection.Query<Product, GaleryProduct, Product>(sql,
                                    splitOn: "PathImage",
                                    map: (p, g) =>
                                    {
                                        Product pr;
                                        if (!produtos.TryGetValue((int)p.ProductId, out pr))
                                        {
                                            pr = p;
                                            produtos.Add((int)pr.ProductId, pr);
                                        }
                                        if (g.IsPrincipal)
                                        {
                                            pr.GaleryProduct.Add(g);

                                        }
                                        return p;
                                    }


                   , param: new { filter = $"%{name}%" }).ToList();

                return produtos.Values;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool InsertProduct(Product product)
        {
            try
            {
                var sql = @"INSERT INTO 
                                Products( Name, 
                                          Description,
                                          Quantity,
                            
                                          Price,
                                          CategoryId,
                                          DateRegister)
                        VALUES(@Name,@Description,@Quantity,@Price,@CategoryId,@DateRegister)";

                product.ProductId = db.Connection.Insert(product);

                sql = "INSERT INTO GaleryProducts (NameImage, PathImage,IsPrincipal, ProductId) VALUES (@NameImage, @PathImage,@IsPrincipal,@ProductId)";
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

        public Product GetProductsImages(long id)
        {
            try
            {
                var sql = @"SELECT  p.ProductId, p.Name, p.Price, g.PathImage, g.IsPrincipal, p.CategoryId
                                FROM Products p INNER JOIN
                                GaleryProducts g ON g.ProductId = p.ProductId INNER JOIN
                                Categories c ON c.CategoryId = p.CategoryId 
                                WHERE Quantity > 0 AND g.IsPrincipal = 1 AND p.ProductId = " + id;

                Dictionary<int, Product> produtos = new Dictionary<int, Product>();
                return db.Connection.Query<Product, GaleryProduct, Product>(sql,
                                     splitOn: "PathImage",
                                     map: (p, g) =>
                                     {
                                         Product pr;
                                         if (!produtos.TryGetValue((int)p.ProductId, out pr))
                                         {
                                             pr = p;
                                             produtos.Add((int)pr.ProductId, pr);
                                         }
                                         if (g.IsPrincipal)
                                         {
                                             pr.GaleryProduct.Add(g);

                                         }
                                         return p;
                                     }


                     ).FirstOrDefault();



            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GaleryProduct> GetImages(long id)
        {
            try
            {
                var sql = @"SELECT p.ProductId, g.PathImage, g.IsPrincipal
                                FROM GaleryProducts g INNER JOIN
                                Products p ON g.ProductId = p.ProductId 
                                WHERE   p.ProductId = " + id;

                Dictionary<int, Product> produtos = new Dictionary<int, Product>();

                Product product = db.Connection.Query<Product, GaleryProduct, Product>(sql,
                                     splitOn: "PathImage",
                                     map: (p, g) =>
                                     {
                                         Product pr;
                                         if (!produtos.TryGetValue((int)p.ProductId, out pr))
                                         {
                                             pr = p;
                                             produtos.Add((int)pr.ProductId, pr);
                                         }
                                         pr.GaleryProduct.Add(g);

                                         return p;
                                     }


                     ).FirstOrDefault();

                List<GaleryProduct> galeries = new List<GaleryProduct>();
                galeries = product.GaleryProduct;
                return galeries;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public IEnumerable<Product> ListTop12()
        {
            try
            {
                var sql = @"SELECT  p.ProductId, p.Name, p.Price, g.PathImage, g.IsPrincipal
                                FROM Products p INNER JOIN
                                GaleryProducts g ON g.ProductId = p.ProductId
                                WHERE Quantity > 0 AND g.IsPrincipal = 1";

                Dictionary<int, Product> produtos = new Dictionary<int, Product>();
                db.Connection.Query<Product, GaleryProduct, Product>(sql,
                                    splitOn: "PathImage",
                                    map: (p, g) =>
                                    {
                                        Product pr;
                                        if (!produtos.TryGetValue((int)p.ProductId, out pr))
                                        {
                                            pr = p;
                                            produtos.Add((int)pr.ProductId, pr);
                                        }
                                        if (g.IsPrincipal)
                                        {
                                            pr.GaleryProduct.Add(g);

                                        }
                                        return p;
                                    }


                    ).ToList();

                return produtos.Values;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public object GetAll(ProductReportFilters filters)
        {
            var @return = new Dictionary<long, Product>();

            var sql = @"SELECT * 
                            FROM Products
                            LEFT JOIN CartsItems
                                 ON Products.ProductId = CartsItems.ProductId
                            LEFT JOIN Orders
                                 ON CartsItems.OrderId = Orders.OrderId
                            INNER JOIN Categories
                                ON Categories.CategoryId = Products.CategoryId
                        WHERE /*((@InitDate IS NULL AND @EndData IS NULL) OR cast(Orders.OrderDate as date) BETWEEN @InitDate AND @EndDate) AND*/ (@CategoryId IS NULL OR Categories.CategoryId = @CategoryId) ";

            var queryResult = base.db.Connection.Query<Product, ItemCart, Order, Category, Product>(sql,
                splitOn: "CustomerId,AddressId,UserId,ItemCartId,ProductId,CategoryId",
                map: (prod, cart, ord, cat) =>
                {
                    Product result = new Product();
                    if (prod != null && cart != null && ord != null && cat != null)
                    {


                        if (!@return.TryGetValue(prod.ProductId, out result))
                        {
                            result = prod;
                            @return.Add(result.ProductId, result);
                        }

                        result.Category = cat;
                        result.CategoryId = cat.CategoryId;
                        cart.Order = ord;
                        cart.OrderId = ord.OrderId;

                        if (result.SoldItens == null) result.SoldItens = new List<ItemCart>();

                        if (!(result.SoldItens.Contains(cart)))
                            result.SoldItens.Add(cart);

                    }
                    return result;





                },
                param: filters);

            return @return.Values;
        }
    }
}
