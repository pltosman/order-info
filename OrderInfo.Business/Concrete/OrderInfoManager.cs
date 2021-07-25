using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrderInfo.Business.Abstract;
using OrderInfo.Entities.Dtos;

namespace OrderInfo.Business.Concrete
{
    public class OrderInfoManager:IOrderInfoService
    {

        private readonly ILogger<OrderInfoManager> _logger;
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderService _orderService;
        private readonly ICustomerDetailService _customerDetailService;
        


        public OrderInfoManager(ILogger<OrderInfoManager> logger, IOrderItemService orderItemService, IOrderService orderService, ICustomerDetailService customerDetailService)
        {
            _logger = logger;
            _orderItemService = orderItemService;
            _orderService = orderService;
            _customerDetailService = customerDetailService;
        }

        public async Task<OrderInfoResponseModel> GetLastestOrder(string email, string customerId)
        {

            OrderInfoResponseModel model = new OrderInfoResponseModel();

            _logger.LogInformation("Get Customer's Order Info method called");


            var customer = await _customerDetailService.GetCustomerDetail(email, customerId);

            if (customer.Data != null)
            {
                var latestOrder = _orderService.GetLatestOrderByCustomerId(customer.Data.CustomerId);
                if (latestOrder.Data != null)
                {
                    var orderItems = await _orderItemService.GetListWithProductsByOrderIdAsync(latestOrder.Data.OrderId);

                    model = new OrderInfoResponseModel(customer.Data, latestOrder.Data, orderItems.Data);
                }
                else
                {
                    model = new OrderInfoResponseModel(customer.Data);
                }
            }

            return model;
        }
    }
}
