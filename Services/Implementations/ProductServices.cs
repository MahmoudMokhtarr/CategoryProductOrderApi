using CategoryProductOrderApi.Dtos;
using CategoryProductOrderApi.Models;
using CategoryProductOrderApi.Repositories.Interfaces;
using CategoryProductOrderApi.Services.Interfaces;
using static CategoryProductOrderApi.Common.GeneralResponse;

namespace CategoryProductOrderApi.Services.Implementations
{

    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repository;

        public ProductServices(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<Product>> Create(ProductDto productDto)
        {
            var product = new Product
            {
                ProductName = productDto.ProductName,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                CategoryID = productDto.CategoryID,
            };

            var createdProduct = await _repository.Create(product);
            if (createdProduct is null)
                return Result<Product>.FailureResult("An error occurred while creating the product");

            return Result<Product>.SuccessResult(createdProduct);
        }

        public async Task<Result<bool>> Delete(int productId)
        {
            var isDeleted = await _repository.Delete(productId);

            if (!isDeleted)
                return Result<bool>.FailureResult("Product not found");

            return Result<bool>.SuccessResult(true);
        }

        public async Task<Result<Product>> Update(int productId, ProductDto updatedProduct)
        {
            var product = await GetById(productId);
            if (product is null)
                return Result<Product>.FailureResult("Product Not Found");

            product.ProductName = updatedProduct.ProductName;
            product.Price = updatedProduct.Price;
            product.StockQuantity = updatedProduct.StockQuantity;
            product.CategoryID = updatedProduct.CategoryID;

            await _repository.Update(productId, product);
            return Result<Product>.SuccessResult(product);

        }

        public Task<List<Product>> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<Product> GetById(int productId)
        {
            return await _repository.GetById(productId);
        }

    }


}
