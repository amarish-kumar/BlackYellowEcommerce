using BlackYellow.MVC.Domain.Entites;
using BlackYellow.MVC.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.MVC.Domain.Interfaces.Repositories;

namespace BlackYellow.MVC.Services
{
    public class CartItemService : ServiceBase<ItemCart>, ICartItemService
    {
        public CartItemService(IRepositoryBase<ItemCart> repository) : base(repository)
        {
        }
    }
}
