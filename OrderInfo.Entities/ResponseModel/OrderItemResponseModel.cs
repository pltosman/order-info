using System;
using System.Collections.Generic;
using OrderInfo.Entities.Concrete;

namespace OrderInfo.Entities.ResponseModel
{
    public class OrderItemResponseModel
    {

        public string Product { get; set; }

        public string Quantity { get; set; }

        public string PriceEach { get; set; }


        public OrderItemResponseModel()
        {
        }

        public OrderItemResponseModel(string product, string quantity, string priceEach)
        {
            this.PriceEach = priceEach;
            this.Quantity = quantity;
            this.Product = product;
        }

        public static List<OrderItemResponseModel> FillList(List<OrderItem> orderItems,bool IsItGift)
        {
            var VMs = new List<OrderItemResponseModel>();
            foreach (OrderItem orderItem in orderItems)
            {
                if(IsItGift) orderItem.Product.ProductName = "Gift";
                VMs.Add(new OrderItemResponseModel(orderItem.Product.ProductName,orderItem.Quantity.ToString(),orderItem.Price.ToString()));
            }
            return VMs;
        }
    }
}
