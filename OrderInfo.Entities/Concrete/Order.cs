using System;
using System.ComponentModel.DataAnnotations.Schema;
using OrderInfo.Core.Entities;

namespace OrderInfo.Entities.Concrete
{
	[Table(name: "ORDERS")]
	public class Order:IEntity
    {
		[Column(name: "ORDERID")]
		public int OrderId { get; set; }

		[Column(name: "CUSTOMERID")]
		public string CustomerId { get; set; }

		[Column(name: "ORDERDATE")]
		public DateTime? OrderDate { get; set; }

		[Column(name: "DELIVERYEXPECTED")]
		public DateTime? DeliveryExpected { get; set; }

		[Column(name: "CONTAINSGIFT")]
		public bool? ContainGift { get; set; }

		[Column(name: "SHIPPINGMODE")]
		public string ShippingMode { get; set; }

		[Column(name: "ORDERSOURCE")]
		public string OrderSource { get; set; }

	}
}
