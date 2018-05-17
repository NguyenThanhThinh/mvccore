using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace PartyInvites.Controllers
{
    using PartyInvites.Models;
    public class HomeController : Controller
    {
        private DataContext db;

        protected HomeController(DataContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Respond() => View();

        [HttpPost]
        public IActionResult Respond(RuestResponse ruestResponse)
        {
            db.Responses.Add(ruestResponse);
            db.SaveChanges();
            return RedirectToAction(nameof(Thanks),
           new
           {
               Name = ruestResponse.Name,
               WillAttend = ruestResponse.WillAttend
           });
        }

        public IActionResult Thanks() => View();

        public IActionResult ListResponses()
        {
            return View(db.Responses.OrderByDescending(r => r.WillAttend));
        }
    }
}