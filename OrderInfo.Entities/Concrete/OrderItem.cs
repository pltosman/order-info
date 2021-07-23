using System;
using System.ComponentModel.DataAnnotations.Schema;
using OrderInfo.Core.Entities;

namespace OrderInfo.Entities.Concrete
{
	[Table(name: "ORDERITEMS")]
	public class OrderItem :IEntity
    {
		[Column(name:"ORDERITEMID")]
		public int OrderItemId { get; set; }

		[Column(name: "ORDERID")]
		public int? OrderId { get; set; }

		public virtual Order Order { get; set; }

		[Column(name: "PRODUCTID")]
		public int? ProductId { get; set; }

		public virtual Product Product { get; set; }

		[Column(name: "QUANTITY")]
		public int? Quantity { get; set; }

		[Column(name: "PRICE")]
		public decimal? Price { get; set; }

		[Column(name: "RETURNABLE")]
		public bool? Returnable { get; set; }

	}
}
