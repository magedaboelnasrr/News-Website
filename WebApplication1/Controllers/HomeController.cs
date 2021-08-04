using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        NewsContext db;

        public HomeController(NewsContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var data = db.Categories.ToList();
            return View(data);
        }
        public IActionResult Messages()
        {
            var data = db.Contacts.ToList();
            return View(data);
        }
        [Authorize]
        public IActionResult News(int id)
        {
            Category c = db.Categories.Find(id);
            ViewBag.cat = c.Name;

            var data = db.News.Where(x => x.CategoryId == id).OrderByDescending(x => x.Date).Select(x=>x).ToList();
            return View(data);
        }
        public IActionResult DeleteNews(int id)
        {
            var data = db.News.Find(id);
            db.News.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveContact(ContactUS model)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View("Contact", model);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
