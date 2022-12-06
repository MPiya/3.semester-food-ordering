using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebShopModel.Model;
using WebShopWebServerAPIClient.ServiceLayer;

namespace WebShop.ServiceLayer
{
    public class CustomerServiceConnection 
    {


        public CustomerServiceConnection()
        {
          
        }

        public string UseServiceUrl { get; set; }

        public async Task<bool> SaveCustomer(Customer item)
        {
            bool savedOk = false;

            ServiceConnection connectToAPI = new ServiceConnection();
           connectToAPI.UseUrl += "api/customers";

            if (connectToAPI != null)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var serviceResponse = await connectToAPI.CallServicePost(content);
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
