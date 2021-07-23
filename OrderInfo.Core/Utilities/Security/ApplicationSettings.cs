using System;
namespace OrderInfo.Core.Utilities.Security
{
    public class ApplicationSettings
    {
        public AuthSettings AuthSettings { get; set; }
        public CustomerSettings CustomerSettings { get; set; }
    }

    public class AuthSettings
    {
        public string Url { get; set; }
        public string Type { get; set; }
        public string ApiName { get; set; }
        public string RequireHttpsMetadata { get; set; }
    }

    public class CustomerSettings
    {
        public string ApiBaseUrl { get; set; }
        public string ApiCode { get; set; }      
    }
}