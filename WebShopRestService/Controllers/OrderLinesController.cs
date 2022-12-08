using Microsoft.AspNetCore.Mvc;

namespace RestAPi.Controllers
{
    public class OrderLinesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
