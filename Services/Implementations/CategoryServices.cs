using CategoryProductOrderApi.Dtos;
using CategoryProductOrderApi.Models;
using CategoryProductOrderApi.Repositories.Interfaces;
using CategoryProductOrderApi.Services.Interfaces;
using static CategoryProductOrderApi.Common.GeneralResponse;

namespace CategoryProductOrderApi.Services.Implementations
{
    public class CategoryServices : ICategoryServices
    {
        ICategoryRepository _repository;
        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }

        public async Task<Result<Category>> Create(CategoryDto categoryDto)
        {
            var category = new Category { CategoryName = categoryDto.CategoryName };

            var createdCategory = await _repository.Create(category);

            if (createdCategory is null)
                return Result<Category>.FailureResult("An error occurred while creating the category.");


            return Result<Category>.SuccessResult(createdCategory);


        }

        public async Task<Result<bool>> Delete(int categoryId)
        {
            var isDeleted = await _repository.Delete(categoryId);

            if (!isDeleted)
                return Result<bool>.FailureResult("category not found");


            return Result<bool>.SuccessResult(true);
        }

        public Task<List<Category>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Category> GetById(int categoryId)
        {
            return _repository.GetById(categoryId);
        }

        public async Task<Result<Category>> Update(int categoryId, CategoryDto updatedCategory)
        {

            var category = await GetById(categoryId);

            if (category is null)
                return Result<Category>.FailureResult("category not found");

            category.CategoryName = updatedCategory.CategoryName;

            await _repository.Update(categoryId, category);

            return Result<Category>.SuccessResult(category);


        }
    }


}
