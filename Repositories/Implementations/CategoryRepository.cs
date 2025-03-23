using CategoryProductOrderApi.Data;
using CategoryProductOrderApi.Models;
using CategoryProductOrderApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CategoryProductOrderApi.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Category> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> Delete(int categoryId)
        {
            var category = await GetById(categoryId);
            if (category is null)
                return false;


            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Category>> GetAll()
        {
            var listCategories = await _context.Categories.ToListAsync();

            if (listCategories is null)
                throw new KeyNotFoundException("Not Found Is Data for Category.");

            return listCategories;

        }

        public async Task<Category> GetById(int categoryId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.ID == categoryId);
            if (category is null)
                throw new KeyNotFoundException("This Category Id has Not Found.");

            return category;
        }

        public async Task<Category> Update(int categoryId, Category updatedCategory)
        {
            var category = await GetById(categoryId);
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}

