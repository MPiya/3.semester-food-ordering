using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebShopModel.Model;
using WebShopWebServerAPIClient.ServiceLayer;

namespace WebShop.Controllers
{
    public class OrdersController : Controller
    {

        // use to sending request to API
        string baseURL = "https://localhost:7177/";

        ServiceConnection connection;

        public OrdersController()
        {
            ServiceConnection connection = new ServiceConnection();
        }

        public async Task<IActionResult> Index()

        {

            return View();
        }
        public async Task<IActionResult> BookTable()

        {

            return View();
        }

        

        public async Task<IActionResult> addProductById(int id)
        {

            List<Product> products = new List<Product>();
            Product user = new Product();
            //consume API
            ServiceConnection connectToAPI = new ServiceConnection();
            connectToAPI.UseUrl += "api/products/" + 1.ToString();
            //Check response
            HttpResponseMessage getData = await connectToAPI.CallServiceGet();

            if (getData.IsSuccessStatusCode)
            {
                // convert the wished product to object in variable user
                string results = getData.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<Product>(results);
            }

            else
            {
                Console.WriteLine("Error");
            }
            // add product object in List<products>
            products.Add(user);



            ViewData.Model = products;

            return View();

        }
    }
}
