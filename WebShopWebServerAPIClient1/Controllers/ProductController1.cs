using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebShopModel.Model;
using WebShopWebServerAPIClient.ServiceLayer;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        // use to sending request to API
        string baseURL = "https://localhost:7177/";

        ServiceConnection connection;

        public ProductController()
        {
            ServiceConnection connection = new ServiceConnection();
        }
        //async way to get  list 
        public async Task<IActionResult> Index()

        {
            //Consume API
            IList<Product> user = new List<Product>();
            ServiceConnection connectToAPI = new ServiceConnection();
            connectToAPI.UseUrl += "api/products";
            //Check response
            HttpResponseMessage getData = await connectToAPI.CallServiceGet();

            if (getData.IsSuccessStatusCode)
            {

                string results = getData.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<List<Product>>(results);
            }

            else
            {
                Console.WriteLine("Error");
            }

            ViewData.Model = user;

            return View();
        }

        /* public async Task<IActionResult> Index()

         {
             IList<Product> user = new List<Product>();
             ServiceConnection a = new ServiceConnection();
             a.UseUrl += "api/Products";

             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri(baseURL);
                 //idk client.DefaultRequestHeaders.Accept.Clear();
                 //idk client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                 // HttpResponseMessage getData = await    client.GetAsync("api/Products");
                 HttpResponseMessage getData = await a.CallServiceGet();
                 if (getData.IsSuccessStatusCode)
                 {

                     string results = getData.Content.ReadAsStringAsync().Result;
                     user = JsonConvert.DeserializeObject<List<Product>>(results);
                 }

                 else
                 {
                     Console.WriteLine("Error ");
                 }

                 ViewData.Model = user;
             }
             return View();
         }*/
    }
}
