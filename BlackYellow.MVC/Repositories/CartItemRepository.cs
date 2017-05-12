using BlackYellow.MVC.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.MVC.Domain.Entites;

namespace BlackYellow.MVC.Repositories
{
    public class CartItemRepository : RepositoryBase<ItemCart>, ICartItemRepository
    {
       
    }
}
