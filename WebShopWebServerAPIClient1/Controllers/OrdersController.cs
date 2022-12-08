using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebShop.BusniessLogic;
using WebShop.ServiceLayer;
using WebShop.Session;
using WebShopModel.Model;


namespace WebShop.Controllers
{

    public class OrdersController : Controller
    {

        CustomerServiceConnection cusService = new CustomerServiceConnection();
        OrderServiceConnection orderService = new OrderServiceConnection();

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

        public async Task<ActionResult> Create(Customer customer, Order order, CartItem cartItem )
        {
                DateTime insertedDateTime = DateTime.Now;
                int customerId = await cusService.SaveCustomer(customer);
                     order = new(customerId, insertedDateTime);
                int orderId = await orderService.SaveOrder(order);
        
            //HttpContext.Session.SetJson("Cart", cartItem);
            // CartItem item = HttpContext.Session.GetJson<CartItem>("Cart");
            // the value here are 0 im not sure why
         //   OrderLine orderline = new OrderLine(4, orderId, 3, 30);
            // OrderLine orderline = new OrderLine(item.ProductId, 90, item.Quantity, item.Total);
           // _customerAccess.CreateOrderLine(orderline);
            return RedirectToAction(nameof(Index));

            //OrderLine orderline = new OrderLine(1, 66, 2, 10);
     
            //   Customer da = new("Adam", "Star", "4564566", "123@gmaill.com");
            //  int cusId = _customerAccess.CreateCustomera(da);
            //  Order ad = new(returnCustomerId, insertedDateTime);

            //int orderId = _customerAccess.CreateOrder(ad);
            // int OrderLine = _customerAccess.CreateOrderLine(orderId, cusId, etc);



            //  Order orderOBJ = new(cus.Id, order.orderDate); */


        }
    }
}
