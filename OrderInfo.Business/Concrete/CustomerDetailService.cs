using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrderInfo.Business.Abstract;
using OrderInfo.Core.Entities.Concrete;
using OrderInfo.Core.Utilities.Messages;
using OrderInfo.Core.Utilities.Results;
using OrderInfo.Core.Utilities.Security;
using OrderInfo.Entities.Concrete;
using RestSharp;

namespace OrderInfo.Business.Concrete
{
    public class CustomerDetailService : ICustomerDetailService
    {

        private readonly ILogger<CustomerDetailService> _logger;
        private readonly RestClient _restClient;
        private readonly ApplicationSettings _settings;

        public CustomerDetailService(ILogger<CustomerDetailService> logger, IOptions<ApplicationSettings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
            _restClient = new RestClient(_settings.CustomerSettings.ApiBaseUrl);
        }

        public async Task<IDataResult<CustomerDetailResponse>> GetCustomerDetail(string customerEmail, string customerId)
        {

            if (string.IsNullOrEmpty(customerEmail))
            {
                _logger.LogError(AspectMessages.InvalidRequest);
            }

            var response = await GetDetail(customerEmail);

            if(response.Data == null)
            {
                return new DataResult<CustomerDetailResponse>(null, false, AspectMessages.InvalidRequest);
            }

            if(!IsCustomerIdSame(customerId,response.Data.CustomerId))
            {
                return new DataResult<CustomerDetailResponse>(null, false, AspectMessages.InvalidRequest);
            }


            return response;
        }


        private async Task<IDataResult<CustomerDetailResponse>> GetDetail(string customerEmail)
        {
            var customerDetailResponse = new DataResult<CustomerDetailResponse>(null, false);

            try
            {
                var url = _settings.CustomerSettings.ApiBaseUrl;

                var client = new RestClient(url);
                var request = new RestRequest($"/GetUserDetails", Method.GET);
                request.AddParameter("code", string.Format(_settings.CustomerSettings.ApiCode), ParameterType.QueryString);
                request.AddParameter("email", string.Format(customerEmail), ParameterType.QueryString);
                request.AddHeader("Content-type", "application/json");

                var cancellationTokenSource = new CancellationTokenSource();

                var response = await client.ExecuteAsync(request, cancellationTokenSource.Token);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResponse = (JObject)JsonConvert.DeserializeObject(response.Content);
                    var json = jsonResponse.ToString();
                    var data = JsonConvert.DeserializeObject<CustomerDetailResponse>(json);
                    customerDetailResponse = new DataResult<CustomerDetailResponse>(data, true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return customerDetailResponse;
        }

        private bool IsCustomerIdSame(string requestCustomerId, string responseCustomerId)
        {

            if (requestCustomerId.Equals(responseCustomerId))
                return true;

            return false;

        }
    }
}
