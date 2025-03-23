using CategoryProductOrderApi.Dtos;
using CategoryProductOrderApi.Models;
using static CategoryProductOrderApi.Common.GeneralResponse;

namespace CategoryProductOrderApi.Services.Interfaces
{
    public interface IOrderServices
    {
        public Task<Result<Order>> Create(OrderDto order);
        public Task<List<Order>> GetAll();
        public Task<Order> GetById(int orderId);
        public Task<Result<Order>> Update(int orderId, OrderDto updatedOrder);
        public Task<Result<bool>> Delete(int orderId);

    }


}
