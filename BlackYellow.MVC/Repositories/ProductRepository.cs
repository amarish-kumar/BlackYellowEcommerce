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
                                    map: (p, g) => {
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
                                FROM Products p INNER JOIN
                                GaleryProducts g ON g.ProductId = p.ProductId
                                WHERE Quantity > 0 AND g.IsPrincipal = 1 AND p.Name = '"+ name +"'";

                Dictionary<int, Product> produtos = new Dictionary<int, Product>();
                db.Connection.Query<Product, GaleryProduct, Product>(sql,
                                    splitOn: "PathImage",
                                    map: (p, g) => {
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

        public  Product GetProductsImages(int id)
        {
            try
            {
                var sql = @"SELECT  p.ProductId, p.Name, p.Price, g.PathImage, g.IsPrincipal, p.CategoryId
                                FROM Products p INNER JOIN
                                GaleryProducts g ON g.ProductId = p.ProductId INNER JOIN
                                Categories c ON c.CategoryId = p.CategoryId 
                                WHERE Quantity > 0 AND g.IsPrincipal = 1 AND p.ProductId = "+ id;

                Dictionary<int, Product> produtos = new Dictionary<int, Product>();
               return db.Connection.Query<Product, GaleryProduct, Product>(sql,
                                    splitOn: "PathImage",
                                    map: (p, g) => {
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

        //public IEnumerable<GaleryProduct> GetImagesByProduct(int id)
        //{
        //    try
        //    {
        //        var sql = @"SELECT g.PathImage, g.IsPrincipal
        //                        FROM Products p INNER JOIN
        //                        GaleryProducts g ON g.ProductId = p.ProductId ";

        //        Dictionary<int, Product> produtos = new Dictionary<int, Product>();
        //        db.Connection.Query<GaleryProduct, GaleryProduct, Product>(sql,
        //                            splitOn: "PathImage",
        //                            map: (p, g) =>
        //                            {
        //                                Product pr;
        //                                if (!produtos.TryGetValue((int)p.ProductId, out pr))
        //                                {
        //                                    pr = p;
        //                                    produtos.Add((int)pr.ProductId, pr);
        //                                }

        //                                return p;
        //                            }


        //            ).ToList();

        //        return produtos.Values;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    
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
                                    splitOn:"PathImage",
                                    map:(p, g) => {
                                        Product pr;
                                        if (!produtos.TryGetValue((int)p.ProductId, out pr))
                                        {
                                            pr = p;
                                            produtos.Add((int) pr.ProductId, pr);
                                        }
                                        if(g.IsPrincipal)
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

    }
}
