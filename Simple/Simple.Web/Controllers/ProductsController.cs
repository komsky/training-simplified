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
using Simple.Web.Models.Factories;
using Simple.Web.Models;

namespace Simple.Web.Controllers
{
    public class ProductsController : Controller
    {
        //private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly ISimpleDbContext _db;
        public ProductsController(ISimpleDbContext db)
        {
            _db = db;
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = _db.Products.Include(p => p.Customer).Select(ProductFactories.CreateProductViewModel);
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductViewModel product = _db.Products.Find(id).ToProductViewModel();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Color,Price,DateAdded,CustomerId")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product.ToProduct());
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "Name", product.CustomerId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductViewModel product = _db.Products.Find(id).ToProductViewModel();
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "Name", product.CustomerId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Color,Price,DateAdded,CustomerId")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(product.ToProduct()).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "Name", product.CustomerId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductViewModel product = _db.Products.Find(id).ToProductViewModel();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _db.Products.Find(id);
            _db.Products.Remove(product);
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
