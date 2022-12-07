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
                int returnCustomerId = await cusService.SaveCustomer(customer);
         
            Customer da = new("Adam", "Star", "4564566", "123@gmaill.com");
            
           
         //  int cusId = _customerAccess.CreateCustomera(da);
            Order ad = new(returnCustomerId, insertedDateTime);
            int orderId = _customerAccess.CreateOrder(ad);
           // int OrderLine = _customerAccess.CreateOrderLine(orderId, cusId, etc);
            


            //  Order orderOBJ = new(cus.Id, order.orderDate); */

            return RedirectToAction(nameof(Index));

        }
    }
}
