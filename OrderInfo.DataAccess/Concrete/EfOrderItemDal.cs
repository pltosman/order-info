using System;
using OrderInfo.Core.DataAccess.EntityFramework;
using OrderInfo.DataAccess.Abstract;
using OrderInfo.DataAccess.Concrete.EntityFramework.Contexts;
using OrderInfo.Entities.Concrete;

namespace OrderInfo.DataAccess.Concrete
{
    public class EfOrderItemDal : EfEntityRepositoryBase<OrderItem, OrderInfoContext>, IOrderItemDal
    {

    }
}
