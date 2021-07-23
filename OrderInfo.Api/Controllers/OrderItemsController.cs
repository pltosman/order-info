using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderInfo.Business.Abstract;

namespace OrderInfo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private IOrderItemService _orderItemService;

        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _orderItemService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _orderItemService.GetById(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

       [HttpGet("getbyorderid")]
        public async Task<IActionResult> GetByOrderIdAsync(int orderId)
        {
            var result = await _orderItemService.GetItemsByOrderIdAsync(orderId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getlistwithproductsbyorderid")]
        public async Task<IActionResult> GetListWithProductsByOrderIdAsync(int orderId)
        {
            var result = await _orderItemService.GetListWithProductsByOrderIdAsync(orderId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
