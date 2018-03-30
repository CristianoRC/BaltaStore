using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.OrderCommand.Inputs;

namespace BaltaStore.Domain.StoreContext.Repositories
{
    public interface IOrderRepository
    {
        void Create(PlaceOrderCommand order);

        void Update(PlaceOrderCommand order);

        void Delete(string number);
    }
}