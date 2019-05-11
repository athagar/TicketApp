using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketApp.Models;
using TicketApp.ViewModels;

namespace TicketApp.Controllers
{
    public class TechController : Controller
    {
        private ApplicationDbContext _context;  // Step 1. temporary DB context object A.K.A. The Database

        public TechController()  //ctor + tabtab  Step 2. opening the context object
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
            var teches = _context.Teches.ToList();

            return View(teches);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Tech tech)
        {
            if (tech.Id == 0)
                _context.Teches.Add(tech);

            _context.Teches.Add(tech);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        

        public ActionResult Delete (int id)
        {
            Tech tech = _context.Teches.Where(t => t.Id == id).FirstOrDefault();

            _context.Teches.Remove(tech);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}