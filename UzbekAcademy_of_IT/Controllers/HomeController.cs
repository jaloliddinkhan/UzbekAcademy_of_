using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using UzbekAcademy_of_IT.Models;

namespace UzbekAcademy_of_IT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View(new Tekshiruv());
        }

        [HttpPost]
        public ActionResult Index(Tekshiruv model)
        {
            string userFileContent;
            string adminFileContent;

            try
            {
                using (StreamReader reader = new StreamReader("file/login_parol.txt"))
                {
                    userFileContent = reader.ReadToEnd();
                }
                using (StreamReader reader = new StreamReader("file/admin.txt"))
                {
                    adminFileContent = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Faylni o'qishda xatolik yuz berdi: {0}", ex.Message);
                return View("Error");
            }

            var userData = ParseFileContent(userFileContent);
            var adminData = ParseFileContent(adminFileContent);

            var selectLogin = model.Login;
            var selectParol = model.Parol;
            var requestedSection = model.Qiymat;

            var userRecord = userData.LastOrDefault(data => data.Item1 == selectLogin && data.Item2 == selectParol);
            var adminRecord = adminData.LastOrDefault(data => data.Item1 == selectLogin && data.Item2 == selectParol);

            if (userRecord != null)
            {
                string allowedSection = userRecord.Item3;
                if (allowedSection == requestedSection)
                {
                    ViewBag.Qiymat = allowedSection; // Qiymatni view ga uzatish
                    return View(allowedSection, model);
                }
            }

            if (adminRecord != null)
            {
                ViewBag.Qiymat = "admin"; // Admin uchun alohida view ko'rsatish
                return View("~/Views/Admin/Index.cshtml", model);
            }

            ModelState.AddModelError("", "Login yoki parol xato yoki bu bo'limga kirish ruxsatiga ega emassiz.");
            return View("Index");
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult dasturlash()
        {
            return View();
        }

        public ActionResult biologiya()
        {
            return View();
        }

        public ActionResult fizika()
        {
            return View();
        }

        public ActionResult matematika()
        {
            return View();
        }

        public ActionResult kimyo()
        {
            return View();
        }

        public ActionResult admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<Tuple<string, string, string>> ParseFileContent(string fileContent)
        {
            var items = fileContent.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var dataList = new List<Tuple<string, string, string>>();

            foreach (var item in items)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    var userInfoParts = item.Split(new[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                    if (userInfoParts.Length == 2)
                    {
                        var loginPasswordSection = userInfoParts[1].Split('$');
                        if (loginPasswordSection.Length == 2)
                        {
                            var passwordAndSection = loginPasswordSection[1].Split('&');
                            if (passwordAndSection.Length == 2)
                            {
                                dataList.Add(new Tuple<string, string, string>(loginPasswordSection[0].Trim(), passwordAndSection[0].Trim(), passwordAndSection[1].Trim()));
                            }
                        }
                    }
                }
            }

            return dataList;
        }
    }
}
