using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderInfo.Core.Utilities.Results;
using OrderInfo.Entities.Concrete;

namespace OrderInfo.Business.Abstract
{
    public interface IOrderItemService
    {
        IDataResult<OrderItem> GetById(int productId);
        IDataResult<List<OrderItem>> GetList();
        Task<IDataResult<List<OrderItem>>> GetItemsByOrderIdAsync(int orderId);
        Task<IDataResult<List<OrderItem>>> GetListWithProductsByOrderIdAsync(int orderId);
        
    }
}
