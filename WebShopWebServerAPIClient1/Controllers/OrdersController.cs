using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebShop.BusniessLogic;
using WebShop.Models;
using WebShop.Models.ViewModels;
using WebShop.ServiceLayer;
using WebShop.Session;



namespace WebShop.Controllers
{

    public class OrdersController : Controller
    {
        CustomerServiceConnection cusService = new CustomerServiceConnection();
        OrderServiceConnection orderService = new OrderServiceConnection();
        OrderCRUD orderAccess;

        public OrdersController(IConfiguration inConfiguration)
        {
            orderAccess = new OrderCRUD(inConfiguration);
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
        public async Task<ActionResult> Create(OrderViewModel model )
        {
            Customer cus = new Customer
            {
                FirstName = model.customerVM.FirstName,
                LastName = model.customerVM.LastName,
                PhoneNu = model.customerVM.PhoneNu,
                Email = model.customerVM.Email
            };
            int customerId = await cusService.SaveCustomer(cus);
            Order order = new(customerId, model.orderVM.orderDate);
                int orderId = await orderService.SaveOrder(order);

            List<CartItem> cartItems = TempData.Get<List<CartItem>>("cartVM");
            try
            {
                foreach (var item in cartItems)
                {
                    OrderLine oLine = new OrderLine();
                    oLine.OrderID = orderId;
                    oLine.ProductID = item.ProductId;
                    oLine.Quantity = item.Quantity;
                    oLine.TotalPrice = item.Price;

                    orderAccess.ReduceProductQuantity(oLine);
                    orderAccess.CreateOrderLine(oLine);

                }

            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Orders");
            }
           
            
            return RedirectToAction(nameof(Index));



        }

        public ActionResult Error()
        {
            return View();
        }


    }
}
