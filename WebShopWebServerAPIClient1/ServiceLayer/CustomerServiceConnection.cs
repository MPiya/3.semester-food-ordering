using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebShopModel.Model;
using WebShopWebServerAPIClient.ServiceLayer;

namespace WebShop.ServiceLayer
{
    public class CustomerServiceConnection 
    {

        readonly IServiceConnection _lineServiceConnection;

        public CustomerServiceConnection()
        {
            _lineServiceConnection = new ServiceConnection();
        }

        public string UseServiceUrl { get; set; }

        public async Task<bool> SaveCustomer(Customer item)
        {
            bool savedOk = false;

            _lineServiceConnection.UseUrl = _lineServiceConnection.UseUrl;
            _lineServiceConnection.UseUrl += "customers";

            if (_lineServiceConnection != null)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var serviceResponse = await _lineServiceConnection.CallServicePost(content);
                    bool wasResponse = (serviceResponse != null);
                    if (wasResponse && serviceResponse.IsSuccessStatusCode)
                    {
                        savedOk = true;
                    }
                }
                catch
                {
                    savedOk = false;
                }
            }

            return savedOk;
        }

    }
}
