using System.Collections.Generic;
using System.Linq;
using OrderInfo.Business.Abstract;
using OrderInfo.Core.Utilities.Results;
using OrderInfo.DataAccess.Abstract;
using OrderInfo.Entities.Concrete;

namespace OrderInfo.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

     
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IDataResult<Order> GetById(int orderId)
        {
            return new DataResult<Order>(_orderDal.Get(p => p.OrderId == orderId), true);
        }

        public IDataResult<Order> GetLatestOrderByCustomerId(string customerId)
        {
            return new DataResult<Order>(_orderDal.GetList(p => p.CustomerId == customerId).OrderByDescending(p => p.OrderDate).FirstOrDefault(),true);
        }

        public IDataResult<List<Order>> GetList()
        {
            return new DataResult<List<Order>>(_orderDal.GetList().ToList(), true);
        }
    }
}
