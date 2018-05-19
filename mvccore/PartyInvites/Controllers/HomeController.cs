using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
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

        public IActionResult Respond()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Respond(RuestResponse ruestResponse)
        {
            db.Responses.Add(ruestResponse);
            db.SaveChanges();
            return RedirectToAction(nameof(Thanks),
                new {ruestResponse.Name, ruestResponse.WillAttend});
        }

        public IActionResult Thanks()
        {
            return View();
        }

        public IActionResult ListResponses()
        {
            return View(db.Responses.OrderByDescending(r => r.WillAttend));
        }
    }
}