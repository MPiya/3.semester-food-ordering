using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPi.Controllers
{
    public class OrderLinesController : Controller
    {
        // GET: OrderLinesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderLinesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderLinesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderLinesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderLinesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderLinesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderLinesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderLinesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
