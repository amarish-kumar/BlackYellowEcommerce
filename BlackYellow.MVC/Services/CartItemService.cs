using BlackYellow.Domain.Entites;
using BlackYellow.Domain.Interfaces.Services;
using BlackYellow.Domain.Interfaces.Repositories;

namespace BlackYellow.MVC.Services
{
    public class CartItemService : ServiceBase<ItemCart>, ICartItemService
    {
        public CartItemService(IRepositoryBase<ItemCart> repository) : base(repository)
        {
        }
    }
}
