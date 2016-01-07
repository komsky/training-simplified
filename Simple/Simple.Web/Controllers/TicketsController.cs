using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Simple.DAL.Context;
using Simple.DAL.Entities;
using Simple.Web.Models;
using Microsoft.AspNet.Identity;
using AutoMapper;
using Simple.Web.Models.Factories;

namespace Simple.Web.Controllers
{
    [Authorize] //Tylko się upewniam, że jesteście zalogowani
    public partial class TicketsController : Controller
    {
        //private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly ISimpleDbContext _db;
        public TicketsController(ISimpleDbContext db)
        {
            _db = db;
        }

        // GET: Tickets
        public virtual ActionResult Index()
        {
            var tickets = _db.Tickets.Include(t => t.AssignedAgent).Include(t => t.Owner).Include(t => t.Product).Select(Mapper.DynamicMap<TicketViewModel>);
            return View(tickets);
        }
        public virtual ActionResult Search(string id)
        {
            var tickets = _db.Tickets
                .Include(t => t.AssignedAgent)
                .Include(t => t.Owner).Include(t => t.Product)
                .Where(x=>x.Title.Contains(id) 
                    || x.Description.Contains(id)
                    || x.AgentReply.Contains(id))
                .Select(Mapper.DynamicMap<TicketViewModel>);
            return View(MVC.Tickets.Views.Index, tickets);
        }

        // GET: Tickets/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketViewModel ticket = _db.Tickets.Find(id).ToTicketViewModel();
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public virtual ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(_db.Products, "Id", "Name");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TicketViewModel ticket)
        {
            if (ModelState.IsValid)
            {

                ticket.OwnerId = User.Identity.GetUserId();
                _db.Tickets.Add(ticket.ToTicket());
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(_db.Products, "Id", "Name");
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketViewModel ticket = _db.Tickets.Find(id).ToTicketViewModel();
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(_db.Products, "Id", "Name");
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TicketViewModel ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.OwnerId = User.Identity.GetUserId();
                _db.Entry(ticket.ToTicket()).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(_db.Products, "Id", "Name");
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketViewModel ticket = _db.Tickets.Find(id).ToTicketViewModel();
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = _db.Tickets.Find(id);
            _db.Tickets.Remove(ticket);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
