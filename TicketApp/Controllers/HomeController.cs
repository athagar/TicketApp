using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketApp.Models;

namespace TicketApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;  // Step 1. temporary DB context object A.K.A. The Database

        public HomeController()  //ctor + tabtab  Step 2. opening the context object
        {
            _context = new ApplicationDbContext();
        }
        // Step 3. Use the db however you want in the Actions below
        protected override void Dispose(bool disposing)  // Step 4. disposing of the  object
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var messages = _context.Messages.ToList();

            return View(messages);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}