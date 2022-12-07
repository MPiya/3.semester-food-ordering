using Newtonsoft.Json;
using WebShopModel.Model;
using WebShopWebServerAPIClient.ServiceLayer;

namespace WebShop.ServiceLayer
{
    public class ProductServiceConnection
    {

        public async Task<List<Product>> getProducts() { 
        //Consume API
        List<Product> user = new List<Product>();

        ServiceConnection connectToAPI = new ServiceConnection();
        connectToAPI.UseUrl += "api/products";
            //Check response
            HttpResponseMessage getData = await connectToAPI.CallServiceGet();

            if (getData.IsSuccessStatusCode)
            {

                string results = getData.Content.ReadAsStringAsync().Result;
        user = JsonConvert.DeserializeObject<List<Product>>(results);
            }
            
        

            return user;
        }
    }
}
