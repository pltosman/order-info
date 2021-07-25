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
     
        private readonly IOrderInfoService _orderInfoService;
        private readonly ILogger<OrderInfoController> _logger;

        public OrderInfoController(IOrderInfoService orderInfoService, ILogger<OrderInfoController> logger)
        {
            _orderInfoService = orderInfoService;
            _logger = logger;
        }
       
        [HttpPost()]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IDataResult<OrderInfoResponseModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetLastestOrder([FromBody] LastOrderDto request)
        {

            _logger.LogInformation("OrderInfo controller's method called");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage().ToString());
            }

            var result = await _orderInfoService.GetLastestOrder(request.User, request.CustomerId);

            if (string.IsNullOrEmpty(result.Customer?.FirstName))
            {
                return BadRequest(new Result(false,AspectMessages.InvalidRequest));
            }

            return Ok(result);

        }
    }
}
