using System;
using System.Threading.Tasks;
using OrderInfo.Core.Utilities.Results;
using OrderInfo.Entities.Dtos;

namespace OrderInfo.Business.Abstract
{
    public interface IOrderInfoService
    {
        Task<IDataResult<OrderInfoResponseModel>> GetLastestOrder(string email, string customerId);
    }
}
