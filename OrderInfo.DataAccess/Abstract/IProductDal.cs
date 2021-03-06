using System;
using OrderInfo.Core.DataAccess;
using OrderInfo.Entities.Concrete;

namespace OrderInfo.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {

    }
}

