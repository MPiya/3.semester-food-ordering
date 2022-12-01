using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using WebShop.Busniesslogic;
using WebShop.Models;
using WebShop.Repository;
using WebShop.Views;
using WebShopModel.Model;
using WebShopWebServerAPIClient.ServiceLayer;

namespace WebShop.Controllers
{
    public class OrdersController : Controller
    {

        // use to sending request to API
        string baseURL = "https://localhost:7177/";

        ServiceConnection connection;
        List<Product> products;
        OrderLine orderLine;
        UnitOfWork _unitOfWork;

        public ShoppingCartViewModel shoppingcart { get; set; }
        Databaseaccess dataacc;
        public OrdersController(IConfiguration inConfiguration)
        {
            ServiceConnection connection = new ServiceConnection();
            products = new List<Product>();
            dataacc = new Databaseaccess(inConfiguration);



        }

        protected string PriceFormat(decimal price)
        {
            System.Globalization.CultureInfo danish = new System.Globalization.CultureInfo("da-DK");
            danish = (System.Globalization.CultureInfo)danish.Clone();
            // Adjust these to suit
            danish.NumberFormat.CurrencyPositivePattern = 3;
            danish.NumberFormat.CurrencyNegativePattern = 3;
            decimal value = price;
            string output = value.ToString("C", danish);

            return output;
        }
        public async Task<IActionResult> Index()

        {
            /*
            shoppingcart = new ShoppingCartViewModel()
            {
                ListCart = dataacc.getAll()
            }; */

            List<ShoppingCart> cart;
            cart  = dataacc.showTable();
                
            return View(cart);

        }



        public async Task<IActionResult> BookTable()

        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> addProductById(int id)
        {


            // create a product object
            Product user = new Product();
            //consume API
            ServiceConnection connectToAPI = new ServiceConnection();
            connectToAPI.UseUrl += "api/products/" + id.ToString();
            //Check response
            HttpResponseMessage getData = await connectToAPI.CallServiceGet();

            // if its true then product object will be created based on the product ID
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

            //return Redirect("/Products/Index");

        }




        public async Task<IActionResult> Details(int ID)
        {

            Product user = new Product();
            //consume API
            ServiceConnection connectToAPI = new ServiceConnection();
            connectToAPI.UseUrl += "api/products/" + ID.ToString();
            //Check response
            HttpResponseMessage getData = await connectToAPI.CallServiceGet();

            // if its true then product object will be created based on the product ID
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

            ShoppingCart cartObj = new ShoppingCart()
            {
                ProductId = ID,
                Count = 1,
                Product = user

            };


            dataacc.CreateProduct(cartObj);




            return RedirectToAction("Index");

        }



        [HttpPost]
        /*
        [ValidateAntiForgeryToken]
        [Authorize]*/

        public IActionResult Details(ShoppingCart CartObject)
        {


            _unitOfWork.ShoppingCart.Add(CartObject);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }






    }





}

