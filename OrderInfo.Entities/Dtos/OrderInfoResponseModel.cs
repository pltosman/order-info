using System;
using System.Collections.Generic;
using OrderInfo.Core.Entities.Concrete;
using OrderInfo.Entities.Concrete;
using OrderInfo.Entities.ResponseModel;

namespace OrderInfo.Entities.Dtos
{
    public class OrderInfoResponseModel
    {
        public CustomerResponseModel Customer { get; set; }

        public OrderResponseModel Order { get; set; }

     

        public OrderInfoResponseModel()
        {

            Customer = new CustomerResponseModel();
            Order = new OrderResponseModel();
        }


        public OrderInfoResponseModel(CustomerDetailResponse customer, Order order, List<OrderItem> orderItems)
        {

            if(customer!=null)
            {
                Customer = new CustomerResponseModel(customer.FirstName, customer.LastName);
            }

            if(order!=null)
            {
                Order = new OrderResponseModel(order.OrderId.ToString(), order.OrderDate.ToString(), order.OrderSource, orderItems, order.DeliveryExpected.ToString(),order.ContainGift==true?true:false);
            }
        }

    }
}
