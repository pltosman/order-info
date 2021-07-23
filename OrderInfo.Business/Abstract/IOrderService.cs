using System;
using System.Collections.Generic;
using OrderInfo.Core.Utilities.Results;
using OrderInfo.Entities.Concrete;

namespace OrderInfo.Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<Order> GetById(int productId);
        IDataResult<List<Order>> GetList();
        IDataResult<Order> GetLatestOrderByCustomerId(string customerId);

    }
}
