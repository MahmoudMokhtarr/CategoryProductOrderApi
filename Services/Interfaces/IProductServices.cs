using CategoryProductOrderApi.Dtos;
using CategoryProductOrderApi.Models;
using static CategoryProductOrderApi.Common.GeneralResponse;

namespace CategoryProductOrderApi.Services.Interfaces
{
    public interface IProductServices
    {
        public Task<Result<Product>> Create(ProductDto productDto);
        public Task<List<Product>> GetAll();
        public Task<Product> GetById(int productId);
        public Task<Result<Product>> Update(int productId, ProductDto updatedProduct);
        public Task<Result<bool>> Delete(int productId);
    }


}
