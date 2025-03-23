using CategoryProductOrderApi.Dtos;
using CategoryProductOrderApi.Models;
using CategoryProductOrderApi.Repositories.Interfaces;
using CategoryProductOrderApi.Services.Interfaces;
using static CategoryProductOrderApi.Common.GeneralResponse;

namespace CategoryProductOrderApi.Services.Implementations
{
    public class OrderServices : IOrderServices
    {
        IOrderRepository _repository;
        public OrderServices(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<Order>> Create(OrderDto orderDto)
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                CustomerName = orderDto.CustomerName
            };

            var createdOrder = await _repository.Create(order);
            if (createdOrder is null)
                return Result<Order>.FailureResult("An error occurred while creating the Order");

            return Result<Order>.SuccessResult(createdOrder);
        }

        public async Task<Result<bool>> Delete(int orderId)
        {
            var order = await GetById(orderId);
            if (order is null)
                return Result<bool>.FailureResult("order not found");

            await _repository.Delete(orderId);
            return Result<bool>.SuccessResult(true);

        }

        public Task<List<Order>> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<Order> GetById(int orderId)
        {
            return await _repository.GetById(orderId);
        }

        public async Task<Result<Order>> Update(int orderId, OrderDto updatedOrder)
        {
            var order = await GetById(orderId);
            if (order is null)
                return Result<Order>.FailureResult("order not found");

            order.OrderDate = updatedOrder.OrderDate;
            order.CustomerName = updatedOrder.CustomerName;

            await _repository.Update(orderId, order);
            return Result<Order>.SuccessResult(order);
        }
    }


}
