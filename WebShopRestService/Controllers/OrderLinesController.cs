using Microsoft.AspNetCore.Mvc;

namespace RESTAPI.Controllers
{
    public class OrderLinesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
