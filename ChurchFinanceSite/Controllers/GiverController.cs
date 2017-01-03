using ChurchFinanceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ChurchFinanceSite.Controllers
{
    public class GiverController : Controller
    {
        private ApplicationDbContext _context;

        public GiverController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Giver
        public ActionResult Index()
        {
            var givers = _context.Givers;
            return View(givers.ToList());
        }

        public ActionResult GiverAndAddress()
        {
            return View();
        }
       
    }
}