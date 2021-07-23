using System;
using System.Collections.Generic;
using OrderInfo.Core.Utilities.Results;
using OrderInfo.Entities.Concrete;

namespace OrderInfo.Business.Abstract
{
    public interface IProductService
    {

        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetList();
      
       
    }
}
