using System;
using OrderInfo.Core.Entities;

namespace OrderInfo.Entities.Dtos
{
    public class LastOrderDto:IDto
    {

        public string User { get; set; }

        public string CustomerId { get; set; }

    }
}
