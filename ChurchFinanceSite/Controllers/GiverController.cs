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
        List<Giver> givers;
        // GET: Giver
        public ActionResult Index()
        {
            givers = new List<Giver>
            {
                new Giver {ID = 1, FirstName = "James", LastName = "Leveille" },
                new Giver {ID = 2, FirstName = "Markys", LastName = "Jean Pierre" },
                new Giver {ID = 3, FirstName = "Kendall", LastName = "Leveille" },
                new Giver {ID = 4, FirstName = "Barbara", LastName = "Hypolite" }
            };
            return View(givers.ToList());
        }

       
    }
}