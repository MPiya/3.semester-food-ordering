using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Text;
using WebShop.Models;


namespace WebShop.ServiceLayer
{
    public class CustomerServiceConnection 
    {


        public CustomerServiceConnection()
        {
          
        }

        public string UseServiceUrl { get; set; }

        public async Task<int> SaveCustomer(Customer item)
        {
            bool savedOk = false;
            int returnId = -1;
            

            ServiceConnection connectToAPI = new ServiceConnection();
           connectToAPI.UseUrl += "api/customers";

            if (connectToAPI != null)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    returnId = await connectToAPI.CallServicePost(content);
                    bool wasResponse = (returnId != null);
                    if (wasResponse !=null)
                    {
                        savedOk = true;
                    }
                }
                catch
                {
                    savedOk = false;
                }
            }

            
            return returnId;
        }

    }
}
