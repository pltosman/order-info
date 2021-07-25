using System;
using System.Threading.Tasks;
using OrderInfo.Entities.Dtos;

namespace OrderInfo.Business.Abstract
{
    public interface IOrderInfoService
    {
       Task<OrderInfoResponseModel> GetLastestOrder(string email, string customerId);
    }
}
