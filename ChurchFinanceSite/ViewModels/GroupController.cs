using ChurchFinanceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChurchFinanceSite.ViewModels
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index()
        {
            var group = new List<Group>
            {
                new Group{ID = 1, Name = "Dames", GroupDateCreated = Convert.ToDateTime("2001-09-5")},
                new Group{ID = 2, Name = "Hommes", GroupDateCreated = Convert.ToDateTime("2000-10-4")},
                new Group{ID = 4, Name = "Jeune", GroupDateCreated = Convert.ToDateTime("2003-07-17")},
                new Group{ID = 3, Name = "kids", GroupDateCreated = Convert.ToDateTime("2009-5-8")},
            };
            return View(group.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}