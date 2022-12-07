using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebShop.BusniessLogic;
using WebShop.ServiceLayer;
using WebShopData.DatabaseLayer;
using WebShopModel.Model;
using WebShopWebServerAPIClient.ServiceLayer;

namespace WebShop.Controllers
{

    public class OrdersController : Controller
    {

        CustomerServiceConnection cusService = new CustomerServiceConnection();


        CustomerDatabaseAccessa _customerAccess;

        public OrdersController(IConfiguration inConfiguration)
        {
            _customerAccess = new CustomerDatabaseAccessa(inConfiguration);
        }
        public IActionResult Index()
        {
            return View();
        }


        // GET: ShapesController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: Customers/Create
        [HttpPost]

        public async Task<ActionResult> Create(Customer customer)
        {
            DateTime insertedDateTime = DateTime.Now;
            await cusService.SaveCustomer(customer);
            Customer cus = new(customer.Id, customer.FirstName, customer.LastName, customer.PhoneNu, customer.Email);

            Customer da = new(26, "aa", "gg", "ff", "ew");
            
            Order ad = new(da.Id, insertedDateTime);
            _customerAccess.CreateOrder(ad);


            //  Order orderOBJ = new(cus.Id, order.orderDate); */

            return RedirectToAction(nameof(Index));

        }
    }
}
