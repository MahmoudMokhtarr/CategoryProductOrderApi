using CategoryProductOrderApi.Models;

namespace CategoryProductOrderApi.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category> Create(Category Product);
        public Task<List<Category>> GetAll();
        public Task<Category> GetById(int categoryId);
        public Task<Category> Update(int categoryId, Category updatedCategory);
        public Task<bool> Delete(int categoryId);

    }
}
