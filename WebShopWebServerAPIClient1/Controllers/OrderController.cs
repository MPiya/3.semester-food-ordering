using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class OrderController : Controller
    {
        public async Task<IActionResult> Index()

        {

            return View();
        }
        public async Task<IActionResult> BookTable()

        {

            return View();
        }
    }
}
