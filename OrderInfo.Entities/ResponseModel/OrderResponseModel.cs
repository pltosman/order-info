using System;
using System.Collections.Generic;
using OrderInfo.Entities.Concrete;

namespace OrderInfo.Entities.ResponseModel
{
    public class OrderResponseModel
    {
        public string OrderNumber { get; set; }

        public string OrderDate { get; set; }

        public string DeliveryAddress { get; set; }

        public string DeliveryExpected { get; set; }

        public List<OrderItemResponseModel> OrderItems { get; set; }


        public OrderResponseModel()
        {
            OrderItems = new List<OrderItemResponseModel>();
        }

        public OrderResponseModel(string orderNumber, string orderDate, string deliveryAddress, List<OrderItem> products,string deliveryExpected,bool isItGift)
        {
            this.OrderNumber = orderNumber;
            this.OrderDate = orderDate;
            this.DeliveryAddress = deliveryAddress;
            this.OrderItems = OrderItemResponseModel.FillList(products,isItGift);
            this.DeliveryExpected = deliveryExpected;
        }
    }
}
