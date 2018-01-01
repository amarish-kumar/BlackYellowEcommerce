using BlackYellow.Domain.Interfaces.Repositories;
using BlackYellow.Domain.Entites;
using System.Collections.Generic;
using Dapper;

namespace BlackYellow.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category> , ICategoryRepository
    {
        public IEnumerable<Category> GetAllWithProducts()
        {

            var sql = "SELECT * FROM Categories C WHERE EXISTS(SELECT * FROM Products P WHERE P.CategoryId = C.CategoryId AND P.Quantity > 0)";

            return base.db.Connection.Query<Category>(sql);   

        }

        public override IEnumerable<Category> GetAll()
        {
            return base.GetAll();
        }

    }
}
