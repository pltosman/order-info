using System;
namespace OrderInfo.Core.Entities.Concrete
{
    public class CustomerDetailResponse
    {
        public string  Email { get; set; }
        public string  CustomerId { get; set; }
        public bool  WebSite { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public string  LastLoggedIn { get; set; }
        public string  HouseNumber { get; set; }
        public string  Street { get; set; }
        public string  Town { get; set; }
        public string  PostCode { get; set; }
        public string  PreferredLanguage { get; set; }

    }
}
