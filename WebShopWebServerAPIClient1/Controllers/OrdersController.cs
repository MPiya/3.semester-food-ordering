using Microsoft.AspNetCore.Mvc;
using WebShop.ServiceLayer;
using WebShopModel.Model;

namespace WebShop.Controllers
{
    public class OrdersController : Controller
    {

        CustomerServiceConnection cusService = new CustomerServiceConnection();
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

            try
            {
                Customer cus = new(customer.FirstName, customer.LastName, customer.PhoneNu, customer.Email);


                bool wasOk = await cusService.SaveCustomer(cus);
                
            }


            catch {

                System.Console.WriteLine("Hello World!");
                // TempData["ProcessText"] = "Technical error!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
