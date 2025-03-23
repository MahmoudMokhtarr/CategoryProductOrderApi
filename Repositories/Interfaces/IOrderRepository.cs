using CategoryProductOrderApi.Models;

namespace CategoryProductOrderApi.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> Create(Order order);
        public Task<List<Order>> GetAll();
        public Task<Order> GetById(int orderId);
        public Task<Order> Update(int orderId, Order updatedOrder);
        public Task<bool> Delete(int orderId);

    }
}
