using CategoryProductOrderApi.Dtos;
using CategoryProductOrderApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CategoryProductOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var result = await _categoryServices.Create(categoryDto);

            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(_categoryServices.GetById), new { id = result.Data!.ID }, result.Data);

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var result = await _categoryServices.Delete(categoryId);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, CategoryDto categoryDto)
        {
            var result = await _categoryServices.Update(id, categoryDto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryServices.GetAll();

            if (categories is null)
                return NotFound("Not Found Data");

            return Ok(categories);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int categoryId)
        {
            var category = await _categoryServices.GetById(categoryId);

            if (category is null)
                return NotFound("Not Found Data");


            return Ok(category);
        }



    }
}
