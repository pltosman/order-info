using System.ComponentModel.DataAnnotations.Schema;
using OrderInfo.Core.Entities;

namespace OrderInfo.Entities.Concrete
{
    [Table(name: "PRODUCTS")]
    public class Product: IEntity
    {
        [Column( name:"PRODUCTID")]
        public int ProductId { get; set; }

        [Column(name: "PRODUCTNAME")]
        public string ProductName { get; set; }

        [Column(name: "PACKHEIGHT")]
        public decimal? PackHeight { get; set; }

        [Column(name: "PACKWIDTH")]
        public decimal? PackWidth { get; set; }

        [Column(name: "PACKWEIGHT")]
        public decimal? PackWeight { get; set; }

        [Column(name: "COLOUR")]
        public string Colour { get; set; }

        [Column(name: "SIZE")]
        public string Size { get; set; }
    
    }
}
