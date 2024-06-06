using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UzbekAcademy_of_IT.Models;

namespace UzbekAcademy_of_IT.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        { 
            return View(); 
        }
        // GET: AdminController
        [HttpGet]
        public ActionResult Admin()
        {
            var model = new meetingsave
            {
                Fanlar = new List<SelectListItem>
                {
                    new SelectListItem { Value = "dasturlash", Text = "Dasturlash" },
                    new SelectListItem { Value = "fizika", Text = "Fizika" },
                    new SelectListItem { Value = "matematika", Text = "Matematika" },
                    new SelectListItem { Value = "biologiya", Text = "Biologiya" },
                    new SelectListItem { Value = "kimyo", Text = "Kimyo" }
                }
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Admin(meetingsave model)
        {
            try
            {
                SaveMeetingLink(model.fan_nomi, model.link_nomi);
                model.Fanlar = new List<SelectListItem>
                {
                    new SelectListItem { Value = "dasturlash", Text = "Dasturlash" },
                    new SelectListItem { Value = "fizika", Text = "Fizika" },
                    new SelectListItem { Value = "matematika", Text = "Matematika" },
                    new SelectListItem { Value = "biologiya", Text = "Biologiya" },
                    new SelectListItem { Value = "kimyo", Text = "Kimyo" }
                };
                return View(model);
            }
            catch (Exception ex)
            {
                // Log error (example: _logger.LogError(ex, "Failed to save meeting link"))
                return View("Error");
            }
        }

        private void SaveMeetingLink(string fanNomi, string meetingLink)
        {
            string formattedLine = $"[{fanNomi}][{meetingLink}]";
            string filePath = "link.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(formattedLine);
            }
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            var model = new meetingsave();
            return View(model);
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(meetingsave model)
        {
            try
            {
                // Process model
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new meetingsave();
            return View(model);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, meetingsave model)
        {
            try
            {
                // Process model
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new meetingsave();
            return View(model);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, meetingsave model)
        {
            try
            {
                // Process model
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}