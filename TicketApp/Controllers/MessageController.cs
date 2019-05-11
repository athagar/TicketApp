using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TicketApp.Models;
using TicketApp.ViewModels;

namespace TicketApp.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        
        private ApplicationDbContext _context;  // Step 1. temporary DB context object A.K.A. The Database

        public MessageController()  //ctor + tabtab  Step 2. opening the context object
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
            var messages = _context.Messages.Include(i => i.Tech).ToList();

            return View(messages);
        }

        public ActionResult AdminIndex()
        {
            var messages = _context.Messages.Include(i => i.Tech).ToList();

            return View(messages);
        }

        public ActionResult Details(int id)
        {
            var message = _context.Messages.Include(i => i.Tech).SingleOrDefault(m => m.Id == id);

            if (message == null)
                return HttpNotFound();

            return View(message);
        }


        [HttpGet]
        public ActionResult New()
        {
            var teches = _context.Teches.ToList();
            var viewModel = new MessageTechViewModel
            {
                Teches = teches
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult New (Message message)
        {
            message.DatePosted = DateTime.Now;
            
            if(message.Id ==0)
                _context.Messages.Add(message);

            _context.Messages.Add(message);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id) // https://www.udemy.com/the-complete-aspnet-mvc-5-course/learn/v4/t/lecture/4924174?start=0
        {
            var message = _context.Messages.SingleOrDefault(c => c.Id == id);

            if (message == null)
                return HttpNotFound();

            var viewModel = new MessageTechViewModel
            {
                Message = message,
                Teches = _context.Teches.ToList()
            };
            return View(viewModel);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(Message message)
        {
            
                var messageInDb = _context.Messages.Single(m => m.Id == message.Id);

                messageInDb.Name = message.Name;
                messageInDb.Subject = message.Subject;
                messageInDb.Body = message.Body;
                messageInDb.TechId = message.TechId;

            _context.SaveChanges();

            return RedirectToAction("AdminIndex");
            
            
        }

        [HttpGet]
        public ActionResult CreateReply()
        {
            var reply = new Reply();
            return View(reply);
        }

        [HttpPost]
        public ActionResult CreateReply(Reply reply, int id)
        {
            reply.DatePosted = DateTime.Now;
            reply.MessageId = id;

            if (reply.Id == 0)
                _context.Replies.Add(reply);

            _context.Replies.Add(reply);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = id });
        }

       
        public ActionResult ConfirmDelete(int id)
        {
            Message message = _context.Messages.Where(r => r.Id == id).FirstOrDefault();

            return View("Delete", message);
        }

        
        public ActionResult Delete (int id)
        {
            Message message = _context.Messages.Where(r => r.Id == id).FirstOrDefault();

            _context.Messages.Remove(message);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}