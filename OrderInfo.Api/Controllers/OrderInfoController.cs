using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderInfo.Business.Abstract;
using OrderInfo.Core.Entities.Concrete;
using OrderInfo.Core.Extentions;
using OrderInfo.Core.Utilities.Messages;
using OrderInfo.Core.Utilities.Results;
using OrderInfo.Entities.Concrete;
using OrderInfo.Entities.Dtos;

namespace OrderInfo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderInfoController : ControllerBase
    {

        private readonly ILogger<OrderInfoController> _logger;
        private readonly ICustomerDetailService _customerDetailService;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;

        public OrderInfoController(ICustomerDetailService customerDetailService, IOrderService orderService, IOrderItemService orderItemService, ILogger<OrderInfoController> logger)
        {
            _logger = logger;
            _customerDetailService = customerDetailService;
            _orderService = orderService;
            _orderItemService = orderItemService;
        }

       
        [HttpPost()]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IDataResult<OrderInfoResponseModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetLastestOrder([FromBody] LastOrderDto request)
        {

            OrderInfoResponseModel model = new OrderInfoResponseModel();

            _logger.LogInformation("Get Customer's Order Info method called");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage().ToString());
            }

            var customer = await _customerDetailService.GetCustomerDetail(request.User, request.CustomerId);

            if(customer.Data!= null)
            {

                var latestOrder = _orderService.GetLatestOrderByCustomerId(customer.Data.CustomerId);
                if(latestOrder.Data != null)
                {
                   var orderItems = await _orderItemService.GetListWithProductsByOrderIdAsync(latestOrder.Data.OrderId);

                    model = new OrderInfoResponseModel(customer.Data, latestOrder.Data, orderItems.Data); 
                }

                return Ok(model);

            }

            return Ok(model);

        }
    }
}
