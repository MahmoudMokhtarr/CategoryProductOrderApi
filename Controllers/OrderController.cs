using CategoryProductOrderApi.Dtos;
using CategoryProductOrderApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CategoryProductOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(OrderDto orderDto)
        {
            var result = await _orderServices.Create(orderDto);

            if (!result.Success)
                return NotFound(result.Message);

            return CreatedAtAction(nameof(_orderServices.GetById), new { id = result.Data!.OrderID }, result.Data);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int orderId)
        {
            var result = await _orderServices.Delete(orderId);
            if (!result.Success)
                return NotFound(result.Message);

            return NoContent();

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int orderId, OrderDto orderDto)
        {
            var result = await _orderServices.Update(orderId, orderDto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);


        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderServices.GetAll();
            if (result is null)
                return NotFound("Not Found Data");

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int orderId)
        {
            var result = await _orderServices.GetById(orderId);
            if (result is null)
                return NotFound("Not Found Data");

            return Ok(result);
        }
    }
}
