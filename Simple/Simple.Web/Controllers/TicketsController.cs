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
using AutoMapper;

namespace Simple.Web.Controllers
{
    public class TicketsController : Controller
    {
        //private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly ISimpleDbContext _db;
        public TicketsController(ISimpleDbContext db)
        {
            _db = db;
        }

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = _db.Tickets.Include(t => t.AssignedAgent).Include(t => t.Owner).Include(t => t.Product).Select(Mapper.DynamicMap<TicketViewModel>);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = _db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            //TODO: Replace with ViewModel and UserManager
            //ViewBag.AssignedAgentId = new SelectList(_db.ApplicationUsers, "Id", "Email");
            //ViewBag.OwnerId = new SelectList(_db.ApplicationUsers, "Id", "Email");
            //ViewBag.ProductId = new SelectList(_db.Products, "Id", "Name");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,TicketPriority,TicketState,ProductId,AgentReply,OwnerId,AssignedAgentId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _db.Tickets.Add(ticket);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            //TODO: Replace with ViewModel and UserManager
            //ViewBag.AssignedAgentId = new SelectList(_db.ApplicationUsers, "Id", "Email");
            //ViewBag.OwnerId = new SelectList(_db.ApplicationUsers, "Id", "Email");
            //ViewBag.ProductId = new SelectList(_db.Products, "Id", "Name");
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = _db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            //TODO: Replace with ViewModel and UserManager
            //ViewBag.AssignedAgentId = new SelectList(_db.ApplicationUsers, "Id", "Email");
            //ViewBag.OwnerId = new SelectList(_db.ApplicationUsers, "Id", "Email");
            //ViewBag.ProductId = new SelectList(_db.Products, "Id", "Name");
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,TicketPriority,TicketState,ProductId,AgentReply,OwnerId,AssignedAgentId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(ticket).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //TODO: Replace with ViewModel and UserManager
            //ViewBag.AssignedAgentId = new SelectList(_db.ApplicationUsers, "Id", "Email");
            //ViewBag.OwnerId = new SelectList(_db.ApplicationUsers, "Id", "Email");
            //ViewBag.ProductId = new SelectList(_db.Products, "Id", "Name");
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = _db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
