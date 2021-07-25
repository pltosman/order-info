using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrderInfo.Business.Abstract;
using OrderInfo.Core.Utilities.Results;
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

        public async Task<IDataResult<OrderInfoResponseModel>> GetLastestOrder(string email, string customerId)
        {

            DataResult<OrderInfoResponseModel> model = new (null,false);

            _logger.LogInformation("Get Customer's Order Info method called");

            var customer = await _customerDetailService.GetCustomerDetail(email, customerId);
          
            if (customer.Success)
            {
                var latestOrder = _orderService.GetLatestOrderByCustomerId(customer.Data.CustomerId);
                if (latestOrder.Data != null)
                {
                    var orderItems = await _orderItemService.GetListWithProductsByOrderIdAsync(latestOrder.Data.OrderId);

                    model = new (new OrderInfoResponseModel(customer.Data, latestOrder.Data, orderItems.Data),true);
                }
                else
                {
                    model = new (new OrderInfoResponseModel(customer.Data),true);
                }
            }
            else
            {
                model = new(null, customer.Success, customer.Message);
            }

            return model;
        }
    }
}
