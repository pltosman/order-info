using System;
using System.Threading.Tasks;
using OrderInfo.Core.Entities.Concrete;
using OrderInfo.Core.Utilities.Results;

namespace OrderInfo.Business.Abstract
{
    public interface ICustomerDetailService
    {
        Task<IDataResult<CustomerDetailResponse>> GetCustomerDetail(string customerEmail, string customerId);
    }
}
