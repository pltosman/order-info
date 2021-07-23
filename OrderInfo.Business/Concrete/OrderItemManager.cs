using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderInfo.Business.Abstract;
using OrderInfo.Core.Utilities.Results;
using OrderInfo.DataAccess.Abstract;
using OrderInfo.Entities.Concrete;

namespace OrderInfo.Business.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        private IOrderItemDal _orderItemDal;

        public OrderItemManager(IOrderItemDal orderItemDal)
        {
            _orderItemDal = orderItemDal;
        }

        public IDataResult<OrderItem> GetById(int OrderItemId)
        {
            return new DataResult<OrderItem>(_orderItemDal.Get(p => p.OrderItemId == OrderItemId), true);
        }

        public async Task<IDataResult<List<OrderItem>>> GetItemsByOrderIdAsync(int orderId)
        {
            var items = await _orderItemDal.GetAllAsync(p => p.OrderId == orderId, y => y.Order);

            return new DataResult<List<OrderItem>>(items.ToList(), true);
        }

        public IDataResult<List<OrderItem>> GetList()
        {
            return new DataResult<List<OrderItem>>(_orderItemDal.GetList().ToList(), true);
        }

        public async Task<IDataResult<List<OrderItem>>> GetListWithProductsByOrderIdAsync(int orderId)
        {
            var items = await _orderItemDal.GetAllAsync(p => p.OrderId == orderId, y => y.Product);

            return new DataResult<List<OrderItem>>(items.ToList(), true);
        }
    }
}
