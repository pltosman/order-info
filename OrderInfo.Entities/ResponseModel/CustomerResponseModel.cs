using System;
namespace OrderInfo.Entities.ResponseModel
{
    public class CustomerResponseModel
    {
        public string FirstName { get; set; }
        public string lastName { get; set; }

        public CustomerResponseModel()
        {

        }

        public CustomerResponseModel(string firstname, string lastName)
        {
            this.FirstName = firstname;
            this.lastName = lastName;
        }
    }
}
