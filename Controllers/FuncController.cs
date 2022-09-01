using DawaAPI.Data.Word;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DawaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FuncController : Controller
    {
        // GET: FuncController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult WordReader()
        {
            return Content("Worked!");
        }

        // GET: FuncController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FuncController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FuncController/Create
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

        // GET: FuncController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FuncController/Edit/5
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

        // GET: FuncController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FuncController/Delete/5
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
