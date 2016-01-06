using Simple.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISimpleDbContext _db;
        public HomeController(ISimpleDbContext db)
        { _db = db; }
        public ActionResult Index()
        {
            ViewBag.NumberOfTickets = _db.Tickets.Count();
            return View();
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