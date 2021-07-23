using System;
using System.Collections.Generic;
using System.Linq;
using OrderInfo.Business.Abstract;
using OrderInfo.Core.Utilities.Results;
using OrderInfo.DataAccess.Abstract;
using OrderInfo.Entities.Concrete;

namespace OrderInfo.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new DataResult<Product>(_productDal.Get(p => p.ProductId == productId),true);
        }

       
        public IDataResult<List<Product>> GetList()
        {
            return new DataResult<List<Product>>(_productDal.GetList().ToList(),true);
        }
    }
}
