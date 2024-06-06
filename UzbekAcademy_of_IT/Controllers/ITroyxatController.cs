using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UzbekAcademy_of_IT.Controllers
{
    public class ITroyxatController : Controller
    {
        // GET: ITroyxatController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult books()
        {  
            return View(); 
        }
        // GET: ITroyxatController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ITroyxatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ITroyxatController/Create
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

        // GET: ITroyxatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ITroyxatController/Edit/5
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

        // GET: ITroyxatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ITroyxatController/Delete/5
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
