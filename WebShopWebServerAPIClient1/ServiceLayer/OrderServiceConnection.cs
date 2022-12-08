using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Text;
using WebShopModel.Model;
using WebShopWebServerAPIClient.ServiceLayer;

namespace WebShop.ServiceLayer
{
    public class OrderServiceConnection 
    {
        public OrderServiceConnection()
        {
          
        }

        public string UseServiceUrl { get; set; }

        public async Task<int> SaveOrder(Order item)
        {
            bool savedOk = false;
            int returnOrderId = -1;
            ServiceConnection connectToAPI = new ServiceConnection();
           connectToAPI.UseUrl += "api/orders";

            if (connectToAPI != null)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    returnOrderId = await connectToAPI.CallServicePost(content);
                    // if Post request fail it would return -1 else return the orderId 
                    bool wasResponse = (returnOrderId != null);
                    if (wasResponse != null)
                    {
                        savedOk = true;
                    }
                }
                catch
                {
                    savedOk = false;
                }
            }

            
            return returnOrderId;
        }

    }
}
