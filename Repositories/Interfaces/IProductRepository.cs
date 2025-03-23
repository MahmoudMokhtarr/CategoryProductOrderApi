using CategoryProductOrderApi.Models;

namespace CategoryProductOrderApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> Create(Product product);
        public Task<List<Product>> GetAll();
        public Task<Product> GetById(int productId);
        public Task<Product> Update(int productId, Product updatedProduct);
        public Task<bool> Delete(int productId);

    }
}
