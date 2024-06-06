using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UzbekAcademy_of_IT.Controllers
{
    public class csController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public csController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // GET: csController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult JoinMeeting()
        {
            try
            {
                // Fayldan linkni o'qish
                string linkPath = "link.txt";
                string meetingLinkFromFile = "";

                // Fayldan linkni o'qish
                using (StreamReader reader = new StreamReader(linkPath))
                {
                    // Birinchi qatorni o'qish
                    string line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        // Linkni ajratib olish
                        string[] parts = line.Split(new[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length == 2)
                        {
                            meetingLinkFromFile = parts[1]; // link nomi
                                                            // Boshqacha formatda yo'naltirish uchun '[' va ']' belgilarni olib tashlash
                            meetingLinkFromFile = meetingLinkFromFile.Replace("[", "").Replace("]", "");
                        }
                    }
                }

                // Agar link mavjud bo'lsa, onlayn darsga yo'naltirish
                if (!string.IsNullOrEmpty(meetingLinkFromFile))
                {
                    return Redirect(meetingLinkFromFile);
                }
                else
                {
                    // Agar link topilmagan bo'lsa, error sahifasiga yo'naltirish
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                // Xatolik yuz berib, error sahifasiga yo'naltirish
                _logger.LogError("Meeting linkni o'qishda xatolik yuz berdi: {0}", ex.Message);
                return View("Error");
            }
        }
        public ActionResult Kirish()
        {
            return View();
        }
        public ActionResult mantiqiy()
        {
            return View();
        }
        public ActionResult Massiv()
        {
            return View();
        }
        public ActionResult Math()
        {
            return View();
        }
        public ActionResult Satr()
        {
            return View();
        }
        public ActionResult Shart()
        {
            return View();
        }
        public ActionResult Takrorlash()
        {
            return View();
        }
        // GET: csController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: csController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: csController/Create
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

        // GET: csController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: csController/Edit/5
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

        // GET: csController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: csController/Delete/5
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
