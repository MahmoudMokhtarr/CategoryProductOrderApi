
using CategoryProductOrderApi.Data;
using CategoryProductOrderApi.Models;
using CategoryProductOrderApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CategoryProductOrderApi.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Create(Product product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> Delete(int productId)
        {
            var product = await GetById(productId);
            if (product is null)
                return false;

            _context.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Product>> GetAll()
        {
            var listProducts = await _context.Product.ToListAsync();

            if (listProducts is null)
                throw new KeyNotFoundException("Not Found Is Data for Products.");

            return listProducts;
        }

        public async Task<Product> GetById(int productId)
        {
            var product = await _context.Product.FirstOrDefaultAsync(p => p.ID == productId);
            if (product is null)
                throw new KeyNotFoundException("This product Id has Not Found");

            return product;
        }

        public async Task<Product> Update(int productId, Product updatedProduct)
        {
            var product = await GetById(productId);
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;

        }
    }
}
