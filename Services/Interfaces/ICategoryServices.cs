using CategoryProductOrderApi.Dtos;
using CategoryProductOrderApi.Models;
using static CategoryProductOrderApi.Common.GeneralResponse;

namespace CategoryProductOrderApi.Services.Interfaces
{
    public interface ICategoryServices
    {
        public Task<Result<Category>> Create(CategoryDto Product);
        public Task<List<Category>> GetAll();
        public Task<Category> GetById(int categoryId);
        public Task<Result<Category>> Update(int categoryId, CategoryDto updatedCategory);
        public Task<Result<bool>> Delete(int categoryId);

    }


}
