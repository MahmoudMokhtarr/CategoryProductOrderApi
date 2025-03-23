using CategoryProductOrderApi.Dtos;
using CategoryProductOrderApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CategoryProductOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _producServices;
        public ProductController(IProductServices productServices)
        {
            _producServices = productServices;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            var result = await _producServices.Create(productDto);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(_producServices.GetById), new { id = result.Data!.ID }, result.Data);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int productId)
        {
            var result = await _producServices.Delete(productId);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int productId, ProductDto productDto)
        {
            var result = await _producServices.Update(productId, productDto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var product = await _producServices.GetAll();
            if (product is null)
                return NotFound("Not Found Data");

            return Ok(product);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int productId)
        {
            var result = await _producServices.GetById(productId);

            if (result is null)
                return NotFound("Not Found Data");

            return Ok(result);
        }

    }
}
