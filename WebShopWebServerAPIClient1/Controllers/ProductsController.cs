using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebShop.ServiceLayer;
using WebShopModel.Model;


namespace WebShop.Controllers
{
    public class ProductsController : Controller
    {
        // use to sending request to API
        string baseURL = "https://localhost:7177/";

        // readonly ServiceConnection connectToAPAA;

        ProductServiceConnection _pService;

        public ProductsController()
        {
            _pService = new ProductServiceConnection();
        }
        //async way to get  list 

        public async Task<IActionResult> Index()

        {
            List<Product> product= await _pService.getProducts();
            ViewData.Model = product;
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
