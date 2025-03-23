

using CategoryProductOrderApi.Data;
using CategoryProductOrderApi.Models;
using CategoryProductOrderApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CategoryProductOrderApi.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Order> Create(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> Delete(int orderId)
        {
            var book = await GetById(orderId);

            _context.Orders.Remove(book);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<Order>> GetAll()
        {
            var listOrders = await _context.Orders.ToListAsync();
            if (listOrders is null)
                throw new KeyNotFoundException("Not Found Is Data for Orders.");

            return listOrders;
        }

        public async Task<Order> GetById(int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderID == orderId);
            if (order is null)
                throw new KeyNotFoundException("This Order Id has Not Found.");

            return order;
        }

        public async Task<Order> Update(int orderId, Order updatedOrder)
        {
            var book = await GetById(orderId);
            _context.Orders.Update(updatedOrder);
            await _context.SaveChangesAsync();
            return updatedOrder;

        }
    }
}